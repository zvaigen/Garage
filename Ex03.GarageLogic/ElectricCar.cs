using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public ElectricCar(eCarColors i_CarColor, eCarDoorsAmount i_CarDoors)
            : base(i_CarColor, i_CarDoors)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
