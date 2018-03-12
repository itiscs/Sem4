using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private EShopDB context = new EShopDB();
        public CartController()
        {

        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int ID, string returnUrl)
        {
            Phone  phone = context.Phones
                .FirstOrDefault(g => g.ID == ID);

            if (phone != null)
            {
                GetCart().AddItem(phone, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int ID, string returnUrl)
        {
            Phone phone = context.Phones
                .FirstOrDefault(g => g.ID == ID);

            if (phone != null)
            {
                GetCart().RemoveLine(phone);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
