using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(string i_LicenseNumber, string i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case "ElectricCar":
                    return new ElectricCar("", i_LicenseNumber, eCarColor.noColor, eCarDoor.noDoors, null);
                case "NormalCar":
                    return new NormalCar("", i_LicenseNumber, eCarColor.noColor, eCarDoor.noDoors, null);
                case "ElectricMotorcycle":
                    return new ElectricMotorcycle("", i_LicenseNumber, 0, eLicense.noLicense, null);
                case "NormalMotorcycle":
                    return new NormalMotorcycle("", i_LicenseNumber, 0, eLicense.noLicense, null);
                case "Truck":
                    return new Truck("", i_LicenseNumber, false, 0f, null);
                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
        }
    }
}
