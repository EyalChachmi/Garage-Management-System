using System.Collections.Generic;

namespace Ex03_01
{
    public abstract class Motorcycle : Vehicle
    {
        protected int m_EngineCapacity;

        protected eLicense m_LicenseType;
        
        public eLicense LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        protected Motorcycle(string i_ModelName, string i_LicenseNumber, int i_EngineCapacity, eLicense i_LicenseType) : base(i_ModelName, i_LicenseNumber)
        {
            this.m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
        }
        protected void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition, int i_EngineCapacity, eLicense i_LicenseType)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_EngineCapacity = i_EngineCapacity;
            m_LicenseType = i_LicenseType;
        }

    }
}
