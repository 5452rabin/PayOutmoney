using Assignment.Models;
using Assignment.ViewModel;
using AutoMapper;

namespace Assignment.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile() {
            CreateMap<Rate, RateVM>().ReverseMap();
                
            CreateMap<Currency, CurrencyVM>().ReverseMap();
            CreateMap<TrasactionVM, Transaction>().ReverseMap();
        
        }
    }
}
