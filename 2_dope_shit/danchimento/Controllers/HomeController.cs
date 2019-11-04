using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using danchimento.Models;
using MongoDB.Driver;
using danchimento.ViewModels;
using MongoDB.Bson;

namespace danchimento.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMongoCollection<DopeShit> _dopeShit;
        
        public HomeController(ILogger<HomeController> logger, IDopeShitDbSettings dbSettings)
        {
            _logger = logger;

            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _dopeShit = database.GetCollection<DopeShit>(dbSettings.DopeShitCollectionName);
        }

        public IActionResult Index()
        {
            var originalDopeShit =_dopeShit.Find(dopeShit => true);

            var dopeShitList = originalDopeShit.ToList();
            
            var dopeShitViewModelList = dopeShitList.Select(o => new DopeShitVm
            {
                Id = o.Id.ToString(),
                Name = o.Name
            }).ToList();

            return View(dopeShitViewModelList);
        }

        [HttpPost]
        public IActionResult Add(CreateDopeShitVm model)
        {
            var newDopeShit = new DopeShit
            {
                Id = ObjectId.GenerateNewId(),
                Name = model.DopeShit
            };

            _dopeShit.InsertOne(newDopeShit);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
