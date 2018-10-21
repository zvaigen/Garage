using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        public GasMotorcycle(eLicenseTypes i_MotorcycleType, int i_EngineCapacity)
            : base(i_MotorcycleType, i_EngineCapacity)
        {
        }
    }
}
