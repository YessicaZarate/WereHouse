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
            //Products products = await db.Products.FindAsync(id);
            //if (products == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(products);
            DetailsVM model = new DetailsVM();
            Products prods = await db.Products.FindAsync(id);
            if (prods == null)
            {
                return HttpNotFound();
            }
            model.Item = prods.Item;
            model.Brand = prods.Brand;
            model.Description = prods.Description;
            model.Qty = prods.Qty;
            model.Cost = prods.Cost;
            model.Price = prods.Price;
            model.Country = prods.Country;
            model.Provider = prods.Provider;
            model.Warranty = prods.Warranty;
            model.DateAd = prods.DateAd;
            model.DateCr = prods.DateCr;
            model.DateUp = prods.DateUp;

            return View(model);

        }

        // GET: Products/Create
        public ActionResult Create()
        {
            CreateVM model = new CreateVM();
            return View(model);
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
                db.Products.Add(newProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(createVM);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Products products = await db.Products.FindAsync(id);
            //if (products == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(products);
            EditVM model = new EditVM();
            if (id == null)
            {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products prods = await db.Products.FindAsync(id);
            if (prods == null)
            {
                return HttpNotFound();
            }
            model.Item = prods.Item;
            model.Brand = prods.Brand;
            model.Description = prods.Description;
            model.Qty = prods.Qty;
            model.Cost = prods.Cost;
            model.Price = prods.Price;
            model.Country = prods.Country;
            model.Provider = prods.Provider;
            model.Warranty = prods.Warranty;
            model.DateAd = prods.DateAd;
            
         
            return View(model);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Brand,Description,Qty,Cost,Price,Country,Provider,Warranty,DateAd,DateCr,DateUp")] Products products)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(products).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(products);
        //}

        public async Task<ActionResult> Edit(EditVM model, int? id)
        {
            if (ModelState.IsValid)
            {
                Products exProd = await db.Products.FindAsync(id);
                if (exProd != null)
                {
                    exProd.Item = model.Item;
                    exProd.Brand = model.Brand;
                    exProd.Description = model.Description;
                    exProd.Qty = model.Qty;
                    exProd.Cost = model.Cost;
                    exProd.Price = model.Price;
                    exProd.Country = model.Country;
                    exProd.Provider = model.Provider;
                    exProd.Warranty = model.Warranty;
                    exProd.DateAd = model.DateAd;
                    exProd.DateUp = DateTimeOffset.Now;
                }
                else
                {
                    return HttpNotFound();
                }
                db.Entry(exProd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

         

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeleteVM model = new DeleteVM();
            Products prods = await db.Products.FindAsync(id);
            if (prods == null)
            {
                return HttpNotFound();
            }

            model.Item = prods.Item;
            model.Brand = prods.Brand;
            model.Description = prods.Description;
            model.Qty = prods.Qty;
            model.Cost = prods.Cost;
            model.Price = prods.Price;
            model.Country = prods.Country;
            model.Provider = prods.Provider;
            model.Warranty = prods.Warranty;
            model.DateAd = prods.DateAd;
            model.DateCr = prods.DateCr;
            model.DateUp = prods.DateUp;

            return View(model);
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
