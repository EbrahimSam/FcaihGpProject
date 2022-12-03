using FcaihGpProject.Infrastructure;
using FcaihGpProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FcaihGpProject.Controllers
{
    //[Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        private readonly IRepoProvider repoProvider;
        private readonly IRepoOffer repoOffer;
        private readonly IRepoRequest repoRequest;
        public ClientController(IRepoProvider repoProvider, IRepoRequest repoRequest ,IRepoOffer repoOffer)
        {
            this.repoProvider = repoProvider;
            this.repoRequest = repoRequest;
            this.repoOffer = repoOffer; 
        }
        public IActionResult GetProviders()
        {
            var Providers = repoProvider.GetAll();
            return PartialView(Providers);
        }
        [HttpGet]
        public IActionResult CreateRequest(Guid RequesterId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRequest(Request request)
        {
            if (ModelState.IsValid)
            {
                var response = repoRequest.Create(request);
                if (response.success)
                    return RedirectToAction("GetRequest",new {id = response.Id});
                return NotFound(); // TODO : Custom Error Page
            }
            return View(request);
        }
        public IActionResult GetClinetRequests()
        {
            var Requests = repoRequest.GetClientRequests(Guid.NewGuid()); // edit with Claims After 
            return PartialView(Requests); 
        }
        public IActionResult DeleteRequest(Guid RequestId)
        {
            var response = repoRequest.Delete(RequestId);
            return Json(response.success); // To Works with Ajax Callas 
        }
        [HttpGet]
        public IActionResult UpdateRequest (Guid RequestId)
        {
            var Request = repoRequest.Get(RequestId);
            if (Request != null)
            {
                return View(Request);
            }
            return NotFound(); //TODO: Custom NotFound View 
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateRequest (Request request)
        {
            if (ModelState.IsValid)
            {
                var response = repoRequest.Update(request);
                if (response.success) 
                    return RedirectToAction("GetRequest",new {id = response.Id});
                return NotFound(); //
            }
            return View(request); 
        }
        public IActionResult GetRequest (Guid id)
        {
            var request = repoRequest.Get(id); 
            if (request != null)
            {
                return View(request); 
            }
            return NotFound(); // 
        }
        public IActionResult GetOffersByRequest (Guid RequestId)
        {
            return View(repoOffer.GetByRequest(RequestId)); 
        }
        public IActionResult GetAllProviderOnCity(string city)
        {
            return Json(repoProvider.GetAllWithCondition(p=>p.City==city)) // as Example
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
