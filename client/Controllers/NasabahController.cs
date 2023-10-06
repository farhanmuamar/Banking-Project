using Microsoft.AspNetCore.Mvc;
using client.Models;

namespace client.Controllers
{
    public class NasabahController : Controller
    {
        private readonly APIGateway _apiGateway;

        public NasabahController(APIGateway apiGateway)
        {
            _apiGateway = apiGateway;
        }
        public IActionResult Index()
        {
            List<NasabahModel> nasabah;
            nasabah = _apiGateway.ListNasabah();
            return View(nasabah);
        }

        [HttpGet]
        public IActionResult Create()
        {
            NasabahModel nasabah = new NasabahModel();
            return View(nasabah);
        }

        [HttpPost]
        public IActionResult create(NasabahModel nasabah)
        {
            _apiGateway.CreateNasabah(nasabah);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            NasabahModel nasabah;
            nasabah = _apiGateway.GetNasabah(id);
            
            return View(nasabah);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            NasabahModel nasabah;
            nasabah = _apiGateway.GetNasabah(id);

            return View(nasabah);
        }

        [HttpPost]
        public IActionResult Edit(NasabahModel nasabah)
        {
            _apiGateway.UpdateNasabah(nasabah);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            NasabahModel nasabah;
            nasabah = _apiGateway.GetNasabah(id);

            return View(nasabah);
        }

        [HttpPost]
        public IActionResult Delete(NasabahModel nasabah)
        {
            _apiGateway.DeleteNasabah(nasabah.AccountId);
            return RedirectToAction("Index");
        }
    }
}