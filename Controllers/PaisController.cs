using Microsoft.AspNetCore.Mvc;
using PracticoDotNet.Data;
using PracticoDotNet.Models;

namespace PracticoDotNet.Controllers
{
    public class PaisController : Controller
    {
        private readonly AppDbContext _db;
        public PaisController(AppDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Pais> listadoPaises = _db.Paises.ToList();
            return View(listadoPaises);
        }

        public IActionResult CrearPais()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearPais(Pais p)
        {
            if (ModelState.IsValid)
            {
                _db.Paises.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ModificarPais(int? id)
        {
            if (id==null || id==0) {
                NotFound();
            }
            Pais? PaisMod = _db.Paises.Find(id);  //Find solo funciona con PK como parámetro

            //otras formas de encontrar un objeto
            //Pais PaisMod1 = _db.Paises.FirstOrDefault(u=>u.id==id);  FirstOrDefault funciona con cualquier atributo
            //Pais PaisMod1 = _db.Paises.Where(u=>u.id==id).FirstOrDefault();
            
            if (PaisMod == null)
            {
                return NotFound();
            }
            return View(PaisMod);
        }

        [HttpPost]
        public IActionResult ModificarPais(Pais p)
        {
            if (ModelState.IsValid) {
                _db.Paises.Update(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EliminarPais(int? id)
        {
            if (id == null || id == 0)
            {
                NotFound();
            }
            Pais? PaisDel = _db.Paises.Find(id);

            if (PaisDel == null)
            {
                return NotFound();
            }
            return View(PaisDel);
        }

        [HttpPost, ActionName("EliminarPais")]
        public IActionResult EliminarPaisPOST(int? id)
        {
            Pais? p = _db.Paises.Find(id);
            if (p == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Paises.Remove(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
