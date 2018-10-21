using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(eLicenseTypes i_MotorcycleType, int i_EngineCapacity)
            : base(i_MotorcycleType, i_EngineCapacity)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
