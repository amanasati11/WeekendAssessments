namespace PieAPI.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        // Home Page
        IEnumerable<Pie> PiesOfTheWeek { get; }
        // Details Page
        //Pie GetPieById(int pieId);
        Pie InsertPie(Pie pie);
        Pie UpdatePie(Pie pie);
        Pie DeletePie(int pieID);
    }
}
