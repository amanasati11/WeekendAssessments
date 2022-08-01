namespace Waffle_Shop.Models
{
    public interface IPieRepository
    {
        // Middle Page
        IEnumerable<Pie> AllPies { get; }
        // Home Page
        IEnumerable<Pie> PiesOfTheWeek { get; }
        // Details Page
        Pie GetPieById(int pieId);
        int UpdatePie(Pie pie);
        int CreatePie(Pie pie);
        int RemovePie(Pie pie);
    }
}
