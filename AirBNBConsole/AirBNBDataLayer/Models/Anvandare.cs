using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBNBDataLayer
{
	public class Anvandare
	{
		public int ID { get; set; }
		public string Losenord { get; set; }
		public string Namn { get; set; }
		public string Epost { get; set; }

		public Anvandare(string losenord, string namn, string epost)
		{
			this.Losenord = losenord;
			Namn = namn;
			Epost = epost;
		}
		public Anvandare()
		{

		}
	}
}
