using System.Collections.Generic;
using System.Text;

namespace Ex03_01
{
    public abstract class Vehicle
    {
        protected string m_OwnerName;
        protected string m_OwnerNumber;
        protected eVehicleCondition m_VehicleCondition;
        protected List<Tire> m_Tires;
        protected float m_EnergyPrecent;
        private string m_ModelName;
        private string m_LicenseNumber;
        public EnergyType VehicleEnergyType
        {
            get;
            set;
        }

        public eVehicleCondition VehicleCondition
        {
            get
            {
                return m_VehicleCondition;
            }
            set
            {
                m_VehicleCondition = value;
            }
        }

        public float EnergyPercent
        {
            get
            {
                return m_EnergyPrecent;
            }
            set
            {
                m_EnergyPrecent= value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        protected void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, eVehicleCondition i_VehicleCondition,string i_ModelName)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerNumber = i_OwnerNumber;
            VehicleCondition = i_VehicleCondition;
            m_ModelName = i_ModelName;
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
                if (i_CurrentAirPressure <= t.MaximumAirPressure && i_CurrentAirPressure >= 0)
                {
                    t.CurrentAirPressure = i_CurrentAirPressure;
                    t.ManufacturerName = i_ManufacturerName;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, t.MaximumAirPressure - i_CurrentAirPressure);
                }
            }
        }

        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public void TireInflationToMaximumForEachTire()
        {
            foreach (Tire tire in m_Tires)
            {
                tire.TireInflationToMaximum();
            }
        }

        public override string ToString()
        {
            int tireCount = 1;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format($"License number: {m_LicenseNumber}, Model name is: {m_ModelName}"));
            stringBuilder.AppendLine(string.Format($"Owner name is: {m_OwnerName}, Owner's phone number is: {m_OwnerNumber}"));
            stringBuilder.AppendLine(string.Format($"The vehicle is currently: {m_VehicleCondition} and its Energy Percentage is: {m_EnergyPrecent} %"));
            foreach (Tire tire in m_Tires)
            {
                stringBuilder.AppendLine(string.Format($"Tire number {tireCount++} " + tire.ToString()));
            }

            return stringBuilder.ToString();
        }
    }
}
