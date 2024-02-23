using System.Collections.Generic;

namespace Ex03_01
{
    public abstract class Car:Vehicle
    {
        protected eCarColor m_CarColor;
        protected eCarDoor m_CarDoor;

        protected Car(string i_ModelName, string i_LicenseNumber, eCarColor i_Color, eCarDoor i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber)
        {
            this.m_CarColor = i_Color;
            this.m_CarDoor= i_NumberOfDoors;
        }
        protected void UpdateVehicleDetails(string i_OwnerName,string i_OwnerNumber,string i_VehicleCondition,eCarColor i_carColor,eCarDoor i_numberOfDoors)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition);
            this.m_CarColor = i_carColor;
            this.m_CarDoor = i_numberOfDoors;
        }
    }
}
