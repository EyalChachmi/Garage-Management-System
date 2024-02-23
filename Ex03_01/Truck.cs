using System.Collections.Generic;

namespace Ex03_01
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportingHazardousMaterials;
        private float m_CargoVolume;
        private Fuel m_Fuel;

        public Truck(string i_ModelName, string i_LicenseNumber, bool i_IsTransportingHazardousMaterials, float i_CargoVolume,Fuel i_Fuel) : base(i_ModelName, i_LicenseNumber)
        {
            this.m_Fuel = i_Fuel;
            this.m_IsTransportingHazardousMaterials = i_IsTransportingHazardousMaterials;
            this.m_CargoVolume = i_CargoVolume;
            m_Fuel.MaxFuelQuantity = 110f;
            m_Fuel.FuelType = eFuelType.Soler;
            for (int i = 0; i < 12; i++)
            {
                m_Tires.Add(new Tire(28));
            }
            m_EnergyPrecent = (m_Fuel.CurrentFuelQuantity / m_Fuel.MaxFuelQuantity) * 100;
        }
        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition, bool i_IsCarryingHazardousMaterials, float i_CargoVolume,float i_CurrentFuel)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_IsTransportingHazardousMaterials = i_IsCarryingHazardousMaterials;
            this.m_CargoVolume = i_CargoVolume;
            this.m_Fuel = new Fuel(i_CurrentFuel);
        }

    }
}
