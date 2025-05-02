using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_7___Polymorphism.Entities
{
	internal class Router : Machine
	{
		public double  WorkSpaceWidth { get; set; }
		public double WorkSpaceLength { get; set; }
		public double CostPerMinute { get; set; }


		protected override int LifeSpanCostPerMinute {
			get { return 50;  }
		}

		public Router(string name, double width, double length, double cost) : base(name)
		{
			WorkSpaceWidth = width;
			WorkSpaceLength = length;
			CostPerMinute = cost;

			base.LifeSpan = 25000;
		}



		public override void Use(int numberOfMinutes)
		{
			LifeSpan -= (numberOfMinutes * LifeSpanCostPerMinute);
		}

		public override string ToString()
		{
			return $"ROUTER: \t'{Name}' ({WorkSpaceWidth}x{WorkSpaceLength}) {base.ToString()}";
		}
	}
}
