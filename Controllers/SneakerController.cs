using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PrototypProjekta.Models;
using PrototypProjekta.Services;
using System.Data;

namespace PrototypProjekta.Controllers
{
    public class SneakerController : Controller
    {

        private readonly ISneakerRepository _repository;
        public SneakerController(AppDbContext context, ISneakerRepository repository_sneaker)
        {
            _repository = repository_sneaker;
        }

        //////////////////////////////////////////////////////////////////////////////
        //Metoda Akcji:


        //Index
        public IActionResult Index()
        {
            return View(_repository.FindAll());
        }

        /**************************************************************************/

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


        /**************************************************************************/

        //Usuwania
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }




        /**************************************************************************/

        //Okreslanie rodzaju butów
        [HttpGet]
        public IActionResult ChangeCategorySneaker([FromRoute] int id)
        {
            ViewBag.sneakerModelId = id;
            return View();
        }

        [HttpPost]
        public IActionResult ChangeCategorySneaker([FromForm] CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                _repository.ChangeCategorySneaker(categoryModel, categoryModel.SneakerModelId);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
