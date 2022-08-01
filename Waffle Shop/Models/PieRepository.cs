using Microsoft.EntityFrameworkCore;

namespace Waffle_Shop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies => appDbContext.Pies.Include(c => c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek).Include(c => c.Category);

        public int CreatePie(Pie pie)
        {
            appDbContext.Pies.Add(pie);
            return appDbContext.SaveChanges();
        }

        public Pie GetPieById(int pieId)
        {
            return AllPies.FirstOrDefault(p => p.PieId == pieId);
        }

        public int RemovePie(Pie pie)
        {
            appDbContext.Pies.Remove(pie);
            return appDbContext.SaveChanges();
        }

        public int UpdatePie(Pie pie)
        {
            appDbContext.Pies.Update(pie);
            return appDbContext.SaveChanges();
        }
    }
}
