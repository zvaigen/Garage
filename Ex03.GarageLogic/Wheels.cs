using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string m_ManufacturerName;
        public float m_CurrentAirPressure;
        public float m_MaximumAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaximumAirPressure = i_MaximumAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            private set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            private set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return m_MaximumAirPressure;
            }

            private set
            {
                m_MaximumAirPressure = value;
            }
        }

        public void InflatingAir(float i_AddAir)
        {
            if (i_AddAir + m_CurrentAirPressure <= m_MaximumAirPressure)
            {
                m_CurrentAirPressure += i_AddAir;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaximumAirPressure);
            }
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = this.m_MaximumAirPressure;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Wheel details: ");
            sb.AppendFormat("Manufacturer name: {0}\n", this.m_ManufacturerName);
            sb.AppendFormat("Current air pressure: {0}\n", this.m_CurrentAirPressure);
            sb.AppendFormat("Maximum air pressure: {0}\n", this.m_MaximumAirPressure);
            return sb.ToString();
        }
    }
}