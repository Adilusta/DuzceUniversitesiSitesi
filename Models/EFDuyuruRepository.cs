using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Web_Vize_Proje.Models
{
    public class EFDuyuruRepository
    {
        private UniWebSiteContext _context;
        public EFDuyuruRepository(UniWebSiteContext context)
        {
            this._context = context;
        }
        public IQueryable<Duyuru> DuyurularıListele()
        {
            var result = _context.Duyurular;
            return result;

        }
        public Duyuru GetDuyuruById(int duyuru_id)
        {
            

            var result = _context.Set<Duyuru>().Find(duyuru_id);
            //var a = _context.Duyurular.Select(p=> p.DuyuruID==duyuru_id).
            return result;

        }
        public void Duyurusil(Duyuru duyuru)
        {
            _context.Remove(duyuru);
            _context.SaveChanges();
           
        }
        public void DuyuruDuzenle(Duyuru duyuru)
        {
            _context.Update(duyuru);
            _context.SaveChanges();
        }

        public void DuyuruEkle(Duyuru duyuru)
        {
            _context.Add(duyuru);
            _context.SaveChanges();
        }
    }
}
