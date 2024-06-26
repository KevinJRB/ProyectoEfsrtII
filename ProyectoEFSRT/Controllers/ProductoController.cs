using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoEFSRT.Models;
using ProyectoEFSRT.DAO;

namespace ProyectoEFSRT.Controllers
{
    public class ProductoController : Controller
    {
        ProductosDAO prodao = new ProductosDAO();


        // GET: Producto
        public ActionResult IndexProductos()
        {

            return View(prodao.GetProductos());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult CreateProducto()
        {
            Producto nprod = new Producto();

            return View(nprod);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult CreateProducto(Producto prod)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    TempData["mensaje"]=prodao.InsertarProducto(prod);
                }

                return RedirectToAction("IndexProductos");
            }
            catch(Exception ex)
            {
                ViewBag.mensaje=ex.Message;
                return View(prod);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
