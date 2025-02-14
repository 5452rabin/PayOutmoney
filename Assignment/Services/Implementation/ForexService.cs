using Assignment.Constraints;
using Assignment.Services.Interface;
using Assignment.ViewModel;
using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment.Services.Implementation
{
    
    public class ForexService : IForexService
    {
        

        private readonly HttpClient _httpclient;
        private readonly IMapper _mapper;

        public ForexService(HttpClient httpClient,IMapper mapper) 
        {
            _mapper = mapper;
            _httpclient = httpClient;
        }
        public async Task<List<RateVM>> GetAllRates()
        {
            string fromDate= DateTime.Today.ToString("yyyy-MM-dd");
            var response = await _httpclient.GetAsync($"https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from={fromDate}&to={fromDate}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);
            Console.Write(root.Data.Payload[0].Rates);

            List<RateVM> rates = _mapper.Map<List<RateVM>>(root.Data.Payload[0].Rates);
            foreach (var item in rates)
            {
                decimal unit=item.currency.unit;
                item.currency.unit = item.currency.unit / item.currency.unit;
                item.sell = item.sell / unit;
                item.buy=item.buy / unit;
            }

            return rates;

        }

        public RateVM GetRateByiso3(string iso3)
        {
            var rateVM = GetAllRates().Result[16];
            return rateVM;
        }
        
    }
}
