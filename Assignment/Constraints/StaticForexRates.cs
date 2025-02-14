using Assignment.Services.Interface;
using Assignment.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Assignment.Constraints
{
    public static class StaticForexRates
    {

        public static List<RateVM> rateVMs { get; set; }
     
        
    }
}
