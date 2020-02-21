using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;

namespace Shop.Controllers
{
    public class PromotionController : Controller
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionController(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                await _promotionRepository.AddAsync(promotion);
                return RedirectToAction("Index");
            }

            return View(promotion);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _promotionRepository.GetAsync(id.Value);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _promotionRepository.UpdateAsync(promotion);

                return RedirectToAction("Index");
            }

            return View(promotion);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var promotions = await _promotionRepository.GetAsync();
            return View(promotions);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _promotionRepository.GetAsync(id.Value);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }
    }
}