using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MountainBound.Areas.TradingPost.Models;
using MountainBound.Areas.TradingPost.Models.ViewModels;
using MountainBound.Infrastructure;
using MountainBound.Models;
using Order = MountainBound.Areas.TradingPost.Models.Order;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MountainBound.Areas.TradingPost.Controllers
{
    [Area("TradingPost")]
    public class CheckoutController : Controller
    {
        private AppDbContext _context;

        public CheckoutController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult ShipInfo()
        {
            var shipInfo = HttpContext.Session.GetJson<AddressViewModel>("ShipInfo") ?? new AddressViewModel();
            return View("NewAddress", shipInfo);
        }

        [HttpPost]
        public IActionResult ShipInfo(AddressViewModel shipInfo)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("ShipInfo", shipInfo);
                return RedirectToAction("PaymentInfo");
            }
            return View("NewAddress", shipInfo);
        }

        public IActionResult EditShipInfo()
        {
            var shipInfo = HttpContext.Session.GetJson<AddressViewModel>("ShipInfo");
            return View("NewAddress", shipInfo);
        }

        [HttpGet]
        public IActionResult PaymentInfo()
        {
            var payInfo = HttpContext.Session.GetJson<PaymentInfoViewModel>("PaymentInfo") ?? new PaymentInfoViewModel();
            payInfo.CardNumber = "";
            return View(payInfo);
        }

        [HttpPost]
        public IActionResult PaymentInfo(PaymentInfoViewModel payInfo)
        { 
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("PaymentInfo", payInfo);
                return RedirectToAction("ReviewOrder");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ReviewOrder()
        {
            var cartContents = HttpContext.Session.GetJson<Cart>("Cart");
            if (cartContents == null)
            {
                return RedirectToAction("ViewCart", "Cart");}

            var shipInfo = HttpContext.Session.GetJson<AddressViewModel>("ShipInfo");
            if (shipInfo == null)
            {
                return RedirectToAction("ShipInfo");}
            return View( new ReviewOrderViewModel(){Cart = cartContents, ShipInfo = shipInfo});
        }

        [HttpPost]
        public IActionResult SubmitOrder()
        {
            var cartContents = HttpContext.Session.GetJson<Cart>("Cart");
            var shipInfo = HttpContext.Session.GetJson<AddressViewModel>("ShipInfo");
            var address = new Address()
            {
                FirstName = shipInfo.FirstName,
                LastName = shipInfo.LastName,
                AddressLine1 = shipInfo.AddressLine1,
                AddressLine2 = shipInfo.AddressLine1,
                City = shipInfo.City,
                State = shipInfo.State,
                Zipcode = (int)shipInfo.Zipcode,
                Phone = (long)shipInfo.Phone
            };
            _context.Addresses.Add(address);
            var items = new List<LineItem>();
            items.AddRange(cartContents.LineItems);
            var newOrder = new Order()
            {
                ShippingInfo = address,
                OrderItems = items,
            };
            _context.AttachRange(newOrder.OrderItems);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            var orderId = newOrder.OrderId;
            HttpContext.Session.Clear();
            return RedirectToAction("OrderConfirmation");
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }

        //check if orders saved to DB -- not public
        public IActionResult GetOrder()
        {
           var order= _context.Orders.Include(p => p.OrderItems).FirstOrDefault();
            return View("Order", order);
        }

    }
}

