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


        public Pie GetPieById(int pieId)
        {
            return AllPies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
