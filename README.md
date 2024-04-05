**Small Garage Management System**

The goal is to develop a small system to manage a garage. The system is capable of managing five types of vehicles:

1. Regular Motorcycle
2. Electric Motorcycle
3. Regular Car
4. Electric Car
5. Truck

Each vehicle type possesses the following characteristics:

- Model Name (string)
- License Plate Number (string)
- Remaining Energy Percentage (float)
- Collection of Wheels

Each wheel has the following properties:

- Manufacturer Name (string)
- Current Air Pressure (float)
- Maximum Air Pressure (float)
- Inflation Action (method to add air to the wheel)

In addition to the general vehicle characteristics, each type of vehicle has specific properties:

- For motorcycles (regular/electric), additional properties include:
  - License Type (A1, A2, AB, B2)
  - Engine Capacity in cc (int)

- For cars (regular/electric), additional properties include:
  - Color (blue, white, red, yellow)
  - Number of Doors (2, 3, 4, or 5)

- For trucks, additional properties include:
  - Hazardous Material Transport (bool)
  - Cargo Capacity (float)

For vehicles running on fuel, the system should provide information about:

- Fuel Type (Octan98, Octan96, Octan95, Soler)
- Current Fuel Amount in Liters (float)
- Maximum Fuel Capacity in Liters (float)
- Refueling Action (method to refuel)

For electric vehicles, the system should provide information about:

- Remaining Battery Time in hours (float)
- Maximum Battery Time in hours (float)
- Charging Action (method to charge)

The system offers the following functionalities:

1. Add a new vehicle to the garage:
   - Input: License plate number
   - If the vehicle already exists in the garage, utilize the existing vehicle and change its status to "In repair."
   - If not:
     - Select the vehicle type and input its condition (e.g., fuel level, battery status, tire pressure, color, license type, etc.).
     - To ease user input, allow setting the same condition for all wheels simultaneously.
     - Display appropriate error messages only after the user finishes inputting all details.

2. Display a list of vehicle license plate numbers in the garage, with filtering options based on their status.

3. Change the status of a vehicle in the garage (input required: license plate number and new status).

4. Inflate the tires of a vehicle to their maximum pressure (input required: license plate number).

5. Refuel a fuel-operated vehicle (input required: license plate number, fuel type, amount to refuel).

6. Charge an electric vehicle (input required: license plate number, minutes to charge).

7. Display complete vehicle details based on the license plate number.

This system provides basic management functionalities for a garage, allowing efficient handling of various types of vehicles.

implemented the garage management system using polymorphism, inheritance, and file handling.
