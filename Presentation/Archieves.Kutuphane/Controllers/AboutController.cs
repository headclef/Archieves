using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Kutuphane.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    public class AboutController : Controller
    {
        private readonly ISubscriberService _subscriberService;
        public AboutController(ISubscriberService subscribers)
        {
            _subscriberService = subscribers;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult IndexAsync(SubscriberAddModel subscriber)
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
                _ = _subscriberService.AddSubscriberModelAsync(subscriber);
                return RedirectToAction("Index", "About");
            }
        }
    }
}
