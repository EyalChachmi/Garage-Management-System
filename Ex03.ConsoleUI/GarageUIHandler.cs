using Ex03_01;
using System;
using System.Collections.Generic;
using System.IO;


namespace Ex03.ConsoleUI
{
    public class GarageUIHandler
    {
        private Garage m_Garage;

        public GarageUIHandler()
        {
            m_Garage = new Garage();
        }

        public void TableOfContents()
        {
            bool isRunning = true;

            Console.WriteLine("Welcome to our Garage!");
            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("To add a vehicle to our garage please type: 1");
                Console.WriteLine("To provide a list of all the vehicles by license number please type: 2");
                Console.WriteLine("To change a vehicle's status please type: 3");
                Console.WriteLine("To inflate the tires to the maximum please type: 4");
                Console.WriteLine("To refuel a vehicle that is fueled by fuel please type: 5");
                Console.WriteLine("To charge an electric vehicle please type: 6");
                Console.WriteLine("To display complete vehicle data by license number please type: 7");
                Console.WriteLine("To Exit the Garage, Please type: 8");
                string usersCommand = Console.ReadLine();

                Console.Clear();
                switch (usersCommand)
                {
                    case "1":
                        AddVehicleToGarage();
                        break;
                    case "2":
                        try
                        {
                            GetAllLicensesInGarage();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            ChangeVehicleCondition();
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "4":
                        InflateTiresByLicenseNumber();
                        break;
                    case "5":
                        try
                        {
                            FuelAVehicle();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "6":
                        try
                        {
                            ChargeVehicle();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "7":
                        try
                        {
                            RevealFullDetailsAboutVehicleBasedOnLicenseNumber();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "8":
                        isRunning = false;
                        Console.WriteLine("Goodbye for now! Please come again for next time");
                        break;
                    default:
                        Console.WriteLine("The choice's number can be 1-8. Try again:");
                        break;

                }
            }
        }

        public void RevealFullDetailsAboutVehicleBasedOnLicenseNumber()
        {
            Console.WriteLine("Please enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();
            Vehicle vehicle = m_Garage.GetVehicleInGarageByLicenseNumber(licenseNumber);

            Console.WriteLine(vehicle);
        }

        public void ChargeVehicle()
        {
            Console.WriteLine("Please enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Please enter the amount of time you'd like to have for your battery life");
            string fuelAmountUserInput = Console.ReadLine();
            float battaryHoursToAdd;

            if (!float.TryParse(fuelAmountUserInput, out battaryHoursToAdd))
            {
                throw new FormatException("Invalid input for battery life: " + fuelAmountUserInput);
            }

            try
            {
                m_Garage.FillEnergyForBatteryVehicle(licenseNumber, battaryHoursToAdd);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FuelAVehicle()
        {
            Console.WriteLine("Please enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Please enter the fuel type");
            short fuelTypeListPosition = 0;
            eFuelType[] avaliableFuelTypesArray = (eFuelType[])Enum.GetValues(typeof(eFuelType));

            foreach (eFuelType avaliableFuelTypes in avaliableFuelTypesArray)
            {
                Console.WriteLine($"For {avaliableFuelTypes}, please type {fuelTypeListPosition++}");
            }

            string usersFuelTypeNumberResponseInput = Console.ReadLine();
            int usersFuelTypeNumberResponse;

            if (!int.TryParse(usersFuelTypeNumberResponseInput, out usersFuelTypeNumberResponse))
            {
                throw new FormatException("Invalid input for fuel type");
            }

            eFuelType eFuelType = avaliableFuelTypesArray[usersFuelTypeNumberResponse];

            Console.WriteLine("Please enter the amount of fuel you'd like to fuel");
            string fuelAmountUserInput = Console.ReadLine();
            float fuelAmount;

            if (!float.TryParse(fuelAmountUserInput, out fuelAmount))
            {
                throw new FormatException("Invalid input for fuel amount: " + fuelAmountUserInput);
            }

            try
            {
                m_Garage.FillEnergyForFueledVehicle(licenseNumber, eFuelType, fuelAmount);
                Console.Clear();
                Console.WriteLine("The vehicle was successfully fueled");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InflateTiresByLicenseNumber()
        {
            Console.WriteLine("Please enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();

            m_Garage.InflatTiresByLicenseNumber(licenseNumber);
            Console.Clear();
            Console.WriteLine("The tires were successfully inflated");
        }

        public void ChangeVehicleCondition()
        {
            Console.WriteLine("Please enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();
            short vehicleConditionArrayPosition = 0;
            eVehicleCondition[] avaliableVehicleConditionsArray = (eVehicleCondition[])Enum.GetValues(typeof(eVehicleCondition));

            foreach (eVehicleCondition avaliableVehicleCondition in avaliableVehicleConditionsArray)
            {
                Console.WriteLine($"For {avaliableVehicleCondition}, please type {vehicleConditionArrayPosition++}");
            }

            string usersVehicleConditionNumberResponseInput = Console.ReadLine();
            int usersVehicleConditionNumberResponse;

            if (!int.TryParse(usersVehicleConditionNumberResponseInput, out usersVehicleConditionNumberResponse))
            {
                throw new FormatException("Invalid Condition value ");
            }

            eVehicleCondition eVehicleCondition = avaliableVehicleConditionsArray[usersVehicleConditionNumberResponse];

            m_Garage.ChangeVehicleCondition(licenseNumber, eVehicleCondition);
        }

        public void GetAllLicensesInGarage()
        {
            if (m_Garage.Vehicles.Count != 0)
            {
                foreach (Vehicle vehicle in m_Garage.Vehicles)
                {
                    Console.WriteLine(vehicle.LicenseNumber);
                }

                Console.WriteLine("To sort them by status:");
                eVehicleCondition vehicleCondition;
                short vehicleConditionArrayPosition = 0;
                eVehicleCondition[] avaliableVehicleConditionsArray = (eVehicleCondition[])Enum.GetValues(typeof(eVehicleCondition));

                foreach (eVehicleCondition avaliableVehicleCondition in avaliableVehicleConditionsArray)
                {
                    Console.WriteLine($"for {avaliableVehicleCondition}, please type {vehicleConditionArrayPosition++}");
                }

                Console.WriteLine($"or type {vehicleConditionArrayPosition} to get back to the main menu:");
                string usersRespontOfCondition = Console.ReadLine();

                switch (usersRespontOfCondition)
                {
                    case "0":
                        vehicleCondition = eVehicleCondition.InRepair;
                        break;
                    case "1":
                        vehicleCondition = eVehicleCondition.Repaired;
                        break;
                    case "2":
                        vehicleCondition = eVehicleCondition.Paid;
                        break;
                    case "3":

                        return;
                    default:
                        throw new FormatException($"The choice's number can be 0 - {vehicleConditionArrayPosition}. Try again:");
                }

                GetAllLicensesInGarageBasedOnVehicleCondition(vehicleCondition);
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage at the moment.");
            }
        }

        public void GetAllLicensesInGarageBasedOnVehicleCondition(eVehicleCondition i_Condition)
        {
            if (m_Garage.Vehicles.Count != 0)
            {
                bool foundVehicle = false;

                foreach (Vehicle vehicle in m_Garage.Vehicles)
                {
                    if (vehicle.VehicleCondition == i_Condition)
                    {
                        Console.WriteLine(vehicle.LicenseNumber);
                        foundVehicle = true;
                    }
                }

                if (!foundVehicle)
                {
                    Console.WriteLine(String.Format($"There are no vehicles in the garage with condition '{i_Condition}'."));
                }
            }
            else
            {
                Console.WriteLine("There are no vehicles in the garage at the moment.");
            }
        }

        public void AddVehicleToGarage()
        {
            string licenseNumber;
            string vehicleType;
            string usersVehicleNumberResponseInput;
            short vehicleListPosition = 0;

            Console.WriteLine("Please enter your license number");
            licenseNumber = Console.ReadLine();

            if (m_Garage.CheckIfVehicleExists(licenseNumber))
            {
                Console.WriteLine("Vehicle already exists in the garage. Changing its condition to in Repair....");
                m_Garage.ChangeVehicleCondition(licenseNumber, eVehicleCondition.InRepair);
            }
            else
            {
                try
                {
                    Console.WriteLine("Vehicle doesn't exist in the garage, Please enter your vehicle type that you interested in");
                    foreach (string vehicleTypeAvaliable in VehicleFactory.AvaliableVehicles)
                    {
                        Console.WriteLine($"For {vehicleTypeAvaliable}, please type {vehicleListPosition++}");
                    }

                    usersVehicleNumberResponseInput = Console.ReadLine();
                    int usersVehicleNumberResponse;

                    if (!int.TryParse(usersVehicleNumberResponseInput, out usersVehicleNumberResponse))
                    {
                        throw new FormatException("Invalid input for vehicle type");
                    }

                    vehicleType = VehicleFactory.AvaliableVehicles[usersVehicleNumberResponse]; 
                    Vehicle vehicle = VehicleFactory.CreateVehicle(licenseNumber, vehicleType);
                    // In order for the program to remain modular, we used files so that if we want to add more vehicles, we can simply add a new file under the same name as the new vehicle with the data it needs.
                    // Configuration for each vehicle type is stored in separate text files.
                    // Adding a new vehicle in the future involves creating a new text file rather than modifying UI code. 
                    string directoryPath = Path.Combine("..", "..", "..", "..", "A24 Ex03 EyalChachmishvily 209786094 MorCohen 313201246", "Ex03.ConsoleUI", "Files"); 
                    string fileName = vehicleType + ".txt";
                    string filePath = Path.Combine(directoryPath, fileName);
                    string[] lines = File.ReadAllLines(filePath);
                    List<string> userResponses = new List<string>();

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                        string response = Console.ReadLine();

                        Console.Clear();
                        userResponses.Add(response);
                    }

                    VehicleFactory.UpdateVehicle(m_Garage, vehicle, userResponses);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Make sure you enter a correct input");

                    return;
                }
            }

            Console.Clear();
            Console.WriteLine("Your vehicle has successfully entered our garage!");
        }
    }
}
