using PriceConverter.ModelProvider;
using PriceConverter.Models;
using System.Web.Mvc;

namespace PriceConverter.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceModelProvider _priceModelProvider;

        public PriceController(IPriceModelProvider priceModelProvider)
        {
            _priceModelProvider = priceModelProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new PriceModel());
        }

        [HttpPost]
        public ActionResult Index(PriceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(_priceModelProvider.GetModel(model.Value));
        }
    }
}