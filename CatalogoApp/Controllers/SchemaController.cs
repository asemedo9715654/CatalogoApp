using CatalogoApp.Service;

using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Controllers
{
    public class SchemaController : Controller
    {
        private readonly SchemaService _schemaService;

        public SchemaController()
        {
            var connectionString = "Data Source=ANGELOS-PT11\\SQLEXPRESS; Initial Catalog=SGASTIF;Trusted_Connection=True;MultipleActiveResultSets=true";

            _schemaService = new SchemaService(connectionString);
        }

        public ActionResult Index()
        {
            var schema = _schemaService.GetDatabaseSchema();
            return View(schema);
        }
    }
}
