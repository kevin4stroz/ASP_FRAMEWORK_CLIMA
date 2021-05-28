using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using PruebaTecnica.Datos;
using System.Data.Entity;

namespace PruebaTecnica.Controllers
{
    [Authorize]
    public class ClimaController : Controller
    {
        // GET: Clima
        public async Task<ActionResult> Index()
        {
            using( ClimaDbEntities dbCtx = new ClimaDbEntities())
            {
                ViewBag.ListaClimas = await dbCtx.Clima.ToListAsync();
            }

            return View();
        }

        // GET: Clima
        public ActionResult ModificarClima(int id)
        {
            return View();
        }


        // vista de clima
        [HttpGet]
        public ActionResult SetClima(int? id)
        {
            if (id == null)
                return View(new Clima());

            Clima clima = null;

            using(ClimaDbEntities dbCtx = new ClimaDbEntities())
            {
                clima = dbCtx.Clima.Find(id);
            }

            if (clima == null)
                clima = new Clima();

            return View(clima);
        }


        // actualizar o crear clima
        [HttpPost]
        public ActionResult SetClima(Clima clima)
        {

            if (ModelState.IsValid)
            {
                using(ClimaDbEntities dbCtx = new ClimaDbEntities())
                {
                    if(clima.ClimaId > 0)
                    {
                        Clima changeClima = dbCtx.Clima.Find(clima.ClimaId);

                        if (changeClima == null)
                            return RedirectToAction("Index");

                        changeClima.Localidad = clima.Localidad;
                        changeClima.Temperatura = clima.Temperatura;
                        changeClima.Trecipitaciones = clima.Trecipitaciones;
                        changeClima.Viento = clima.Viento;
                        changeClima.FechaCreacion = DateTime.Now;
                    }
                    else
                    {
                        clima.FechaCreacion = DateTime.Now;
                        dbCtx.Clima.Add(clima);
                    }

                    dbCtx.SaveChanges();

                }
            }

            return RedirectToAction("Index");

        }

        // Eliminar clima
        public async Task<ActionResult> EliminarClima(int id)
        {
            Clima clima = null;
            using (ClimaDbEntities dbCtx = new ClimaDbEntities())
            {
                clima = await dbCtx.Clima.FindAsync(id);
            

                if(clima != null)
                {
                    dbCtx.Clima.Remove(clima);
                    await dbCtx.SaveChangesAsync();
                }

            }
            return RedirectToAction("Index");
        }
    }
}