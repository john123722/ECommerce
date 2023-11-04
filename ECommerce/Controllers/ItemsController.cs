using ECommerce.Data_Access_Layer;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        
        private readonly DAL con = new DAL();
        public ActionResult Index()
        {
            var vm = con.GetItems();
            return View(vm);
        }
        
        public ActionResult AddItems()
        {
            var vm = new AddItemModel();
            _ = new List<CategoriesModel>();
            List<CategoriesModel> li = con.GetCategories();
            vm.DisplayCategories = li;
            return View(vm);
        }
        [HttpPost]
        public ActionResult GetCategories()
        {
            List<CategoriesModel> li = con.GetCategories();
            return Json(new { result = li });

        }
        [HttpPost]
        public ActionResult AddItems(AddItemModel item) 
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var file = Request.Files[i];

                            if (file != null && file.ContentLength > 0)
                            {
                            AddItemModel fileCopy = new AddItemModel
                            {
                                    UserId = (int)Convert.ToInt64(Request.Cookies["User"].Value),
                                    ItemName = item.ItemName,
                                    Category = item.Category,
                                    Price = item.Price,
                                    Quantity = item.Quantity,
                                    Description = item.Description,
                                    FileName = Path.GetFileName(file.FileName),
                                    FileSize = file.ContentLength,
                                    FileType = Path.GetExtension(file.FileName)?.TrimStart('.').ToLower(),
                                    UploadDate = DateTime.Now
                                };

                                string uploadFolderPath = Server.MapPath(ConfigurationManager.AppSettings["ImagePath"]);
                                string folderPath = uploadFolderPath;

                                // Create the folder if it doesn't exist
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }
                               
                                string originalFileName = file.FileName;
                                string uniqueFileName = Guid.NewGuid().ToString();
                                string filePath = Path.Combine(uploadFolderPath, uniqueFileName + Path.GetExtension(originalFileName));
                                     
                                // Save the file without compression
                                file.SaveAs(filePath);

                                fileCopy.FilePath = Path.Combine("..\\Images", uniqueFileName + Path.GetExtension(originalFileName));
                                fileCopy.FileName = uniqueFileName;

                                con.Upload(fileCopy);
                            }
                        }

                        return RedirectToAction("Index");
                   
                }
            }
            return View();
            
        }

        [HttpPost]
        public bool AddToCart(int itemid)
        {
            int buyerId = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            bool vm = con.AddItemsToCart(itemid,buyerId);
            return vm;
        }

        public ActionResult ViewCart() 
        {
            int buyerId = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            var vm = con.GetCartItems(buyerId);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(int itemNumber,int buyingQuantity,int quantity)
        {
            bool res = con.GetCartItemsForEdit(itemNumber,buyingQuantity, quantity);
            return Json(new { success = res });
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int ItemNo,int Quantity)
        {
            bool res = con.RemoveItemsFromCart(ItemNo, Quantity);
            return Json(new { success = res }); 
        }

        [HttpPost]
        public ActionResult BuyItem(int ItemNo, int BuyQuantity, int ItemId,float Price)
        {
            int buyerid = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            float totalPrice = BuyQuantity*Price;
            bool res = con.BuyItems(ItemNo, BuyQuantity, buyerid,ItemId,Price,totalPrice);
            return Json(new { success = res });
        }
        public ActionResult ViewBuyItems()
        {
            int buyerId = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            var vm = con.GetBuyItems(buyerId);
            return View(vm);
        }

        public ActionResult ViewBuyReports()
        {
            int userId = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            var vm = con.GetBuyReports(userId);
            return View(vm);
        }

        public ActionResult EditItems(int UserId)
        {
            var vm = con.GetItemsForEdit(UserId);
            return View(vm);
        }

        public ActionResult EditIndividualItems(int ItemId)
        {
            _ = new AddItemModel();
            AddItemModel vm = con.GetInvidualEditItem(ItemId);
            _ = new List<CategoriesModel>();
            List<CategoriesModel> li = con.GetCategories();
            vm.DisplayCategories = li;
            Session["ItemId"] = ItemId;
            return View(vm);
        }
        [HttpPost]
        public ActionResult EditIndividualItems(AddItemModel item)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            AddItemModel fileCopy = new AddItemModel
                            {
                                UserId = (int)Convert.ToInt64(Request.Cookies["User"].Value),
                                ItemName = item.ItemName,
                                Category = item.Category,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                Description = item.Description,
                                FileName = Path.GetFileName(file.FileName),
                                FileSize = file.ContentLength,
                                FileType = Path.GetExtension(file.FileName)?.TrimStart('.').ToLower(),
                                UploadDate = DateTime.Now
                            };

                            string uploadFolderPath = Server.MapPath(ConfigurationManager.AppSettings["ImagePath"]);
                            string folderPath = uploadFolderPath;

                            // Create the folder if it doesn't exist
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            string originalFileName = file.FileName;
                            string uniqueFileName = Guid.NewGuid().ToString();
                            string filePath = Path.Combine(uploadFolderPath, uniqueFileName + Path.GetExtension(originalFileName));

                            // Save the file without compression
                            file.SaveAs(filePath);

                            fileCopy.FilePath = Path.Combine("..\\Images", uniqueFileName + Path.GetExtension(originalFileName));
                            fileCopy.FileName = uniqueFileName;
                            var itemId = (int)Session["ItemId"];
                            con.EditItem(fileCopy,itemId);
                        }
                    }


                    return RedirectToAction("Index");

                }
            }
            return View();

        }

        [HttpPost]
        public ActionResult ClearOrder(int BuyerId, int ItemId)
        {
            bool res = con.ClearItemsOrder(BuyerId, ItemId);
            return Json(new { success = res });
        }
    }
}