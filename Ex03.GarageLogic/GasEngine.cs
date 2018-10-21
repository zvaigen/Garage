using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        public Vehicle.eGasTypes m_GasType;
        public float m_CurrentGasAmount;
        public float m_MaximumGasAmount;

        public GasEngine(Vehicle.eGasTypes i_GasType, float i_CurrentGasAmount, float i_MaximumGasAmount)
        {
            float currEnergy = i_CurrentGasAmount;
            if (currEnergy > i_MaximumGasAmount || currEnergy < 0)
            {
                throw new ArgumentException(string.Format("Wheel's air pressure must be between {0} to {1}", 0, i_MaximumGasAmount));
            }
            else
            {
                this.m_CurrentGasAmount = currEnergy;
            }

            this.GasType = i_GasType;
            this.m_MaximumGasAmount = i_MaximumGasAmount;
        }

        public Vehicle.eGasTypes GasType
        {
            get
            {
                return this.m_GasType;
            }

            protected set
            {
                this.m_GasType = value;
            }
        }

        public float CrrentGasAmount
        {
            get
            {
                return this.m_CurrentGasAmount;
            }

            protected set
            {
                this.m_CurrentGasAmount = value;
            }
        }

        public float MaximumGasAmount
        {
            get
            {
                return this.m_MaximumGasAmount;
            }

            protected set
            {
                this.m_MaximumGasAmount = value;
            }
        }

        public void Refuel(float i_AddGas, Vehicle.eGasTypes i_GasType)
        {
            if (i_AddGas + m_CurrentGasAmount <= m_MaximumGasAmount && m_GasType == i_GasType)
            {
                m_CurrentGasAmount += i_AddGas;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaximumGasAmount);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendFormat("Gas type: {0}\n", Enum.GetName(typeof(Vehicle.eGasTypes), GasType));
            sb.AppendFormat("Current gas amount: {0}\n", m_CurrentGasAmount);
            sb.AppendFormat("Max gas amount: {0}\n", m_MaximumGasAmount);
            return sb.ToString();
        }
    }
}
