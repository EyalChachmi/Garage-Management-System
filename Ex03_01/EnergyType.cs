using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_01
{
    public abstract class EnergyType
    {
        protected float CurrEnergy
        {
            get;
            set;
        }

        protected float MaxEnergy
        {
            get;
            set;
        }

        public virtual void FillEnergy(float i_EnergyToAdd)
        {
            if (this.CurrEnergy + i_EnergyToAdd <= this.MaxEnergy && i_EnergyToAdd >= 0)
            {
                this.CurrEnergy += i_EnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.MaxEnergy - this.CurrEnergy);
            }
        }
    }
}
