using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeblexData.Data;
using MeblexData.Models.Order;
using MeblexData.Interfaces;
using MeblexData.Models;
using Microsoft.AspNetCore.Authorization;
using Meblex.ModelsDTO;

namespace Meblex.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {

        private readonly IAdminRepository _adminRepository;

        public AdminController( IAdminRepository adminRepository)
        {

            _adminRepository = adminRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Statistics =  _adminRepository.GetStatistics();

            var order = _adminRepository.orders.Select(item => new OrderDTO
            {
                OrderId = item.OrderId,
                PhoneNumber = item.PhoneNumber,
                OrderPlaced = item.OrderPlaced,
                IsShipped = item.IsShipped,
                LastName = item.LastName,
                OrderTotal = item.OrderTotal
            }
            );
            return View(order);
        }

        public  IActionResult Products()
        {
            var products = _adminRepository.products
                .Select(item => new ProductDTO
            {
                ProductID = item.ProductID,
                Name = item.Name,
                Price = item.Price,
                IsPreferred = item.IsPreferred,
                Category = item.Category,
                Description = item.Description,
                ImageUrl = item.ImageUrl,

            }
            );
               
                            
            return View(products);
        }

        public  IActionResult Categories()
        {
            var categories = _adminRepository.Categories.Select(item => new CategoryDTO
            {
                CategoryId = item.CategoryId,
                Description = item.Description,
                Name = item.Description,
            });

            return View(categories);
        }

        [HttpGet, ActionName("DetailsOrder")]
        [Route("Admin/Order/Details/{id}")]

        public async Task<IActionResult> DetailsOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _adminRepository.GetOrderDetails(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet, ActionName("DetailsCategory")]
        [Route("Admin/Category/Details/{id}")]
        public async Task<IActionResult> DetailsCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _adminRepository.GetCategoryDetailsAsync(id);
            CategoryDetailsDTO categoryDetailsDTO = new CategoryDetailsDTO()
            {
                CategoryId = category.CategoryId,
                Description = category.Description,
                Name = category.Name,
                products = category.Products,

            };

            if (categoryDetailsDTO == null)
            {
                return NotFound();
            }

            return View(categoryDetailsDTO);
        }

        [HttpGet, ActionName("DetailsProduct")]
        [Route("Admin/Product/Details/{id}")]
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product= await _adminRepository.GetProductByIdAsync(id);

            ProductDetailsDTO productDetailsDTO = new ProductDetailsDTO()
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                Lenght = product.Lenght,
                Width = product.Width,
                Height = product.Height,
                Weight = product.Weight,
                Description = product.Description,
                Material = product.Material,
                Color = product.Color,
                IsPreferred = product.IsPreferred,
                ImageUrl = product.ImageUrl,
                Category = product.Category,
            };

            if (productDetailsDTO == null)
            {
                return NotFound();
            }

            return View(productDetailsDTO);
        }

        // GET: Admin/Delete/5

        [Route("Admin/Order/Delete/{id}")]

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await  _adminRepository.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [Route("Admin/Product/Delete/{id}")]

        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _adminRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Route("Admin/Categories/Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await _adminRepository.GetCategoryDetailsAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [Route("Admin/Categories/Delete/{id}")]
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoryConfirmed(int id)
        {
            await _adminRepository.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Categories));
        }

        [Route("Admin/Order/Delete/{id}")]

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderConfirmed(int id)
        {
            await _adminRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        [Route("Admin/Product/Delete/{id}")]

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            await _adminRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Products));
        }


        [Route("Admin/Categories/Create")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Route("Admin/Product/Create")]
        public  IActionResult CreateProduct()
        {
            ViewData["CategoryID"] = new SelectList(_adminRepository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost, ActionName("CreateProduct")]
        [ValidateAntiForgeryToken]
        [Route("Admin/Product/Create")]

        public async Task<IActionResult> CreateProduct([Bind("ProductID,Name,Price,Lenght,Width,Height,Weight,Description,Material,Color,IsPreferred,ImageUrl,ImageThumbnail,CategoryID")] Product product)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    await _adminRepository.AddProduct(product);
                    return RedirectToAction(nameof(Categories));
                }
            }
            catch (DbUpdateException)
            {

                ModelState.AddModelError("", "Nie można dodać nowego mebelka .");
            }

            return View(product);
        }

        [HttpPost, ActionName("CreateCategory")]
        [ValidateAntiForgeryToken]
        [Route("Admin/Categories/Create")]

        public async Task<IActionResult> CreateCategory([Bind("CategoryId,Name,Description")] Category category)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _adminRepository.AddCategoryAsync(category);
                    return RedirectToAction(nameof(Categories));
                }
            }
            catch (DbUpdateException)
            {
               
                ModelState.AddModelError("", "Nie można dodać nowej kategorii .");
            }

            return View(category);
        }

        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _adminRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryID"] = new SelectList(_adminRepository.Categories, "CategoryId", "Name", product.CategoryID);

            return View(product);
        }

        [Route("Admin/Category/Edit/{id}")]

        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _adminRepository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, [Bind("ProductID,Name,Price,Lenght,Width,Height,Weight,Description,Material,Color,IsPreferred,ImageUrl,ImageThumbnail,CategoryID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _adminRepository.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_adminRepository.ProductExist(product.ProductID).Equals(false))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost, ActionName("EditCategory")]
        [Route("Admin/Category/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, [Bind("CategoryId,Name,Description")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _adminRepository.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_adminRepository.CategoryExist(category.CategoryId).Equals(false))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Categories));
            }
            return View(category);
        }

        public async Task<IActionResult> ConfirmShipping(int id)
        {
            return Ok( await _adminRepository.IsShipped(id));
        }

        public async Task<IActionResult> ChangePreffering(int id)
        {
            await _adminRepository.PrefferProduct(id);
            return RedirectToAction(nameof(Products));

        }




    }
}
