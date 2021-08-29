using Phyros.ReferenceArchitecture.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phyros.ReferenceArchitecture.Infrastructure.InMemoryDatabase
{
	public class ShoppingCartInMemoryRepository : IShoppingCartRepository
	{
		private static Dictionary<string, List<ShoppingCartBaseEvent>> storedEvents = new Dictionary<string, List<ShoppingCartBaseEvent>>();

		public ShoppingCart Retrieve(string userId)
		{
			var events = storedEvents[userId];
			return new ShoppingCart(events);
		}

		public void SaveEvents(string userId, IEnumerable<ShoppingCartBaseEvent> events)
		{
			if (!events?.Any() ?? false) return;
			var existing = storedEvents[userId] ?? new List<ShoppingCartBaseEvent>();
			existing.AddRange(events);
		}
	}
}
