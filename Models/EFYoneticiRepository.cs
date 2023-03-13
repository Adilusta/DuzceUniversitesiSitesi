using System.Collections.Generic;
using System.Linq;

namespace Web_Vize_Proje.Models
{
    public class EFYoneticiRepository
    {
        private UniWebSiteContext _context;
        public EFYoneticiRepository(UniWebSiteContext context)
        {
            this._context = context;
        }
        public  IQueryable<Yonetici> YoneticileriListele()
        {
            var result= _context.Yoneticiler;
            return result;
           
        }
        

    }
}
