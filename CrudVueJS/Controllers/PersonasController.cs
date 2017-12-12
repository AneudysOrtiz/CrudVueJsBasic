using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudVueJS.Models;
using CrudVueJS.DAL;
using System.Data.Entity;

namespace CrudVueJS.Controllers
{
    public class PersonasController : ApiController
    {
        GeneralContext db = new GeneralContext();

        public PersonasController() {
            

        }

        public IHttpActionResult Delete([FromBody]int id)
        {
            var pp = db.Personas.ToList().Find(x => x.IdPersona == id);
            db.Personas.Remove(pp);
            db.SaveChanges();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            var personas = db.Personas.ToList();


            return Json(personas);
        }

        public List<Personas> BuscarNombre(string text)
        {
            var result = from c in db.Personas
                         where
                c.Nombre.Contains(text)
                         select c;

            return result.ToList();
        }


        public List<Personas> BuscarApellido(string text)
        {
            var result = from c in db.Personas
                         where
                c.Apellido.Contains(text)
                         select c;

            return result.ToList();
        }


        public List<Personas> BuscarTelefono(string text)
        {
            var result = from c in db.Personas
                         where
                c.Telefono.Contains(text)
                         select c;

            return result.ToList();
        }

        public List<Personas> BuscarCorreo(string text)
        {
            var result = from c in db.Personas
                         where
                c.Correo.Contains(text)
                         select c;

            return result.ToList();
        }


        public IHttpActionResult Post([FromBody]Personas persona)
        {
            if (persona.status == "guardar")
            {
                db.Personas.Add(persona);
                db.SaveChanges();

            }else if (persona.status == "eliminar")
            {
                var pp = db.Personas.ToList().Find(x => x.IdPersona == persona.IdPersona);
                db.Personas.Remove(pp);
                db.SaveChanges();


            }else if (persona.status == "editar")
            {
                var pp = db.Personas.ToList().Find(x => x.IdPersona == persona.IdPersona);
                pp.Nombre = persona.Nombre;
                pp.Apellido = persona.Apellido;
                pp.Correo = persona.Correo;
                pp.Telefono = persona.Telefono;

                db.Entry(pp).State = EntityState.Modified;
                db.SaveChanges();

            }else if(persona.status == "buscar")
            {
                if (persona.Nombre == "id")
                {
                    persona.IdPersona = Convert.ToInt32(persona.Apellido);
                    var pp = db.Personas.ToList().Find(x => x.IdPersona == persona.IdPersona);

                    var list = new List<Personas>();

                    list.Add(pp);
                    return Json(list);

                }
                else if(persona.Nombre == "nombre")
                {
                    
                    var pp = BuscarNombre(persona.Apellido);

                    return Json(pp);

                }
                else if (persona.Nombre == "apellido")
                {

                    var pp = BuscarApellido(persona.Apellido);
                    return Json(pp);

                }
                else if (persona.Nombre == "correo")
                {
                    
                    var pp = BuscarCorreo(persona.Apellido);

                    return Json(pp);

                }
                else if (persona.Nombre == "telefono")
                {


                    var pp = BuscarTelefono(persona.Apellido);

                    return Json(pp);

                }



            }


            return Ok();
        }


    }
}
