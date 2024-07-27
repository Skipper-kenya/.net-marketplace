using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using marketplace1.Models;
using marketplace1.Context;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace marketplace1.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationContext db = new ApplicationContext();

       public List<Items> items = new List<Items>();

        public async Task<ActionResult> Index()
        {

            try
            {
                items = await db.Items.ToListAsync();

                if (items.Count > 1)
                {
                    var lastItem = items.Last();
                    items.RemoveAt(items.Count - 1);
                    items.Insert(0, lastItem);
                }

                return View(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View(items);
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(Items items)
        {
            try
            {
                db.Items.Add(items);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("Index", "Home");
            }

        }


        [HttpPost]
        public async Task<ActionResult> DeleteItem(int Id)
        {
            try
            {
                var itemTobeDeleted = await db.Items.FirstOrDefaultAsync(i => i.Id == Id);

                db.Items.Remove(itemTobeDeleted);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");

                Console.WriteLine(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<ActionResult> EditItemGet(int Id)
        {
            try
            {
                Items itemTobeEdited =await db.Items.FirstOrDefaultAsync(i => i.Id ==Id);

                return View(itemTobeEdited);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return View();

            }
        }

        [HttpPost]
        public async Task<ActionResult> EditItem(Items item)
        {
            try
            {
                Items itemTobeDeleted = await db.Items.FirstOrDefaultAsync(i => i.Id == item.Id);

                if (itemTobeDeleted != null)
                {

                    itemTobeDeleted.Name = item.Name;
                    itemTobeDeleted.Description = item.Description;
                    itemTobeDeleted.Price = item.Price;
                    itemTobeDeleted.Category = item.Category;

                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("Index", "Home");

              
            }
        }
    }
}