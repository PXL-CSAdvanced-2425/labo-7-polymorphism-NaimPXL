using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
	internal abstract class Machine
	{
		public string Name { get; set; }
		public int LifeSpan { get; set; }
		public float Price { get; set; }
		public bool OutOfUse
		{ 
			get { return LifeSpan <= 0; }
		}


		protected abstract int LifeSpanCostPerMinute { get; }

		public abstract void Use(int numberOfMinutes);

		protected string LifeSpanInfo()
		{
			return OutOfUse ? "OUT OF USE" : $"<lifespan: {LifeSpan}h>";
		}

		public override string ToString()
		{
			return LifeSpanInfo();
		}

		protected Machine(string name)
		{
			this.Name = name;
		}
	}
}
