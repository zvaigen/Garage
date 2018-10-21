using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public eLicenseTypes m_MotorcycleType;
        public int m_EngineCapacity;

        public Motorcycle(eLicenseTypes i_MotorcycleType, int i_EngineCapacity)
        {
            m_MotorcycleType = i_MotorcycleType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public eLicenseTypes MotorcycleType
        {
            get
            {
                return this.m_MotorcycleType;
            }

            protected set
            {
                this.m_MotorcycleType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }

            protected set
            {
                this.m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendFormat("Motorcycle type: {0}\n", m_MotorcycleType);
            sb.AppendFormat("Engine capacity: {0}\n", m_EngineCapacity);
            return sb.ToString();
        }
    }
}
