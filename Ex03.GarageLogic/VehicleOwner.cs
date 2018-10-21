using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        public string m_OwnerName;
        public string m_OwnerPhoneNumber;

        public VehicleOwner(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        public string OwnerName
        {
            get
            {
                return this.m_OwnerName;
            }

            protected set
            {
                this.m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return this.m_OwnerPhoneNumber;
            }

            protected set
            {
                this.m_OwnerPhoneNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Owner details: \n");
            sb.AppendFormat("Name: {0}\n", m_OwnerName);
            sb.AppendFormat("Phone number: {0}\n", this.m_OwnerPhoneNumber);
            return sb.ToString();
        }
    }
}
