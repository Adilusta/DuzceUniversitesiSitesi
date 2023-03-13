using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_Vize_Proje.Models;

namespace Web_Vize_Proje.ViewComponents
{
    public class SonDuyurularViewComponent : ViewComponent
    {
        UniWebSiteContext _context = new UniWebSiteContext();
        //public SonDuyurularViewComponent(UniWebSiteContext context)
        //{
        //    this._context = context;
        //}

        public IViewComponentResult Invoke()
        {
            //var sonDuyurular = _context.Duyurular.ToList().TakeLast(3);   Bu satır son 3 duyuruyu getirir ama sıralamayı eskiden yeniye doğru yapar
            var sonDuyurular = _context.Duyurular.ToList().TakeLast(3).Reverse(); //Bu satır ise sıralamayı yeniden eskiye doğru yapar.
            return View(sonDuyurular);
        }


    }
}
