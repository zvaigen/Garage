using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private Garage m_Garage = null;

        public UserInterface()
        {
            m_Garage = new Garage();
        }

        public void Run()
        {
            int userInput = 8;
            do
            {
                try
                {
                    userInput = MainMenu();
                    switch (userInput)
                    {
                        case 1:
                            this.insertVehicleToGarage();
                            break;

                        case 2:
                            this.showLicenseNumbers();
                            break;

                        case 3:
                            this.updateVehicleStatus();
                            break;

                        case 4:
                            this.inflateVehicleTiresToMax();
                            break;

                        case 5:
                            this.refuelVehicle();
                            break;

                        case 6:
                            this.rechargeVehicle();
                            break;

                        case 7:
                            this.displayVehicleDetails();
                            break;

                        case 8:
                            this.ExitProgram();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press Enter to return to main menu");
                    Console.ReadLine();
                }
            }
            while (userInput != 8);
        }

        private int MainMenu()
        {     
            string mainMenu = string.Format(
@"Please choose:
1) Insert a new vehicle.
2) Show licenses numbers.
3) Change vehicle status.
4) Inflate vehicle wheels To max.
5) Fuel a vehicle.
6) Charge a vehicle.
7) Show full vehicle details.
8) Quit.");
            Console.WriteLine(mainMenu);
            return this.inputFromUserAndCheckIfInRangeInt(1, 8);
        }

        /// <summary>
        /// Option1
        /// </summary>
        private void insertVehicleToGarage()
        {
            string licenseNumber = this.inputFromUser("Insert license number:");

            if (m_Garage.IsCarInTheGarage(licenseNumber))
            {
                m_Garage.ChangeVehicleStatus(licenseNumber, Vehicle.eStatusOfVehicle.InRepair);
            }
            else
            {
                this.insertNewVehicleToGarage(licenseNumber);
            }
        }

        private void insertNewVehicleToGarage(string i_LicenseNumber)
        {
            string ownerName = this.inputFromUser("Enter owner's name:");
            string ownerPhoneNumber = this.PhoneNumberFromUser();
            string modelName = string.Empty;
            string wheelProducer = string.Empty;
            float energyLevel = 0;
            float wheelAirPressure = 0;
            int engineCapacity = 0;
            Vehicle.eCarColors color;
            Vehicle.eCarDoorsAmount door;
            Vehicle.eLicenseTypes LicenseType;
            Engine engine = null;
            List<Wheel> wheels = null;
            Vehicle vehicle = null;
            Dictionary<string, object> features = new Dictionary<string, object>();
            Console.WriteLine();
            string vehicleTypeMsg = string.Format(
@"Choose vehicle type:
1) Gas car.
2) Electric car.
3) Gas motorcycle.
4) Electric motorcycle.
5) Truck.");
            Console.WriteLine(vehicleTypeMsg);
            Vehicle.eVehicleTypes vehicleType = (Vehicle.eVehicleTypes)inputFromUserAndCheckIfInRangeInt(1, 5);
            modelName = inputFromUser("Insert the " + vehicleType + " Model name:");
            wheelProducer = inputFromUser("Insert wheels producer:");
            switch (vehicleType)
            {
                case Vehicle.eVehicleTypes.GasCar:
                    Console.WriteLine("Insert current fuel level:");
                    energyLevel = inputFromUserAndCheckIfInRangeFloat(0, 42.0f);
                    Console.WriteLine("Insert current wheel air pressure:");
                    wheelAirPressure = inputFromUserAndCheckIfInRangeFloat(0, 30.0f);
                    color = (Vehicle.eCarColors)inputCarColor();
                    features.Add("i_CarColor", color);
                    door = (Vehicle.eCarDoorsAmount)inputNumberOfCarDoors();
                    features.Add("i_CarDoors", door);
                    break;

                case Vehicle.eVehicleTypes.ElectricCar:
                    Console.WriteLine("Insert current battery level:");
                    energyLevel = inputFromUserAndCheckIfInRangeFloat(0, 2.5f);
                    Console.WriteLine("Insert current wheel air Pressure:");
                    wheelAirPressure = inputFromUserAndCheckIfInRangeFloat(0, 30.0f);
                    color = (Vehicle.eCarColors)inputCarColor();
                    features.Add("i_CarColor", color);
                    door = (Vehicle.eCarDoorsAmount)inputNumberOfCarDoors();
                    features.Add("i_CarDoors", door);
                    break;

                case Vehicle.eVehicleTypes.GasMotorcycle:
                    Console.WriteLine("Insert current fuel level:");
                    energyLevel = inputFromUserAndCheckIfInRangeFloat(0, 5.5f);
                    Console.WriteLine("Insert wheel air pressure:");
                    wheelAirPressure = inputFromUserAndCheckIfInRangeFloat(0, 33.0f);
                    LicenseType = (Vehicle.eLicenseTypes)inputMotorcycleLicenseType();
                    features.Add("i_MotorcycleLicenseType", LicenseType);
                    Console.WriteLine("Insert engine capacity:");
                    engineCapacity = inputFromUserAndCheckIfInRangeInt(0, 3000);
                    features.Add("i_EngineCapacity", engineCapacity);
                    break;

                case Vehicle.eVehicleTypes.ElectricMotorcycle:
                    Console.WriteLine("Insert current battery level:");
                    energyLevel = inputFromUserAndCheckIfInRangeFloat(0, 2.7f);
                    Console.WriteLine("Insert current wheel air pressure:");
                    wheelAirPressure = inputFromUserAndCheckIfInRangeFloat(0, 33.0f);
                    LicenseType = (Vehicle.eLicenseTypes)inputMotorcycleLicenseType();
                    features.Add("i_MotorcycleLicenseType", LicenseType);
                    Console.WriteLine("Insert engine capacity:");
                    engineCapacity = inputFromUserAndCheckIfInRangeInt(0, 3000);
                    features.Add("i_EngineCapacity", engineCapacity);
                    break;

                case Vehicle.eVehicleTypes.Truck:
                    Console.WriteLine("Insert current fuel level:");
                    energyLevel = inputFromUserAndCheckIfInRangeFloat(0, 135.0f);
                    Console.WriteLine("Insert current wheel air pressure:");
                    wheelAirPressure = inputFromUserAndCheckIfInRangeFloat(0, 32.0f);
                    string chooseIfCarryingDangerousMaterials = string.Format(
@"Choose if the truck is carrying dangerous materials:
1) Yes.
2) No.");
                    Console.WriteLine(chooseIfCarryingDangerousMaterials);
                    bool isCarryingDangerousMaterials = inputFromUserAndCheckIfInRangeInt(1, 2) == 1;
                    features.Add("i_IsCarryingDangerousMaterials", isCarryingDangerousMaterials);
                    Console.WriteLine("Insert maximum carrying Weight:");
                    float maxCarryingWeight = inputFromUserAndCheckIfInRangeFloat(0, 60000);
                    features.Add("i_MaximumCarryingWeight", maxCarryingWeight);
                    break;
            }

            engine = CreateNewVehicle.CreateEngine(vehicleType, energyLevel);
            wheels = CreateNewVehicle.NewWheels(vehicleType, wheelProducer, wheelAirPressure);
            try
            {
                vehicle = CreateNewVehicle.CreateVehicle(vehicleType, modelName, i_LicenseNumber, energyLevel, wheels, engine, features);
                m_Garage.InsertVehicleToTheGarage(ownerName, ownerPhoneNumber, vehicle);
                Console.WriteLine("New vehicle was added succesfully!");
            }
            catch
            {
                Console.WriteLine("There was a problem while trying to insert the vehicle to the garage, please try again!");
            }
        }

        /// <summary>
        /// Option2
        /// </summary>
        private void showLicenseNumbers()
        {
            Vehicle.eStatusOfVehicle carStatus = Vehicle.eStatusOfVehicle.InRepair;
            Console.WriteLine();
            string filterByCarStatus = string.Format(
@"Show car by status in the garage?
1) Yes.
2) No.");
            Console.WriteLine(filterByCarStatus);
            bool isFilterByCarStatus = inputFromUserAndCheckIfInRangeInt(1, 2) == 1;
            if (isFilterByCarStatus)
            {
                carStatus = (Vehicle.eStatusOfVehicle)chooseCarStatus();
            }

            Console.WriteLine(m_Garage.ShowLicenseNumbers(isFilterByCarStatus, carStatus));
        }

        /// <summary>
        /// Option3
        /// </summary>
        private void updateVehicleStatus()
        {
            Console.WriteLine();
            string licenseNumber = inputFromUser("Insert license number:");
            Vehicle.eStatusOfVehicle i_NewCarCondition = (Vehicle.eStatusOfVehicle)this.chooseCarStatus();
            m_Garage.ChangeVehicleStatus(licenseNumber, i_NewCarCondition);
        }

        /// <summary>
        /// Option4
        /// </summary>
        private void inflateVehicleTiresToMax()
        {
            string licenseNumber = inputFromUser("Insert license number:");
            if (m_Garage.IsCarInTheGarage(licenseNumber))
            {
                m_Garage.InflateWheelsToMaxPressure(licenseNumber);
                Console.WriteLine("Air has been added to the Wheels successfully");
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }
        }

        /// <summary>
        /// Option5
        /// </summary>
        private void refuelVehicle()
        {
            Console.WriteLine();
            string license = inputFromUser("Insert license number:");
            string chooseGasType = string.Format(
@"Choose gas type:
1) Soler.  
2) Octan95.
3) Octan96.
4) Octan98.");
            Console.WriteLine(chooseGasType);
            if (m_Garage.IsCarInTheGarage(license))
            {
                Vehicle.eGasTypes gasType = (Vehicle.eGasTypes)inputFromUserAndCheckIfInRangeInt(1, 4);
                Console.WriteLine("Insert gas amount:");
                float gasAmount = inputFromUserAndCheckIfInRangeFloat(0, 135.0f);
                m_Garage.VehicleGasRefule(license, gasType, gasAmount);
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }
        }

        /// <summary>
        /// Option6
        /// </summary>
        private void rechargeVehicle()
        {
            Console.WriteLine();
            string license = inputFromUser("Insert license number:");
            if (m_Garage.IsCarInTheGarage(license))
            {
                Console.WriteLine("Insert minutes to charge the engine:");
                float powerMinutes = inputFromUserAndCheckIfInRangeFloat(0, 3.3f);
                m_Garage.VehicleElectricCharge(license, powerMinutes);
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }
        }

        /// <summary>
        /// Option7
        /// </summary>
        private void displayVehicleDetails()
        {
            Console.WriteLine();
            string license = inputFromUser("Insert license number:");

            if (m_Garage.IsCarInTheGarage(license))
            {
                Console.WriteLine(m_Garage.GetAllVehicleDetails(license));
            }
            else
            {
                throw new ArgumentException("The wanted vehicle is not in the garage");
            }
        }

        /// <summary>
        /// Input check
        /// </summary>
        private int inputFromUserAndCheckIfInRangeInt(int i_Min, int i_Max)
        {
            int userChoise = 0;
            string userChoiseStr = string.Empty;
            bool isValidInput = false;
            Console.WriteLine("Input should be between " + i_Min + " To " + i_Max);
            while (!isValidInput)
            {
                userChoiseStr = Console.ReadLine();
                try
                {
                    userChoise = int.Parse(userChoiseStr);
                    isValidInput = userChoise >= i_Min && userChoise <= i_Max;
                    if (!isValidInput)
                    {
                        Console.WriteLine("The input is out of range, please try again");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is not an integer, please try again");
                }
            }

            return userChoise;
        }

        private float inputFromUserAndCheckIfInRangeFloat(float i_Min, float i_Max)
        {
            float userChoise = 0;
            string userChoiseStr = string.Empty;
            bool isValidInput = false;
            Console.WriteLine("Input should be between " + i_Min + " To " + i_Max);
            while (!isValidInput)
            {
                userChoiseStr = Console.ReadLine();
                try
                {
                    userChoise = float.Parse(userChoiseStr);
                    isValidInput = userChoise >= i_Min && userChoise <= i_Max;
                    if (!isValidInput)
                    {
                        Console.WriteLine("input is out of range, please try again");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is not a float, please try again");
                }
            }

            return userChoise;
        }

        private string inputFromUser(string i_Msg)
        {
            string userInputStr = string.Empty;
            Console.WriteLine(i_Msg);
            userInputStr = Console.ReadLine();
            while (string.IsNullOrEmpty(userInputStr))
            {
                Console.WriteLine("Wrong input, please try again.");
                userInputStr = Console.ReadLine();
            }

            return userInputStr;
        }

        private string PhoneNumberFromUser()
        {
            int PhoneNum = 0;
            string userChoiseStr = string.Empty;
            bool isValidInput = false;
            Console.WriteLine("Enter owner's phone number:");             
            while (!isValidInput)
            {
                userChoiseStr = Console.ReadLine();
                try
                {
                    isValidInput = int.TryParse(userChoiseStr, out PhoneNum) && userChoiseStr.Length == 10;
                    if (!isValidInput)
                    {
                        Console.WriteLine("The input should be 0501234567, please try again");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is not a phone number, please try again");
                }
            }

            return userChoiseStr;
        }

        private int inputCarColor()
        {
            string chooseColor = string.Format(
@"Choose color:
1) Yellow. 
2) White.  
3) Black.  
4) Blue.");
            Console.WriteLine(chooseColor);
            return this.inputFromUserAndCheckIfInRangeInt(1, 4);
        }

        private int inputNumberOfCarDoors()
        {
            string numberOfDoors = string.Format(
@"Choose number of doors:
1) 2. 
2) 3.
3) 4.
4) 5.");
            Console.WriteLine(numberOfDoors);
            return this.inputFromUserAndCheckIfInRangeInt(1, 4);
        }

        private int inputMotorcycleLicenseType()
        {
            string licenseType = string.Format(
@"Choose license type:
1) A. 
2) AB. 
3) A2. 
4) B1.");
            Console.WriteLine(licenseType);
            return inputFromUserAndCheckIfInRangeInt(1, 4);
        }

        private int chooseCarStatus()
        {
            string carStatus = string.Format(
@"Choose car status:
1) InRepair.
2) Repaired.
3) Payed.");
            Console.WriteLine(carStatus);
            return inputFromUserAndCheckIfInRangeInt(1, 3);
        }

        /// <summary>
        /// Option8
        /// </summary>
        private void ExitProgram()
        {
            Console.WriteLine("Good bye and please drive safely :)");
            Console.ReadLine();
        }
    }
}
