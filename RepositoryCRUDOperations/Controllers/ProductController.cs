using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryCRUDOperations.Models;
using RepositoryCRUDOperations.Repositories;

namespace RepositoryCRUDOperations.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.productRepository.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id","ProductName", "Price", "Quantity")]Product product)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.productRepository.AddAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var product = await _unitOfWork.productRepository.GetProductByIdAsync(id);
            if(product == null)
            {
                return View();
            }   
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id","ProductName", "Price", "Quantity")]Product product)
        {
            if(id != product.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _unitOfWork.productRepository.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var product = await _unitOfWork.productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var product = await _unitOfWork.productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.productRepository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}
