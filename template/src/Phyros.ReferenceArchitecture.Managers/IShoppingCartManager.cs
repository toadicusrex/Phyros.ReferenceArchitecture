using Phyros.ReferenceArchitecture.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phyros.ReferenceArchitecture.Managers
{
	public interface IShoppingCartManager
	{
		ShoppingCart RetrieveCart(string userId);
		void AddItem(string userId, string productId, int quantityChange);
		void ChangeQuantity(string userId, string productId, int newQuantity);
	}
}
