using Waffle_Shop.Models;

namespace Waffle_Shop.ViewModel
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }

    }
}
