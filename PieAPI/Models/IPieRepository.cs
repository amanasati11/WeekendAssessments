namespace PieAPI.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        // Home Page
        IEnumerable<Pie> PiesOfTheWeek { get; }
        // Details Page
        Pie GetPieById(int pieId);
    }
}
