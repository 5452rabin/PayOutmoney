using Assignment.ViewModel;

namespace Assignment.Services.Interface
{
   public  interface  IForexService
    {
        Task<List<RateVM>> GetAllRates();
        RateVM GetRateByiso3(string iso3);
    }
}
