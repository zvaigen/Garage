using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateNewVehicle
    {
        public static Vehicle CreateVehicle(Vehicle.eVehicleTypes i_VehicleType, string i_Model, string i_LicenseNumber, float i_EnergyLeft, List<Wheel> i_Wheels, Engine i_engine, Dictionary<string, object> features)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case Vehicle.eVehicleTypes.ElectricCar:
                    vehicle = new ElectricCar((Vehicle.eCarColors)features["i_CarColor"], (Vehicle.eCarDoorsAmount)features["i_CarDoors"]);
                    break;

                case Vehicle.eVehicleTypes.GasCar:
                    vehicle = new GasCar((Vehicle.eCarColors)features["i_CarColor"], (Vehicle.eCarDoorsAmount)features["i_CarDoors"]);
                    break;

                case Vehicle.eVehicleTypes.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle((Vehicle.eLicenseTypes)features["i_MotorcycleLicenseType"], (int)features["i_EngineCapacity"]);
                    break;

                case Vehicle.eVehicleTypes.GasMotorcycle:
                    vehicle = new GasMotorcycle((Vehicle.eLicenseTypes)features["i_MotorcycleLicenseType"], (int)features["i_EngineCapacity"]);
                    break;

                case Vehicle.eVehicleTypes.Truck:
                    vehicle = new Truck((bool)features["i_IsCarryingDangerousMaterials"], (float)features["i_MaximumCarryingWeight"]);
                    break;
            }

            vehicle.m_EnergyLeft = i_EnergyLeft;
            vehicle.Engine = i_engine;
            vehicle.Wheels = i_Wheels;
            vehicle.LicenseNumber = i_LicenseNumber;
            vehicle.m_Model = i_Model;
            return vehicle;
        }

        public static Engine CreateEngine(Vehicle.eVehicleTypes i_VehicleType, float i_EnergyLevel)
        {
            Engine engine = null;

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleTypes.GasMotorcycle:
                    engine = new GasEngine(Vehicle.eGasTypes.Octan95, i_EnergyLevel, 5.5f);
                    break;
                case Vehicle.eVehicleTypes.ElectricMotorcycle:
                    engine = new ElectricEngine(i_EnergyLevel, 2.7f);
                    break;
                case Vehicle.eVehicleTypes.GasCar:
                    engine = new GasEngine(Vehicle.eGasTypes.Octan98, i_EnergyLevel, 42.0f);
                    break;
                case Vehicle.eVehicleTypes.ElectricCar:
                    engine = new ElectricEngine(i_EnergyLevel, 2.5f);
                    break;
                case Vehicle.eVehicleTypes.Truck:
                    engine = new GasEngine(Vehicle.eGasTypes.Octan96, i_EnergyLevel, 135.0f);
                    break;
            }

            return engine;
        }

        public static List<Wheel> NewWheels(Vehicle.eVehicleTypes i_VehicleType, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();
            int numberOfWheels = 0;
            float maximumAirPressure = 0;

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleTypes.GasMotorcycle:
                case Vehicle.eVehicleTypes.ElectricMotorcycle:
                    numberOfWheels = 2;
                    maximumAirPressure = 33.0f;
                    break;
                case Vehicle.eVehicleTypes.GasCar:
                case Vehicle.eVehicleTypes.ElectricCar:
                    numberOfWheels = 4;
                    maximumAirPressure = 30.0f;
                    break;
                case Vehicle.eVehicleTypes.Truck:
                    numberOfWheels = 12;
                    maximumAirPressure = 32.0f;
                    break;
            }

            if (maximumAirPressure < i_CurrentAirPressure || i_CurrentAirPressure < 0)
            {
                throw new ArgumentException(string.Format("Wheel's air pressure must be between {0} to {1}", 0, maximumAirPressure));
            }

            for (int i = 0; i < numberOfWheels; i++)
            {
                wheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, maximumAirPressure));
            }

            return wheels;
        }
    }
}
