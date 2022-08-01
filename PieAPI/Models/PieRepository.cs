using Microsoft.EntityFrameworkCore;

namespace PieAPI.Models
{

    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Pie> AllPies => appDbContext.Pies.Include(c=> c.Category);

        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek).Include(c => c.Category);

        public Pie DeletePie(int pieID)
        {
            var DeletePie = AllPies.FirstOrDefault(pie => pie.PieId == pieID);
            var entry = this.appDbContext.Pies.Remove(DeletePie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Pie InsertPie(Pie pie)
        {
            var PieInsert = this.appDbContext.Pies.Add(pie);
            this.appDbContext.SaveChanges();
            return PieInsert.Entity;
        }

        public Pie UpdatePie(Pie pie)
        {
            var UpdatedPie = this.appDbContext.Pies.Update(pie);
            this.appDbContext.SaveChanges();
            return UpdatedPie.Entity;
        }
    }
}
