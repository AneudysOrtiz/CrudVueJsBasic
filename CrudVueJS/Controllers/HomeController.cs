using CrudVueJS.DAL;
using CrudVueJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudVueJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        GeneralContext db = new GeneralContext();



        [HttpPost]
        void Guardar(string nombre, string apellido, string correo, string telefono)
        {
            Personas persona = new Personas();
            persona.Nombre = nombre;
            persona.Apellido = apellido;
            persona.Correo = correo;
            persona.Telefono = telefono;

            db.Personas.Add(persona);
            db.SaveChanges();

            Mostrar();

        }


        public List<Personas> Mostrar()
        {
            var personas = db.Personas.ToList();
            return personas;
        }


    }
}
