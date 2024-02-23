using Ex03_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.ConsoleUI
{
    public class GarageUIHandler
    {
        private Garage m_Garage;

        public GarageUIHandler(Garage i_Garage)
        {
            this.m_Garage= i_Garage;
        }

        public void AddVehicleToGarage()
        {
            string licenseNumber;
            string vehicleType;

            licenseNumber = Console.ReadLine();
            if (m_Garage.CheckIfVehicleExists(licenseNumber))
            {
                Console.WriteLine("Vehicle already exists in the garage. Changing its condition to in Repair....");
                m_Garage.ChangeVehicleCondition(licenseNumber, "In Repair");
            }
            else
            {
                Console.WriteLine("Vehicle doesn't exist in the garage, Please enter your vehicle type that you interested in :)");
                vehicleType = Console.ReadLine();

                Vehicle vehicle =VehicleFactory.CreateVehicle(licenseNumber, vehicleType);

                Console.WriteLine("Please enter the owner name of this vehicle");
                string ownerName = Console.ReadLine();

                Console.WriteLine("Please enter the owner's phone number");
                string ownerPhone= Console.ReadLine();

                //private string m_ManufacturerName;
                // private float m_CurrentAirPressure;
        Console.WriteLine("Please enter the ");

                if(vehicle is Car)
                {
                    Console.WriteLine("Please enter the model name:");
                    string modelName = Console.ReadLine();
                    Console.WriteLine("Please enter the car color! Select and type only of this following colors: (White,Blue,Red,Yellow)");
                    eCarColor eCarColor;

                    string colorString = Console.ReadLine();

                    try
                    {
                        eCarColor = (eCarColor)Enum.Parse(typeof(eCarColor), colorString);
                    }
                    catch (ArgumentException)
                    {
                        throw new FormatException("Invalid color value: " + colorString);
                    }
                    Console.WriteLine("Please enter the car doors number! Select and type only of this following numbers: (2,3,4,5)");
                    eCarDoor eCarDoor;

                    string numOfCarDoorsString = Console.ReadLine();

                    try
                    {
                        eCarDoor = (eCarDoor)Enum.Parse(typeof(eCarDoor), numOfCarDoorsString);
                    }
                    catch (ArgumentException)
                    {
                        throw new FormatException("Invalid door numbers value: " + numOfCarDoorsString);
                    }
                    if (vehicle is ElectricCar)
                    {

                        ElectricCar electricCar = vehicle as ElectricCar;

                        Console.WriteLine("Please enter the remaining battery life:");
                        string batteryLifeInput = Console.ReadLine();
                        float batteryLife;

                        if (!float.TryParse(batteryLifeInput, out batteryLife))
                        {
                            throw new FormatException("Invalid input for battery life: " + batteryLifeInput);
                        }

                        electricCar.UpdateVehicleDetails(ownerName, ownerPhone, electricCar.VehicleCondition, eCarColor, eCarDoor, batteryLife);
                    }
                    else
                    {
                        NormalCar normalCar = vehicle as NormalCar;
                        Console.WriteLine("Please enter the amount of the remaining fuel:");
                        string remainingFuelInput = Console.ReadLine();
                        float remainingFuel;

                        if(!float.TryParse(remainingFuelInput, out remainingFuel))
                        {
                            throw new FormatException("Invalid input for amount of remaining fuel: " + remainingFuelInput);
                        }

                        normalCar.UpdateVehicleDetails(ownerName, ownerPhone, normalCar.VehicleCondition, eCarColor, eCarDoor, remainingFuel);
                    }
                }

                else if(vehicle is Motorcycle)
                {
                    Console.WriteLine("Please enter the Engine Capacity:");
                    string engineCapacityInput = Console.ReadLine();
                    int engineCapacity;

                    if (!int.TryParse((engineCapacityInput), out engineCapacity))
                    {
                        throw new FormatException("Invalid input for engine capacity: " + engineCapacityInput);
                    }

                    Console.WriteLine("Please enter the motorcycle's licence type, select and type only of this following colors: (A1, A2, AB, B2)");
                    eLicense eLicenseType;

                    string licenseType = Console.ReadLine();

                    try
                    {
                        eLicenseType = (eLicense)Enum.Parse(typeof(eLicense), licenseType);
                    }
                    catch (ArgumentException)
                    {
                        throw new FormatException("Invalid license type: " + licenseType);
                    }

                    if (vehicle is ElectricMotorcycle)
                    {
                        ElectricMotorcycle electricMotorcycle = vehicle as ElectricMotorcycle;

                        Console.WriteLine("Please enter the remaining battery life:");
                        string batteryLifeInput = Console.ReadLine();
                        float batteryLife;

                        if (!float.TryParse(batteryLifeInput, out batteryLife))
                        {
                            throw new FormatException("Invalid input for battery life: " + batteryLifeInput);
                        }
                        electricMotorcycle.UpdateVehicleDetails(ownerName, ownerPhone, electricMotorcycle.VehicleCondition, engineCapacity, eLicenseType, batteryLife);
                    }
                    else
                    {
                        NormalMotorcycle normalMotorcycle = vehicle as NormalMotorcycle;
                        Console.WriteLine("Please enter the amount of the remaining fuel:");
                        string remainingFuelInput = Console.ReadLine();
                        float remainingFuel;

                        if (!float.TryParse(remainingFuelInput, out remainingFuel))
                        {
                            throw new FormatException("Invalid input for amount of remaining fuel: " + remainingFuelInput);
                        }
                        normalMotorcycle.UpdateVehicleDetails(ownerName, ownerPhone, normalMotorcycle.VehicleCondition, engineCapacity, eLicenseType, remainingFuel);
                    }
                }

                else if(vehicle is Truck)
                {
                    Truck truck = vehicle as Truck;
                    Console.WriteLine("Does the truck transporting hazardous materials?: choose only between (True / False)");
                    string isTransportingHazardousMaterialsInput = Console.ReadLine();
                    bool isTransportingHazardousMaterials;

                    if (!bool.TryParse(isTransportingHazardousMaterialsInput, out isTransportingHazardousMaterials))
                    {
                        throw new FormatException("Invalid input for battery life: " + isTransportingHazardousMaterialsInput);
                    }

                    Console.WriteLine("Please enter the amount of cargo in kg");
                    string CargoVolumeInput = Console.ReadLine();
                    int CargoVolume;

                    if (!int.TryParse((CargoVolumeInput), out CargoVolume))
                    {
                        throw new FormatException("Invalid input for cargo volume: " + CargoVolumeInput);
                    }

                    Console.WriteLine("Please enter the amount of the remaining fuel:");
                    string remainingFuelInput = Console.ReadLine();
                    float remainingFuel;

                    if (!float.TryParse(remainingFuelInput, out remainingFuel))
                    {
                        throw new FormatException("Invalid input for amount of remaining fuel: " + remainingFuelInput);
                    }
                    truck.UpdateVehicleDetails(ownerName, ownerPhone, truck.VehicleCondition, isTransportingHazardousMaterials, CargoVolume, remainingFuel);
                }
            }
        }
    }
}
