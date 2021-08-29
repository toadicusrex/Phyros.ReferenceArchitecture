using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phyros.ReferenceArchitecture.DomainModels
{
	public class ShoppingCartChangeEvent : ShoppingCartBaseEvent
	{
		public string ProductId { get; set; }
		public int QuantityChange { get; set; }
	}
}
