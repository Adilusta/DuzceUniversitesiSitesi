using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_Vize_Proje.Models;

namespace Web_Vize_Proje.Controllers
{
    public class DuyuruController : Controller

    {
        UniWebSiteContext context = new UniWebSiteContext();    
        EFDuyuruRepository duyuruRepository = new EFDuyuruRepository(new UniWebSiteContext());

        public IActionResult Index()
        {
            var veriler = duyuruRepository.DuyurularıListele();
            return View(veriler);
        }
        public IActionResult Duyurular()
        {

            //var veriler = duyuruRepository.DuyurularıListele();

            //Eklediğimiz duyurular normal sırada geliyordu yani ilk başta en eski eklediğimiz duyuru geliyordu.
            // O yüzden de OrderByDescending yaparak en yeni duyuruların başta gelmesini sağladık.
            var a = context.Duyurular.OrderByDescending(p => p.DuyuruTarihi);
            return View(a);

        }

        [HttpGet("/Duyuru/DuyuruDetayi/{duyuru_id}")]
        public IActionResult DuyuruDetayi(int duyuru_id)
        {
            //ViewBag.DuyuruID = duyuru_id;
        
            var result = duyuruRepository.GetDuyuruById(duyuru_id);

            return View(result);
        }


       
    }
}
