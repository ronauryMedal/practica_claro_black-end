using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibroWebService.Models;

namespace LibroWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        [HttpGet]
        public IActionResult GETLibros()
        {
            using (DBLibrosContext db = new DBLibrosContext())
            {
                var respon = new Response();
                try
                {
                    var libros = db.Libro.OrderByDescending(a=>a.Id).ToList();
                    respon.status = 1;
                    respon.mensaje = "success";
                    respon.data = libros;
                }
                catch (Exception error)
                {
                    respon.status = 0;
                    respon.mensaje = error.ToString();
                }
                return Ok(respon);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GETLibrosID(int id)
        {

            var respon = new Response();

            using (DBLibrosContext db = new DBLibrosContext())
            {
                try
                {
                    // Libro libro = db.Libro.Where(a => a.Id == id).ToList();
                    var libro = db.Libro.Where(a => a.Id == id).ToList();
                    respon.status = 1;
                    respon.mensaje = "success";
                    respon.data = libro;
                }
                catch (Exception error)
                {
                    respon.status = 0;
                    respon.mensaje = error.ToString();
                }
            }
            return Ok(respon);

        }


        [HttpPost]

        public IActionResult addLibro(Libro Rlibro)
        {
                var respon = new Response();
            using (var db = new DBLibrosContext())
            {
                try
                {
                    //var DBlibro = new Libro();
                    //DBlibro = Rlibro;
                    db.Libro.Add(Rlibro);
                    db.SaveChanges();
                    respon.status = 1;
                    respon.mensaje = "success";
                }
                catch (Exception error)
                {

                    respon.status = 0;
                    respon.mensaje = error.Message;
                }
            }

            return Ok(respon);
        }

        [HttpPut]

        public IActionResult update(Libro updatelibro)
        {
            using (DBLibrosContext db = new DBLibrosContext())
            {
                var respon = new Response();
                try
                {
                    Libro libro = db.Libro.Where(a => a.Id == updatelibro.Id).FirstOrDefault();
                    libro.Titulo = updatelibro.Titulo;
                    libro.Descripcion = updatelibro.Descripcion;
                    libro.Autor = updatelibro.Autor;
                    libro.Editora = updatelibro.Editora;
                    db.Libro.Add(libro);
                    db.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respon.status = 1;
                    respon.mensaje = "success";
                }
                catch (Exception error)
                {
                    respon.status = 0;
                    respon.mensaje = error.ToString();
                }
                    return Ok(respon);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult delete(int id)
        {
            var respon = new Response();

            using (DBLibrosContext db = new DBLibrosContext())
            {
                try
                {
                    Libro libro = db.Libro.Find(id);
                    db.Remove(libro);
                    db.SaveChanges();
                    respon.status = 1;
                    respon.mensaje = "success";
                }
                catch (Exception error )
                {
                    respon.status = 0;
                    respon.mensaje = error.ToString();

                }
            }
            return Ok(respon);
        }

       
    }
}
