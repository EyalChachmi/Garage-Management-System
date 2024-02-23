using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class NormalCar:Car
    {
        private Fuel m_Fuel;
        public NormalCar(string i_ModelName, string i_LicenseNumber, eCarColor i_Color, eCarDoor i_NumberOfDoors, Fuel i_Fuel) : base(i_ModelName, i_LicenseNumber, i_Color, i_NumberOfDoors)
        {
            this.m_Fuel = i_Fuel;
            m_Fuel.MaxFuelQuantity = 58f;
            m_Fuel.FuelType = eFuelType.Octan95;
            for (int i = 0; i < 5; i++)
            {
                m_Tires.Add(new Tire(30));
            }
            this.m_EnergyPrecent = (m_Fuel.CurrentFuelQuantity / m_Fuel.MaxFuelQuantity) * 100;
        }
        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition, eCarColor i_CarColor, eCarDoor i_NumberOfDoors, float i_CurrentFuel)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_CarColor= i_CarColor;
            this.m_CarDoor = i_NumberOfDoors;
            m_Fuel = new Fuel(i_CurrentFuel);
        }

    }
}
