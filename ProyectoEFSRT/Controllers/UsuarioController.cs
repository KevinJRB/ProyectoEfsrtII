using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoEFSRT.Models;
using ProyectoEFSRT.DAO;

namespace ProyectoEFSRT.Controllers
{
    public class UsuarioController : Controller
    {
        UsuariosDAO usdao = new UsuariosDAO();
        TipoUsuarioDAO tusdao = new TipoUsuarioDAO();

        // GET: Usuario
        public ActionResult IndexUsuario()
        {

            return View(usdao.GetUsuarios());
        }

        // GET: Usuario/Details/5
        public ActionResult DetalleUsuario(string id)
        {
            Usuario u = usdao.GetUsuarios().Find(us => us.CodUs ==id);
            return View(u);
        }

        // GET: Usuario/Create
        public ActionResult CreateUsuario()
        {
            Usuario neuve = new Usuario();
            ViewBag.tipou = new SelectList(tusdao.GetTiposUsuario(),"IdTpu", "NomTpu");
            return View(neuve);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult CreateUsuario(Usuario us)
        {
            try
            {
                if(ModelState.IsValid==true)
                {
                    TempData["mensaje"] = usdao.InsertarUsuario(us);
                }

                return RedirectToAction("IndexUsuario");
            }
            catch(Exception ex)
            {
                ViewBag.mensaje = ex.Message;

                ViewBag.tipou = new SelectList(tusdao.GetTiposUsuario(), "IdTpu", "NomTpu");

                return View(us);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult EditUsuario(string id)
        {
            Usuario u = usdao.GetUsuarios().Find(us => us.CodUs == id);
            ViewBag.tipou = new SelectList(tusdao.GetTiposUsuario(), "IdTpu", "NomTpu");

            return View(u);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult EditUsuario(string id, Usuario us)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    TempData["mensaje"] = usdao.ActualizarUsuario(us);
                    return RedirectToAction("IndexUsuario");

                }
            }
            catch(Exception ex)
            {
                ViewBag.mensaje = ex.Message;
                
            }
            ViewBag.tipou = new SelectList(tusdao.GetTiposUsuario(), "IdTpu", "NomTpu");

            return View(us);
        }

        // GET: Usuario/Delete/5
        public ActionResult DeleteUsuario(string id)
        {
            Usuario u = usdao.GetUsuarios().Find(us => us.CodUs == id);

            return View(u);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult DeleteUsuario(string id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    TempData["mensaje"] = usdao.EliminarUsuario(id);
                    return RedirectToAction("IndexUsuario");

                }

            }
            catch(Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            return View();

        }
        /////////////////////////////////////////Tipo Usuario
        public ActionResult IndexTUsuario()
        {
            return View(tusdao.GetTiposUsuario());

        }
        public ActionResult CreateTUsuario()
        {
            TipoUsuario neuve = new TipoUsuario();
            return View(neuve);
        }
        [HttpPost]
        public ActionResult CreateTUsuario(TipoUsuario tus)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    TempData["mensaje"] = tusdao.InsertarTipoUsuario(tus);
                }

                return RedirectToAction("IndexTUsuario");
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;

                return View(tus);
            }

        }
        public ActionResult EditTUsuario(int id)
        {
            TipoUsuario tu = tusdao.GetTiposUsuario().Find(tus => tus.IdTpu == id);

            return View(tu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult EditTUsuario(int id, TipoUsuario tus)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    TempData["mensaje"] = tusdao.ActualizarTipoUsuario(tus);
                    return RedirectToAction("IndexTUsuario");

                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;

            }

            return View(tus);
        }

        // GET: Usuario/Delete/5
        public ActionResult DeleteTUsuario(int id)
        {
            TipoUsuario tu = tusdao.GetTiposUsuario().Find(tus => tus.IdTpu == id);

            return View(tu);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult DeleteTUsuario(string id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    TempData["mensaje"] = tusdao.EliminarTipoUsuario(id);
                    return RedirectToAction("IndexTUsuario");

                }

            }
            catch (Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            return View();

        }
    }
}
