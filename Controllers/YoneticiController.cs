using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection.Metadata;
using Web_Vize_Proje.Models;

namespace Web_Vize_Proje.Controllers
{
	public class YoneticiController : Controller
	{
		UniWebSiteContext context = new UniWebSiteContext();
		EFDuyuruRepository duyuruRepository = new EFDuyuruRepository(new UniWebSiteContext());
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Duyurular()
		{
			var result = duyuruRepository.DuyurularıListele();
			return View(result);
		}
		[HttpGet]
        public IActionResult DuyuruGetir(int id=1)
        {
			//var result = context.Duyurular.Where(p => p.DuyuruID == id);
            var res = context.Duyurular.SingleOrDefault(p => p.DuyuruID == id);
            return View(res);
        }

        [HttpGet("/Yonetici/DuyuruSil/{duyuru_id}")]
        public IActionResult DuyuruSil(int duyuru_id)
		{
		
			var result = duyuruRepository.GetDuyuruById(duyuru_id);
			duyuruRepository.Duyurusil(result);
			return RedirectToAction("Duyurular");
		}

		[HttpPost]
		public IActionResult DuyuruDuzenle(Duyuru duyuru)
		{
			
			var a = duyuru.DuyuruTarihi; //Duyurunun ilk eklenme tarihini bu şekilde saklıyoruz ki bu tarihi kaybetmeyelim.

			//duyuru.DuyuruTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
		
            duyuruRepository.DuyuruDuzenle(duyuru);
			duyuru.DuyuruTarihi = a;
			return RedirectToAction("Duyurular");
			//Duyuru Güncelleme tarihi eklencek ve gösterilecek.
			
		}
        
		[HttpGet("/Yonetici/DuyuruDuzenle/{duyuru_id}")]
        public IActionResult DuyuruDuzenle(int duyuru_id)
        {
		
            var result = duyuruRepository.GetDuyuruById(duyuru_id);
            return View(result);
        }
   //     [HttpGet("/Yonetici/DuyuruDuzenle/")]
   //     public IActionResult DuyuruDuzenle()
   //     {

			//return RedirectToAction("Duyurular");
   //     }

        [HttpGet("/Yonetici/DuyuruEkle")]
		public IActionResult DuyuruEkle()
		{
			return View();
		}

        [HttpPost("/Yonetici/DuyuruEkle")]
        public IActionResult DuyuruEkle(Duyuru duyuru)
        {
            duyuru.DuyuruTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            duyuruRepository.DuyuruEkle(duyuru);
           
            return RedirectToAction("Duyurular");
        }

        [HttpGet]
        public IActionResult GirisYap()
        {

            return View();
        }


        [HttpPost]
		public IActionResult GirisYap(Yonetici yonetici)
		{
				var result=	context.Yoneticiler.SingleOrDefault(p => p.YoneticiKullanıcıAdi == yonetici.YoneticiKullanıcıAdi &&
				p.YoneticiSifre == yonetici.YoneticiSifre);
			//if (result.YoneticiKullanıcıAdi==yonetici.YoneticiKullanıcıAdi&&
			//	result.YoneticiSifre==yonetici.YoneticiSifre)
			if (result!=null)
			{
                return RedirectToAction("Duyurular");
            }
			
			else
			{
				//string message = "Hatalı giriş yaptınız "
                return View();
            }
			
		}
		
    }
}
