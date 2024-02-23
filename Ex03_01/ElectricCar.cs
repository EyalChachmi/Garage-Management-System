using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class ElectricCar:Car
    {
        private Battery m_Battery;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, eCarColor i_Color, eCarDoor i_NumberOfDoors, Battery i_Battery) : base(i_ModelName, i_LicenseNumber, i_Color, i_NumberOfDoors)
        {
            this.m_Battery = i_Battery;
            m_Battery.MaxBatteryTime = 4.8f;
            for (int i = 0; i < 5; i++)
            {
                m_Tires.Add(new Tire(30));
            }
            m_EnergyPrecent = (m_Battery.RemainingBatteryTime / m_Battery.MaxBatteryTime) * 100;
        }
        public void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, string i_VehicleCondition, eCarColor i_CarColor, eCarDoor i_NumberOfDoors, float i_RemainingBattaryLife)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_CarColor = i_CarColor;
            this.m_CarDoor = i_NumberOfDoors;
            m_Battery = new Battery(i_RemainingBattaryLife);
        }

    }

}
