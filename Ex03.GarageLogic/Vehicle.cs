using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string m_Model;
        public string m_LicenseNumber;
        public float m_EnergyLeft;
        public List<Wheel> m_Wheels;
        public Engine m_Engine;

        public enum eVehicleTypes
        {
            GasCar = 1,
            ElectricCar = 2,
            GasMotorcycle = 3,
            ElectricMotorcycle = 4,
            Truck = 5
        }

        public enum eStatusOfVehicle
        {
            InRepair = 1,
            Repaired = 2,
            Payed = 3
        }

        public enum eGasTypes
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        public enum eLicenseTypes
        {
            A = 1,
            AB = 2,
            A2 = 3,
            B1 = 4
        }

        public enum eCarColors
        {
            Yellow = 1,
            White = 2,
            Black = 3,
            Blue = 4
        }

        public enum eCarDoorsAmount
        {
            TwoDoors = 1,
            ThreeDoors = 2,
            FourDoors = 3,
            FiveDoors = 4
        }

        public string Model
        {
            get
            {
                return this.m_Model;
            }

            set
            {
                this.m_Model = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }

            set
            {
                this.m_LicenseNumber = value;
            }
        }

        public float EnergyLeft
        {
            get
            {
                return this.m_EnergyLeft;
            }

            set
            {
                this.m_EnergyLeft = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }

            set
            {
                this.m_Wheels = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.m_Engine;
            }

            set
            {
                this.m_Engine = value;
            }
        }

        public virtual void InflateToMax()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicle details: ");
            if (!string.IsNullOrEmpty(m_Model))
            {
                sb.AppendFormat("Model: {0}\n", m_Model);
            }

            if (!string.IsNullOrEmpty(this.LicenseNumber))
            {
                sb.AppendFormat("License number: {0}\n", this.LicenseNumber);
            }

            sb.AppendFormat("Current energy: {0}\n", m_EnergyLeft);
            for (int i = 0; i < Wheels.Count; ++i)
            {
                sb.AppendFormat("Wheel Num. {0}:\n", i + 1);
                sb.AppendLine(Wheels[i].ToString());
            }

            sb.AppendLine(Engine.ToString());
            return sb.ToString();
        }
    }
}