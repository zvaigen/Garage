using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehiclesInTheGarage
    {
        public Vehicle m_Vehicle;
        public VehicleOwner m_VehicleOwner;
        public Vehicle.eStatusOfVehicle m_VehicleStatus;

        public VehiclesInTheGarage(VehicleOwner i_VehicleOwner, Vehicle i_Vehicle)
        {
            m_VehicleOwner = i_VehicleOwner;
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = Vehicle.eStatusOfVehicle.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public VehicleOwner VehicleOwner
        {
            get
            {
                return m_VehicleOwner;
            }

            set
            {
                m_VehicleOwner = value;
            }
        }

        public Vehicle.eStatusOfVehicle VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("These are all the details of the wanted vehicle: ");
            sb.AppendLine(m_VehicleOwner.ToString());
            sb.AppendFormat("Car condition: {0}\n", Enum.GetName(typeof(Vehicle.eStatusOfVehicle), VehicleStatus));
            sb.AppendFormat(Vehicle.ToString());
            return sb.ToString();
        }
    }
}
