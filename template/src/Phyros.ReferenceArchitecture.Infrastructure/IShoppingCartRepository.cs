using Phyros.ReferenceArchitecture.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phyros.ReferenceArchitecture.Infrastructure
{
	public interface IShoppingCartRepository
	{
		ShoppingCart Retrieve(string userId);
		void SaveEvents(string userId, IEnumerable<ShoppingCartBaseEvent> events);
		void SaveEvents(object unsavedEvents);
	}
}
