using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WereHouse.Models;
using WereHouse.ViewModels;

namespace WereHouse.Controllers
{
    public class ProductsController : Controller
    {
        private WereHouseContext db = new WereHouseContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            //return View(await db.Products.ToListAsync());
            IEnumerable<Products> prods = await db.Products.ToListAsync();
            List<IndexVM> IndexList = new List<IndexVM>();
            foreach(var prod in prods)
            {
                IndexVM allInd = new IndexVM()
                {
                    Id = prod.Id,
                    Item = prod.Item,
                    Brand = prod.Brand,
                    Description = prod.Description,
                    Qty = prod.Qty,
                    Cost = prod.Cost,
                    Price = prod.Price
                };
                IndexList.Add(allInd);
            }
            return View(IndexList);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = await db.Products.FindAsync(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            CreateVM model = new CreateVM();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateVM createVM)
        {
            if (ModelState.IsValid)
            {
                //db.Products.Add(products);
                //await db.SaveChangesAsync();
                //return RedirectToAction("Index");
                Products newProduct = new Products()
                {
                    Id = createVM.Id,
                    Item = createVM.Item,
                    Brand = createVM.Brand,
                    Description = createVM.Description,
                    Qty = createVM.Qty,
                    Cost = createVM.Cost,
                    Price = createVM.Price,
                    Country = createVM.Country,
                    Provider = createVM.Provider,
                    Warranty = createVM.Warranty,
                    DateAd = createVM.DateAd,
                    DateCr = DateTimeOffset.Now
                };
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(createVM);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = await db.Products.FindAsync(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Brand,Description,Qty,Cost,Price,Country,Provider,Warranty,DateAd,DateCr,DateUp")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = await db.Products.FindAsync(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Products products = await db.Products.FindAsync(id);
            db.Products.Remove(products);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
