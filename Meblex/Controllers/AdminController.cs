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
using Meblex.Services.Interfaces;

namespace Meblex.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {


        private readonly IAdminService adminService;


        public AdminController(IAdminService _adminService)
        {

            adminService = _adminService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Statistics = await adminService.GetStatistics(); 
            return View(await adminService.GetAllOrders());
        }

        public async Task<ActionResult> Products()
        {
            return View(await adminService.GetAllProducts());
        }

        public async Task<IActionResult> Categories()
        {
            return View(await adminService.GetAllCategories());
        }

        [HttpGet, ActionName("DetailsOrder")]
        [Route("Admin/Order/Details/{id}")]

        public async Task<IActionResult> DetailsOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await adminService.GetOrderById(id);

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

            var category = await adminService.GetCategoryById(id);
            

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet, ActionName("DetailsProduct")]
        [Route("Admin/Product/Details/{id}")]
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await adminService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }     

            return View(product);
        }

        // GET: Admin/Delete/5

        [Route("Admin/Order/Delete/{id}")]

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await adminService.GetOrderById(id);

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

            var product = await adminService.GetProductById(id);

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

            var category = await adminService.GetCategoryById(id);

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
            await adminService.DeleteCategory(id);
            return RedirectToAction(nameof(Categories));
        }

        [Route("Admin/Order/Delete/{id}")]

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderConfirmed(int id)
        {
            await adminService.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        [Route("Admin/Product/Delete/{id}")]

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            await adminService.DeleteProduct(id);
            return RedirectToAction(nameof(Products));
        }


        [Route("Admin/Categories/Create")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Route("Admin/Product/Create")]
        public  async Task<IActionResult> CreateProduct()
        {
            var Categories = await adminService.GetAllCategories();
            ViewData["CategoryID"] = new SelectList(Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost, ActionName("CreateProduct")]
        [ValidateAntiForgeryToken]
        [Route("Admin/Product/Create")]

        public async Task<IActionResult> CreateProduct([Bind("ProductID,Name,Price,Lenght,Width,Height,Weight,Description,Material,Color,IsPreferred,ImageUrl,ImageThumbnail,CategoryID")] ProductDetailsDTO product)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    await adminService.createnewproduct(product);
                    return RedirectToAction(nameof(Products));
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

        public async Task<IActionResult> CreateCategory([Bind("CategoryId,Name,Description")] CategoryDetailsDTO category)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await adminService.CreateNewCategory(category);
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

            var product = await adminService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var categories = await adminService.GetAllCategories();

            ViewData["CategoryID"] = new SelectList(categories, "CategoryId", "Name", product.CategoryID);

            return View(product);
        }

        [Route("Admin/Category/Edit/{id}")]

        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await adminService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, [Bind("ProductID,Name,Price,Lenght,Width,Height,Weight,Description,Material,Color,IsPreferred,ImageUrl,ImageThumbnail,CategoryID")] ProductDetailsDTO product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await adminService.UpdateProduct(id, product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (adminService.ProductExist(product.ProductID).Equals(false))
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
        public async Task<IActionResult> EditCategory(int id, [Bind("CategoryId,Name,Description")] CategoryDetailsDTO category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await adminService.UpdateCategory(id,category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (adminService.CategoryExist(category.CategoryId).Equals(false))
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

        public async Task<RedirectToActionResult> ConfirmShipping(int id)
        {
            await adminService.OrderDone(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangePreffering(int id)
        {
            await adminService.ChangePreffer(id);
            return RedirectToAction(nameof(Products));

        }




    }
}
