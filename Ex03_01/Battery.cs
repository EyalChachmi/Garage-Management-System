using System;
using System.Text;

namespace Ex03_01
{
    public class Battery : EnergyType
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;
        public float RemainingBatteryTime
        {
            get
            {
                return m_RemainingBatteryTime;
            }
            set
            {
                if (value < 0 || value > m_MaxBatteryTime)
                {
                    throw new ArgumentException("Please select a valid positive value that doesn't go over the max battery life");
                }

                m_RemainingBatteryTime = value;
            }
        }

        public float MaxBatteryTime
        {
            get
            {
                return m_MaxBatteryTime;
            }
            set
            {
                m_MaxBatteryTime = value;
            }
        }

        public Battery(float i_RemainingBatteryTime)
        {
            this.m_RemainingBatteryTime = i_RemainingBatteryTime;
        }

        public override void FillEnergy(float i_BatteryHoursToCharge)
        {
            if ((i_BatteryHoursToCharge + m_RemainingBatteryTime) <= m_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_BatteryHoursToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.m_MaxBatteryTime - m_RemainingBatteryTime);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format($"Its current Remaining Battery life Time is: {m_RemainingBatteryTime} Hours, it can hold up to {m_MaxBatteryTime} Hours"));

            return stringBuilder.ToString();
        }
    }
}
