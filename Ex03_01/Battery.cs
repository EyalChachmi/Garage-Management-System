namespace Ex03_01
{
    public class Battery
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

        public void batteryCharge(float i_BatteryHoursToCharge)
        {
            if ((i_BatteryHoursToCharge + m_RemainingBatteryTime) <= m_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_BatteryHoursToCharge;
            }
        }

    }
}
