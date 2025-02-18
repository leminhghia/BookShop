using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(CategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            Category item;

            if (id==null || id.Value == 0)
            {
                item = new Category(); 
            }
            else
            {
                item = _unitOfWork.Category.Get(u => u.CatId == id);

            }

            return View(item);
        }

        [HttpPost]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.CatId  == 0)
                {
                    _unitOfWork.Category.Add(obj);

                }
                else
                {
                    _unitOfWork.Category.Update(obj);

                }
                _unitOfWork.Save();
                TempData["success"] = "Category created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpPost]
        //public IActionResult Delete(int? id)
        //{
        //    var deleteItem = _unitOfWork.Category.Get(u => u.Id == id);
        //    if (deleteItem == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Category.Remove(deleteItem);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Delete Category Successfully";
        //    return View();
        //}
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> obj = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = obj });
        }
        [HttpDelete]
        public IActionResult Delete(int? id) 
        { 
            var deleteItem = _unitOfWork.Category.Get(u=>u.CatId == id);
            if (deleteItem == null && !ModelState.IsValid) 
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
           _unitOfWork.Category.Remove(deleteItem);
            _unitOfWork.Save();
            List<Category> obj = _unitOfWork.Category.GetAll().ToList();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
