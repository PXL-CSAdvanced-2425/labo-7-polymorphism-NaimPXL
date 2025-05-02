using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Labo_7___Polymorphism.Entities
{
	internal class LaserCutter : Router
	{

		public double Accuracy { get; set; }
		protected override int LifeSpanCostPerMinute => 1500;


		public LaserCutter(string name, double width, double length, double cost, double accuracy) : base(name, width, length, cost)
		{
			Accuracy = accuracy;
			LifeSpan = 5000;
		}

		public override void Use(int numberOfMinutes)
		{
			LifeSpan -= ((numberOfMinutes * LifeSpanCostPerMinute) + 100);
		}

		public override string ToString()
		{
			return $"LaserCutter: \t'{Name}' ({WorkSpaceWidth}x{WorkSpaceLength}) [accuracy: {Accuracy}] {base.LifeSpanInfo()}";
		}
	}
}
