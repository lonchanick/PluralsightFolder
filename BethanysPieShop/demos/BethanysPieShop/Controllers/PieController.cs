using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";

            //return View(_pieRepository.AllPies);

            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "All Pies");
            return View(piesListViewModel);
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            
            if (pie == null)
                return NotFound();

			return View(pie);
        }
        public IActionResult PiesOfTheWeek()
        {
            var r = _pieRepository.PiesOfTheWeek;
            var r2 = new PieListViewModel(r,"Pies Of the Week");
            return View(r2);
        }
    }
}
