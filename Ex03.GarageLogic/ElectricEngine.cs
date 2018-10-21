using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public float m_CurrentBatteryPower;
        public float m_MaximumBatteryPower;

        public ElectricEngine(float i_CurrentBatteryPower, float i_MaximumBatteryPower)
        {
            if (i_CurrentBatteryPower > i_MaximumBatteryPower || i_CurrentBatteryPower < 0)
            {
                throw new ArgumentException(string.Format("Wheel's air pressure must be between {0} to {1}", 0, i_MaximumBatteryPower));
            }
            else
            {
                m_CurrentBatteryPower = i_CurrentBatteryPower;
            }

            m_MaximumBatteryPower = i_MaximumBatteryPower;
        }

        public float CurrentBatteryPower
        {
            get
            {
                return m_CurrentBatteryPower;
            }

            protected set
            {
                m_CurrentBatteryPower = value;
            }
        }

        public float MaximumBatteryPower
        {
            get
            {
                return m_MaximumBatteryPower;
            }

            protected set
            {
                m_MaximumBatteryPower = value;
            }
        }

        public void ChargingBattery(float i_AddHours)
        {
            if (i_AddHours + m_CurrentBatteryPower <= m_MaximumBatteryPower)
            {
                m_CurrentBatteryPower += i_AddHours;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaximumBatteryPower);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Current battery power (hours): {0}\n", m_CurrentBatteryPower);
            sb.AppendFormat("Max battery power (hours): {0}\n", m_MaximumBatteryPower);
            return sb.ToString();
        }
    }
}
