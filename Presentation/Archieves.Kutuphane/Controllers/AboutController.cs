using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Services.Concretes;
using Archieves.Kutuphane.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    public class AboutController : Controller
    {
        private readonly SubscriberService subscribers;
        public AboutController(SubscriberService _subscribers)
        {
            subscribers = _subscribers;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SubscriberAddModel subscriber)
        {
            SubscriberAddModelValidator subscriberValidator = new SubscriberAddModelValidator();
            ValidationResult validationResult = subscriberValidator.Validate(subscriber);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            else
            {
                subscribers.AddSubscriberModelAsync(subscriber);
                return RedirectToAction("Index", "About");
            }
        }
    }
}
