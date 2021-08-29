using Phyros.ReferenceArchitecture.DomainModels;
using Phyros.ReferenceArchitecture.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phyros.ReferenceArchitecture.API.Converters
{
	public static class ShoppingCartConverter
	{
		public static ShoppingCartDto ToDto(this ShoppingCart shoppingCart)
		{
			return new ShoppingCartDto()
			{
				Items = shoppingCart.Items?.Select(x => new ItemDto()
				{
					ProductId = x.ProductId,
					Quantity = x.Quantity
				}).ToArray()
			};
		}
	}
}
