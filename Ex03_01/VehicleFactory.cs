using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class VehicleFactory
    {
        public static string[] AvaliableVehicles = { "ElectricCar", "NormalCar", "ElectricMotorcycle", "NormalMotorcycle", "Truck" };
        public static Vehicle CreateVehicle(string i_LicenseNumber, string i_VehicleType)
        {
            Vehicle vehicle;

            switch (i_VehicleType)
            {
                case "ElectricCar":
                    vehicle = new ElectricCar("", i_LicenseNumber, eCarColor.Red, eCarDoor.twoDoors, new Battery(0));
                    break;
                case "NormalCar":
                    vehicle = new NormalCar("", i_LicenseNumber, eCarColor.Red, eCarDoor.twoDoors, new Fuel(0));
                    break;
                case "ElectricMotorcycle":
                    vehicle = new ElectricMotorcycle("", i_LicenseNumber, 0, eLicense.A1, new Battery(0));
                    break;
                case "NormalMotorcycle":
                    vehicle = new NormalMotorcycle("", i_LicenseNumber, 0, eLicense.A1, new Fuel(0));
                    break;
                case "Truck":
                    vehicle = new Truck("", i_LicenseNumber, false, 0f, new Fuel(0));
                    break;
                default:
                    throw new Exception("Invalid vehicle type.");
            }

            return vehicle;
        }

        public static void UpdateVehicle(Garage i_Garage, Vehicle i_Vehicle, List<string> i_UserResponses)
        {
            string ownerName = i_UserResponses[0];
            string ownerPhone = i_UserResponses[1];
            string tireManufacturerName = i_UserResponses[2];
            string currentAirPressureInput = i_UserResponses[3];
            float currentAirPressure;

            if (!float.TryParse(currentAirPressureInput, out currentAirPressure))
            {
                throw new FormatException("Invalid input for battery life: " + currentAirPressureInput);
            }

            string modelName = i_UserResponses[4];

            i_Vehicle.UpdateTireSpecification(tireManufacturerName, currentAirPressure);
            if (i_Vehicle is Car)
            {
                eCarColor[] avaliableCarColorsArray = (eCarColor[])Enum.GetValues(typeof(eCarColor));
                string usersCarColorNumberResponseInput = i_UserResponses[5];
                int usersCarColorNumberResponse;

                if (!int.TryParse(usersCarColorNumberResponseInput, out usersCarColorNumberResponse))
                {
                    throw new FormatException("Invalid input for car color type " + usersCarColorNumberResponseInput);
                }

                eCarColor eCarColor = avaliableCarColorsArray[usersCarColorNumberResponse];
                eCarDoor[] avaliableNumOfCarDoorsArray = (eCarDoor[])Enum.GetValues(typeof(eCarDoor));
                string usersNumOfCarDoorsNumberResponseInput = i_UserResponses[6];
                int usersNumOfCarDoorsNumberResponse;

                if (!int.TryParse(usersNumOfCarDoorsNumberResponseInput, out usersNumOfCarDoorsNumberResponse))
                {
                    throw new FormatException("Invalid door numbers value: " + usersNumOfCarDoorsNumberResponseInput);
                }

                eCarDoor eCarDoor = avaliableNumOfCarDoorsArray[usersNumOfCarDoorsNumberResponse - 2];

                if (i_Vehicle is ElectricCar)
                {
                    string batteryLifeInput = i_UserResponses[7];
                    float batteryLife;

                    if (!float.TryParse(batteryLifeInput, out batteryLife))
                    {
                        throw new FormatException("Invalid input for battery life: " + batteryLifeInput);
                    }

                    ElectricCar electricCar = i_Vehicle as ElectricCar;

                    electricCar.UpdateVehicleDetails(ownerName, ownerPhone, electricCar.VehicleCondition, modelName, eCarColor, eCarDoor, batteryLife);
                }

                if (i_Vehicle is NormalCar)
                {
                    string remainingFuelInput = i_UserResponses[7];
                    float remainingFuel;

                    if (!float.TryParse(remainingFuelInput, out remainingFuel))
                    {
                        throw new FormatException("Invalid input for amount of remaining fuel: " + remainingFuelInput);
                    }

                    NormalCar normalCar = i_Vehicle as NormalCar;

                    normalCar.UpdateVehicleDetails(ownerName, ownerPhone, normalCar.VehicleCondition, modelName, eCarColor, eCarDoor, remainingFuel);
                }
            }
            else if (i_Vehicle is Motorcycle)
            {
                string engineCapacityInput = i_UserResponses[5];
                int engineCapacity;

                if (!int.TryParse((engineCapacityInput), out engineCapacity))
                {
                    throw new FormatException("Invalid input for engine capacity: " + engineCapacityInput);
                }

                eLicense[] avaliableLicenseTypeArray = (eLicense[])Enum.GetValues(typeof(eLicense));
                string usersLicenseTypeNumberResponseInput = i_UserResponses[6];
                int usersLicenseTypeNumberResponse;

                if (!int.TryParse(usersLicenseTypeNumberResponseInput, out usersLicenseTypeNumberResponse))
                {
                    throw new FormatException("Invalid input for license type" + usersLicenseTypeNumberResponseInput);
                }

                eLicense eLicenseType = avaliableLicenseTypeArray[usersLicenseTypeNumberResponse];

                if (i_Vehicle is ElectricMotorcycle)
                {
                    string batteryLifeInput = i_UserResponses[7];
                    float batteryLife;

                    if (!float.TryParse(batteryLifeInput, out batteryLife))
                    {
                        throw new FormatException("Invalid input for battery life: " + batteryLifeInput);
                    }

                    ElectricMotorcycle electricMotorcycle = i_Vehicle as ElectricMotorcycle;

                    electricMotorcycle.UpdateVehicleDetails(ownerName, ownerPhone, electricMotorcycle.VehicleCondition, modelName, engineCapacity, eLicenseType, batteryLife);
                }

                if (i_Vehicle is NormalMotorcycle)
                {
                    string remainingFuelInput = i_UserResponses[7];
                    float remainingFuel;

                    if (!float.TryParse(remainingFuelInput, out remainingFuel))
                    {
                        throw new FormatException("Invalid input for amount of remaining fuel: " + remainingFuelInput);
                    }

                    NormalMotorcycle normalMotorcycle = i_Vehicle as NormalMotorcycle;

                    normalMotorcycle.UpdateVehicleDetails(ownerName, ownerPhone, normalMotorcycle.VehicleCondition, modelName, engineCapacity, eLicenseType, remainingFuel);
                }
            }
            else if (i_Vehicle is Truck)
            {
                string isTransportingHazardousMaterialsInput = i_UserResponses[5];
                bool isTransportingHazardousMaterials;

                if (!bool.TryParse(isTransportingHazardousMaterialsInput, out isTransportingHazardousMaterials))
                {
                    throw new FormatException("Invalid input for hazardous materials: " + isTransportingHazardousMaterialsInput);
                }

                string cargoVolumeInput = i_UserResponses[6];
                int cargoVolume;

                if (!int.TryParse((cargoVolumeInput), out cargoVolume))
                {
                    throw new FormatException("Invalid input for cargo volume: " + cargoVolumeInput);
                }

                string remainingFuelInput = i_UserResponses[7];
                float remainingFuel;

                if (!float.TryParse(remainingFuelInput, out remainingFuel))
                {
                    throw new FormatException("Invalid input for amount of remaining fuel: " + remainingFuelInput);
                }

                Truck truck = i_Vehicle as Truck;

                truck.UpdateVehicleDetails(ownerName, ownerPhone, truck.VehicleCondition, modelName, isTransportingHazardousMaterials, cargoVolume, remainingFuel);
            }
            else
            {
                throw new Exception("Invalid vehicle type.");
            }

            i_Garage.AddVehicle(i_Vehicle);
        }
    }
}
