using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public class ValueOutOfRangeException:Exception
    {
        public float MaxValue 
        {
            get; 
        }

        public float MinValue
        {
            get;
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue):base(string.Format($"Error! Value is out of range!"))
        {
            this.MinValue = i_MinValue;
            this.MaxValue = i_MaxValue;
        }
    }
}
