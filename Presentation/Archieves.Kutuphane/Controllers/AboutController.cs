using Archieves.Domain.Entities;
using Archieves.Kutuphane.ValidationRules;
using Archieves.Persistence.Concretes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    public class AboutController : Controller
    {
        SubscriberService subscribers = new SubscriberService(new EfSubscriberRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Subscribe(Subscriber subscriber)
        {
            SubscriberValidator subscriberValidator = new SubscriberValidator();
            ValidationResult validationResult = subscriberValidator.Validate(subscriber);
            if (!validationResult.IsValid)
            {
                ModelState.AddModelError("Email", validationResult.Errors[0].ErrorMessage);
                return View();
            }
            else
            {
                subscriber.Status = true;
                subscriber.Date = DateTime.Now;
                subscribers.Add(subscriber);
                return RedirectToAction("Index", "About");
            }
        }
    }
}
