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
        public ActionResult Details(string id)
        {
            Producto p = prodao.GetProductos().Find(pro => pro.CodProd == id);
            return View(p);
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
        public ActionResult EditProducto(string id)
        {
            Producto p = prodao.GetProductos().Find(pro => pro.CodProd == id);
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult EditProducto(string id, Producto pro)
        {
            try
            {
                if (ModelState.IsValid==true)
                {
                    TempData["mensaje"] = prodao.ActualizarProducto(pro);
                    return RedirectToAction("IndexProductos");

                }
            }
            catch(Exception ex)
            {
                ViewBag.mensaje =  ex.Message;
                
            }
            return View(pro);
        }

        // GET: Producto/Delete/5
        public ActionResult BorrarProducto(string id)
        {
            Producto p = prodao.GetProductos().Find(pro => pro.CodProd == id);
            return View(p);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult BorrarProducto(string id, FormCollection collection)
        {
            try
            {
                TempData["mensaje"] = prodao.EliminarProducto(id);

                return RedirectToAction("IndexProductos");
            }
            catch
            {
                return View();
            }
        }
    }
}
