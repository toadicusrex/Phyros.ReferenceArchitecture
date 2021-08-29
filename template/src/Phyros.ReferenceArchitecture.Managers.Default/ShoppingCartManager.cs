using Phyros.ReferenceArchitecture.DomainModels;
using Phyros.ReferenceArchitecture.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phyros.ReferenceArchitecture.Managers.Default
{
	public class ShoppingCartManager : IShoppingCartManager
	{
		private readonly IShoppingCartRepository _shoppingCartRepository;

		public ShoppingCartManager(IShoppingCartRepository shoppingCartRepository)
		{
			_shoppingCartRepository = shoppingCartRepository;
		}
		public void AddItem(string userId, string productId, int quantityChange)
		{
			var shoppingCart = _shoppingCartRepository.Retrieve(userId);
			shoppingCart.AddEvent(new ShoppingCartChangeEvent()
			{
				ProductId = productId,
				QuantityChange = quantityChange
			});
			_shoppingCartRepository.SaveEvents(shoppingCart.UnsavedEvents);
		}

		public void ChangeQuantity(string userId, string productId, int newQuantity)
		{
			throw new NotImplementedException();
		}

		public ShoppingCart RetrieveCart(string userId)
		{
			throw new NotImplementedException();
		}
	}
}
