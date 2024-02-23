using System.Collections.Generic;

namespace Ex03_01
{
    public abstract class Vehicle
    {
        protected string m_OwnerName;
        protected string m_OwnerNumber;
        protected string m_VehicleCondition;
        protected List<Tire> m_Tires;
        protected float m_EnergyPrecent;
        private string m_ModelName;
        private string m_LicenseNumber;

        public string OwnerName
        {
            get;
            set;
        }

        public string OwnerNumber
        {
            get;
            set;
        }

        public string VehicleCondition
        {
            get;
            set;
        }

        public float EnergyPercent
        {
            get
            {
                return m_EnergyPrecent;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        protected void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerNumber = i_OwnerNumber;
            VehicleCondition = i_VehicleCondition;
        }
        protected Vehicle(string i_ModelName, string i_LicenseNumber)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Tires = new List<Tire>();
        }
        public void UpdateTireSpecification(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Tire t in m_Tires)
            {
                t.CurrentAirPressure= i_CurrentAirPressure;
                t.ManufacturerName= i_ManufacturerName;
            }
        }
    }
}
