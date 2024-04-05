using System;
using System.Text;

namespace Ex03_01
{
    public class Fuel : EnergyType
    {
        private eFuelType eFuelType;
        private float m_MaxFuelQuantity;
        private float m_CurrentFuelQuantity;
        public float CurrentFuelQuantity 
        {
            get
            {
                return m_CurrentFuelQuantity;
            }
            set
            {
                if (value < 0 || value > m_MaxFuelQuantity)
                {
                    throw new ArgumentException("Please select a valid positive value that doesn't go over the max Fuel");
                }

                m_CurrentFuelQuantity = value;
            }
        }

        public float MaxFuelQuantity
        {
            get
            {
                return m_MaxFuelQuantity;
            }
            set
            {
                m_MaxFuelQuantity = value;
            }
        }

        public eFuelType FuelType 
        {
            get
            {
                return eFuelType;
            }
            set
            {
                this.eFuelType = value;
            }
        }

        public Fuel(float i_CurrentFuelQuantity)
        {
            m_CurrentFuelQuantity = i_CurrentFuelQuantity;
        }

        public void FillEnergy(float i_AmountOfLitersToAdd, eFuelType i_FuelTypeToAdd)
        {
            if (i_FuelTypeToAdd == FuelType && ((i_AmountOfLitersToAdd + m_CurrentFuelQuantity) <= m_MaxFuelQuantity))
            {
                m_CurrentFuelQuantity += i_AmountOfLitersToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.m_MaxFuelQuantity - this.CurrentFuelQuantity);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format($"The fuel type is: {eFuelType}"));
            stringBuilder.AppendLine(string.Format($"Its current fuel Quantity is: {m_CurrentFuelQuantity} Liters, it can hold up to {m_MaxFuelQuantity} Liters"));

            return stringBuilder.ToString();
        }
    }
}
