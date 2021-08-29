using System;
using System.Collections.Generic;
using System.Text;

namespace Phyros.ReferenceArchitecture.DomainModels
{
	public class ShoppingCart
	{
		public ShoppingCart(List<ShoppingCartBaseEvent> events)
		{
			if (events == null) return;
			foreach (var e in events)
			{
				AddStoredEvent(e);
			}
		}

		public ShoppingCartItem[] Items { get; }
		private List<ShoppingCartBaseEvent>
		public IEnumerable<ShoppingCartBaseEvent> UnsavedEvents;


		public void AddEvents(IEnumerable<ShoppingCartBaseEvent> events)
		{

		}
		public void AddEvent(ShoppingCartBaseEvent e)
		{
			AddEvents(new List<ShoppingCartBaseEvent>()
			{
				e
			});
		}

		private void AddStoredEvent(ShoppingCartBaseEvent e)
		{

		}
	}
}
