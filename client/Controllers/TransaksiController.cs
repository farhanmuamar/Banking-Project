using Microsoft.AspNetCore.Mvc;
using client.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace client.Controllers
{
    public class TransaksiController : Controller
    {
        private readonly APIGateway _apiGateway;
        
        public TransaksiController(APIGateway apiGateway)
        {
            _apiGateway = apiGateway;
        }
        public IActionResult Index()
        {
            List<TransaksiModel> transaksi;
            transaksi = _apiGateway.ListTransaksi();
            return View(transaksi);
        }

        [HttpGet]
        public IActionResult Create()
        {
            TransaksiModel transaksi = new TransaksiModel();

            NasabahModel lnasabah = new NasabahModel();
            var nasabah = new SelectList(_apiGateway.ListNasabah().OrderBy(n => n.AccountId)
                .ToDictionary(us => us.AccountId, us => us.Name), "Key", "Value");
            ViewBag.Nasabah = nasabah;

            return View(transaksi);
        }

        [HttpPost]
        public IActionResult Create(TransaksiModel transaksi)
        {
            _apiGateway.CreateTransaksi(transaksi);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            TransaksiModel transaksi;
            transaksi = _apiGateway.GetTransaksi(id);
            
            return View(transaksi);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TransaksiModel transaksi;
            transaksi = _apiGateway.GetTransaksi(id);

            return View(transaksi);
        }

        [HttpPost]
        public IActionResult Edit(TransaksiModel transaksi)
        {
            _apiGateway.UpdateTransaksi(transaksi);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TransaksiModel transaksi;
            transaksi = _apiGateway.GetTransaksi(id);

            return View(transaksi);
        }

        [HttpPost]
        public IActionResult Delete(TransaksiModel transaksi)
        {
            _apiGateway.DeleteTransaksi(transaksi.Id);
            return RedirectToAction("Index");
        }
    }
}