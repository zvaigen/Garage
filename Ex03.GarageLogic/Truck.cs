using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public bool m_IsCarryingDangerousMaterials;
        public float m_MaximumCarryingWeight;

        public Truck(bool i_IsCarryingDangerousMaterials, float i_MaximumCarryingWeight)
        {
            m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            m_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return this.m_IsCarryingDangerousMaterials;
            }

            protected set
            {
                this.m_IsCarryingDangerousMaterials = value;
            }
        }

        public float MaximumCarryingWeight
        {
            get
            {
                return this.m_MaximumCarryingWeight;
            }

            protected set
            {
                this.m_MaximumCarryingWeight = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine("Truck Details:");
            sb.AppendFormat("Is carrying dangerous materials: {0}\n", IsCarryingDangerousMaterials);
            sb.AppendFormat("Max carrying weight: {0}\n", m_MaximumCarryingWeight);
            return sb.ToString();
        }
    }
}
