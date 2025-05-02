using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public IActionResult Index()
        {
            var model = _statisticService.GetList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddStatistic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStatistic(Statistic model)
        {
            if (ModelState.IsValid)
            {
                _statisticService.Add(model);
                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage); // Hata mesajlarını logla
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateStatistic(int id)
        {
            var model = _statisticService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateStatistic(Statistic model)
        {
            if (ModelState.IsValid)
            {
                _statisticService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteStatistic(int id)
        {
            var model = _statisticService.GetById(id);
            _statisticService.Delete(model);
            return RedirectToAction("Index");
        }
    }
}
