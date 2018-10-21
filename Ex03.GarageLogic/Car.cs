using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public eCarColors m_CarColor;
        public eCarDoorsAmount m_CarDoors;

        public Car(eCarColors i_CarColor, eCarDoorsAmount i_CarDoors)
        {
            m_CarColor = i_CarColor;
            m_CarDoors = i_CarDoors;
        }

        public eCarColors CarColor
        {
            get
            {
                return this.m_CarColor;
            }

            protected set
            {
                this.m_CarColor = value;
            }
        }

        public eCarDoorsAmount CarDoors
        {
            get
            {
                return this.m_CarDoors;
            }

            protected set
            {
                this.m_CarDoors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Car details: ");
            sb.AppendFormat("Color: {0}\n", Enum.GetName(typeof(eCarColors), m_CarColor));
            sb.AppendFormat("Doors: {0}\n", Enum.GetName(typeof(eCarDoorsAmount), m_CarDoors));
            return sb.ToString() + base.ToString();
        }
    }
}
