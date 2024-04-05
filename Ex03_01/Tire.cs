using System;
using System.Text;

namespace Ex03_01
{
    public class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximumAirPressure;
        public float MaximumAirPressure
        {
            get
            {
                return m_MaximumAirPressure;
            }
            set
            {
                m_MaximumAirPressure = value;
            }
        }

        public float CurrentAirPressure
        {
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public string ManufacturerName
        {
            set
            {
                m_ManufacturerName = value;
            }
        }

        public Tire(float i_MaximumAirPressure)
        {
            this.m_ManufacturerName = "";
            this.m_CurrentAirPressure = 0;
            MaximumAirPressure = i_MaximumAirPressure;
        }

        public Tire(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public void TireInflation(float i_AmountOfAir)
        {
            if (m_CurrentAirPressure + i_AmountOfAir <= MaximumAirPressure)
            {
                m_CurrentAirPressure += i_AmountOfAir;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.m_MaximumAirPressure - this.m_CurrentAirPressure);
            }
        }

        public void TireInflationToMaximum()
        {
            this.m_CurrentAirPressure = m_MaximumAirPressure;
        }

        public override string ToString()
        {
            return string.Format($"The tire Manufacturer name is : {m_ManufacturerName}, The current air preasure is: {m_CurrentAirPressure}, and its max air pressure it can hold: {m_MaximumAirPressure}");
        }
    }
}
