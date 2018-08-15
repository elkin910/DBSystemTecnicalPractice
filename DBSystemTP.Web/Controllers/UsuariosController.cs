using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBSystemTP.Data;
using DBSystemTP.Entities.Models;
using DBSystemTP.Entities.ViewModels;

namespace DBSystemTP.Controllers
{
    public class UsuariosController : Controller
    {
        private DBSystemContext db = new DBSystemContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        [HttpGet]
        public ActionResult GetTiposIdentificacion()
        {
           IEnumerable<SelectListItem> tiposIdentificacion = db.TiposDocumentoes.AsNoTracking()
                        .OrderBy(n => n.Nombre)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.Id.ToString(),
                               Text = n.Nombre
                           }).ToList();
            var tiposidentificacion2 =  new SelectList(tiposIdentificacion, "Value", "Text");
            return Json(tiposidentificacion2, JsonRequestBehavior.AllowGet);
            
            
        }

        [HttpGet]
        public ActionResult GetDepartamentos(string paisSelectedParam)
        {

            int idpais = int.Parse(paisSelectedParam);
            IEnumerable<SelectListItem> Departamentos2 = db.Departamentos.AsNoTracking()
                         .OrderBy(n => n.Nombre)
                          .Where(n => n.PaisId == idpais)
                         .Select(n =>
                            new SelectListItem
                            {
                                Value = n.Id.ToString(),
                                Text = n.Nombre
                            }).ToList();
            var Departamentos = new SelectList(Departamentos2, "Value", "Text");
            return Json(Departamentos, JsonRequestBehavior.AllowGet);


        }


        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {

            List<SelectListItem> countries = db.Paises.AsNoTracking()
                       .OrderBy(n => n.Nombre)
                       .Select(n =>
                          new SelectListItem
                          {
                              Value = n.Id.ToString(),
                              Text = n.Nombre
                          }).ToList();
            var countrytip = new SelectListItem()
            {
                Value = null,
                Text = "--- Seleccione Pais ---"
            };
            countries.Insert(0, countrytip);

            var usuarioEditVM = new UsuarioEditViewModel()
            {

                //Departamentos = db.Departamentos.AsNoTracking()
                //        .OrderBy(n => n.Nombre)
                //        .Select(n =>
                //           new SelectListItem
                //           {
                //               Value = n.Id.ToString(),
                //               Text = n.Nombre
                //           }).ToList(),

             Departamentos =   new List<SelectListItem>()
                {
                    new SelectListItem
                    {
                        Value = null,
                        Text = " "
                     }
                 },


                

            Paises = countries,


                TiposIdentificacion = db.TiposDocumentoes.AsNoTracking()
                        .OrderBy(n => n.Nombre)
                        .Select(n =>
                           new SelectListItem
                           {
                               Value = n.Id.ToString(),
                               Text = n.Nombre
                           }).ToList()
                

            };
             return View(usuarioEditVM);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nombre,Direccion,FechaNacimiento,NumeroIdentificacion")] Usuario usuario)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Usuarios.Add(usuario);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(usuario);
        //}

        // POST: Usuario/Create
        [HttpPost]
        //public ActionResult Create([Bind(Include = "NombreUsuario, DireccionUsuario, FechaUsuario, IdentificacionUsuario, SelectedPais, SelectedDepartamento, SelectedCiudad")] UsuarioEditViewModel model)
        public ActionResult Create([Bind(Include = "NombreUsuario, DireccionUsuario, FechaUsuario, IdentificacionUsuario, SelectedTipoIdentificacion, SelectedPais, SelectedDepartamento")] UsuarioEditViewModel model)
        {
           
                if (ModelState.IsValid)
                {

                int tipoSeleccionado = Convert.ToInt32(model.SelectedTipoIdentificacion);

                Usuario usuario = new Usuario
                {

                    Nombre = model.NombreUsuario,
                    Direccion = model.DireccionUsuario,
                    FechaNacimiento = DateTime.Parse(model.FechaUsuario),
                    NumeroIdentificacion = model.IdentificacionUsuario,
                    TiposDocumento = db.TiposDocumentoes.FirstOrDefault(t => t.Id == tipoSeleccionado),
                    Ciudade = db.Ciudades.FirstOrDefault(c => c.Id == 1)
                    //Ciudade = db.Ciudades.FirstOrDefault(c => c.Id == int.Parse(model.SelectedCiudad))


                };

                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(model);


        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,FechaNacimiento,NumeroIdentificacion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
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
