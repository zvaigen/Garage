using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehiclesInTheGarage> m_VehiclesInTheGarage = null;
        private StringBuilder m_StringBuilder = null;

        public Dictionary<string, VehiclesInTheGarage> VehiclesInTheGarage
        {
            get
            {
                return m_VehiclesInTheGarage;
            }
        }

        public Garage()
        {
            m_VehiclesInTheGarage = new Dictionary<string, VehiclesInTheGarage>();
            m_StringBuilder = new StringBuilder();
        }

        public void InsertVehicleToTheGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            VehicleOwner owner = new VehicleOwner(i_OwnerName, i_OwnerPhoneNumber);
            m_VehiclesInTheGarage.Add(i_Vehicle.LicenseNumber, new VehiclesInTheGarage(owner, i_Vehicle));
        }

        public bool IsCarInTheGarage(string i_LicenseNumber)
        {
            return m_VehiclesInTheGarage.ContainsKey(i_LicenseNumber);
        }

        public string ShowLicenseNumbers(bool i_FilterByCarStatus, Vehicle.eStatusOfVehicle i_VehicleStatus)
        {
            m_StringBuilder.Remove(0, m_StringBuilder.Length);
            foreach (KeyValuePair<string, VehiclesInTheGarage> currentVehicleInTheGarage in m_VehiclesInTheGarage)
            {
                if (i_FilterByCarStatus)
                {
                    if (currentVehicleInTheGarage.Value.VehicleStatus == i_VehicleStatus)
                    {
                        m_StringBuilder.AppendLine(currentVehicleInTheGarage.Value.Vehicle.LicenseNumber);
                    }
                }
                else
                {
                    m_StringBuilder.AppendLine(currentVehicleInTheGarage.Value.Vehicle.LicenseNumber);
                }
            }

            return m_StringBuilder.ToString();
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, Vehicle.eStatusOfVehicle i_NewVehicleStatus)
        {
            VehiclesInTheGarage currentVehicleInTheGarage = null;

            if (m_VehiclesInTheGarage.TryGetValue(i_LicenseNumber, out currentVehicleInTheGarage))
            {
                currentVehicleInTheGarage.VehicleStatus = i_NewVehicleStatus;
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage.");
            }
        }

        public void InflateWheelsToMaxPressure(string i_LicenseNumber)
        {
            VehiclesInTheGarage currentVehicleInTheGarage = null;
            if (m_VehiclesInTheGarage.TryGetValue(i_LicenseNumber, out currentVehicleInTheGarage))
            {
                currentVehicleInTheGarage.Vehicle.InflateToMax();
            }
            else
            {
                throw new ArgumentException("There was an error, please try again.");
            }
        }
       
        public void VehicleGasRefule(string i_LicenseNumber, Vehicle.eGasTypes i_GasType, float i_GasAmount)
        {
            VehiclesInTheGarage currentVehicleInTheGarage = null;
            if (m_VehiclesInTheGarage.TryGetValue(i_LicenseNumber, out currentVehicleInTheGarage))
            {
                GasEngine gasVehicle = currentVehicleInTheGarage.Vehicle.Engine as GasEngine;

                if (gasVehicle != null)
                {
                    gasVehicle.Refuel(i_GasAmount, i_GasType);
                }
                else
                {
                    throw new ArgumentException("This vehicle needs a different fuel type.");
                }
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage.");
            }
        }

        public void VehicleElectricCharge(string i_LicenseNumber, float i_AmountInMinutes)
        {
            VehiclesInTheGarage vehicleEntered = null;
            if (m_VehiclesInTheGarage.TryGetValue(i_LicenseNumber, out vehicleEntered))
            {
                ElectricEngine electricVehicle = vehicleEntered.Vehicle.Engine as ElectricEngine;
                if (electricVehicle != null)
                {
                    float power = i_AmountInMinutes / 60.0f;
                    electricVehicle.ChargingBattery(power);
                }
                else
                {
                    throw new ArgumentException("The vehicle is not in the garage.");
                }
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage.");
            }
        }

        public string GetAllVehicleDetails(string i_LicenseNumber)
        {
            VehiclesInTheGarage vehicleEntered = null;
            string resultStr = null;
            if (m_VehiclesInTheGarage.TryGetValue(i_LicenseNumber, out vehicleEntered))
            {
                resultStr = vehicleEntered.ToString();
            }
            else
            {
                throw new ArgumentException("The vehicle is not in the garage.");
            }

            return resultStr;
        }
    }
}
