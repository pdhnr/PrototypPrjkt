using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PrototypProjekta.Models;
using PrototypProjekta.Services;

namespace PrototypProjekta.Controllers
{
    public class SneakerController : Controller
    {

        private readonly ISneakerRepository _repository;
        public SneakerController(AppDbContext context, ISneakerRepository repository_post)
        {
            _repository = repository_post;
        }


        public IActionResult Index()
        {
            return View(_repository.FindAll());
        }


        //Dodawanie 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] SneakerModel sneakerModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Save(sneakerModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

    }
}
