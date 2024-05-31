using CatalogoApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ContextBaseDados _contextBaseDados;

        public CatalogoController(ContextBaseDados contextBaseDados)
        {
            _contextBaseDados = contextBaseDados;
        }
        public IActionResult ListaCatalogo()
        {
            var catalogo = _contextBaseDados.Catalogo.ToList();

            return View(catalogo);
        }

        public IActionResult NovoCatalogo()
        {
            return View();
        }

        public IActionResult NovoCatalogo(Catalogo catalogo)
        {
            return View();
        }
    }
}
