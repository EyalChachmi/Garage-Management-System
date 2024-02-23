using System;

namespace Ex03_01
{
    public class Fuel
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

        public void FuelVehicle(float i_AmountOfLitersToAdd, eFuelType i_FuelTypeToAdd)
        {
            if (i_FuelTypeToAdd == FuelType && ((i_AmountOfLitersToAdd + m_CurrentFuelQuantity) <= m_MaxFuelQuantity))
            {
                m_CurrentFuelQuantity += i_AmountOfLitersToAdd;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
