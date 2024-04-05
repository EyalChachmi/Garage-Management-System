using System.Collections.Generic;
using System.Text;

namespace Ex03_01
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_CarColor;
        protected eCarDoor m_CarDoor;

        protected Car(string i_ModelName, string i_LicenseNumber, eCarColor i_Color, eCarDoor i_NumberOfDoors) : base(i_ModelName, i_LicenseNumber)
        {
            this.m_CarColor = i_Color;
            this.m_CarDoor = i_NumberOfDoors;
        }

        protected void UpdateVehicleDetails(string i_OwnerName, string i_OwnerNumber, eVehicleCondition i_VehicleCondition, string i_ModelName, eCarColor i_carColor, eCarDoor i_numberOfDoors)
        {
            base.UpdateVehicleDetails(i_OwnerName, i_OwnerNumber, i_VehicleCondition, i_ModelName);
            this.m_CarColor = i_carColor;
            this.m_CarDoor = i_numberOfDoors;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine(string.Format($"The color of the car is: {m_CarColor}, The number of doors that the car has is: {(int)m_CarDoor}"));

            return stringBuilder.ToString();
        }
    }
}
