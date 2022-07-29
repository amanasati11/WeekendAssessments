using AutoMapper;

namespace Waffle_Shop.Models
{
    public class PieProfile: Profile
    {
        public PieProfile()
        {
            this.CreateMap<Pie, PieMini>();
        }
    }
}
