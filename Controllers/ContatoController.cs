using CondMVC.Context;
using CondMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CondMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Contatos = _context.Contatos.ToList();
            return View(Contatos);
        }

                public IActionResult Criar()
        {
                  return View();
        }
        
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
    }
}