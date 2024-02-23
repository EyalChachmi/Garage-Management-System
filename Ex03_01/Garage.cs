using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class Garage
    {
        private List<Vehicle> m_Vehicles;
        public Garage()
        {
            m_Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle i_Vehicle)
        {
            m_Vehicles.Add(i_Vehicle);
        }
        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool vehicleExists = false;
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicleExists = true;
                }
            }
            return vehicleExists;
        }

        public void ChangeVehicleCondition(string i_LicenseNumber, string i_NewCondition)
        {
            foreach (Vehicle vehicle in m_Vehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicle.VehicleCondition = i_NewCondition;
                    return;
                }
            }
        }
    }
}
