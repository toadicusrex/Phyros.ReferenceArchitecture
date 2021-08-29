using Microsoft.AspNetCore.Mvc;
using Phyros.ReferenceArchitecture.API.Converters;
using Phyros.ReferenceArchitecture.DTO;
using Phyros.ReferenceArchitecture.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phyros.ReferenceArchitecture.API.Controllers
{
	public class ShoppingCartController : ControllerBase
	{
		private readonly IShoppingCartManager _shoppingCartManager;

		public ShoppingCartController(IShoppingCartManager shoppingCartManager)
		{
			_shoppingCartManager = shoppingCartManager;
		}
		public ActionResult Get(string user)
		{
			try
			{
				var shoppingCart = _shoppingCartManager.RetrieveCart(user);
				if (shoppingCart != null)
				{
					return Ok(shoppingCart.ToDto());
				}
				return NotFound();
			}
			catch
			{
				return BadRequest();
			}
		}

		//public ActionResult Add(ItemDto item)
		//{

		//}
	}
}
