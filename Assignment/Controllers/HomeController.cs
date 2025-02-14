using Assignment.Constraints;
using Assignment.Models;
using Assignment.Services.Interface;
using Assignment.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IForexService _forexService;
        private readonly ITransactionService _transactionService;

        public HomeController(ILogger<HomeController> logger, IForexService forexService,ITransactionService transactionService)
        {
            
            _logger = logger;
            _forexService = forexService;
            _transactionService = transactionService;
          
        }
        
       
        public async Task<IActionResult> GetForexRateByiso3(string iso3)
        {
            var rateVM = _forexService.GetRateByiso3(iso3);
            return Json(rateVM);
        }
        [Authorize]
        public  IActionResult Index()
        {
            var model = new TrasactionVM();
            model.RateVM = _forexService.GetRateByiso3("MYR");
            model.ExchangeRate = model.RateVM.sell;
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Index(TrasactionVM trasactionVM)
        {
            trasactionVM.date=DateTime.Now;
            _transactionService.SaveTraction(trasactionVM);
            return RedirectToAction("Privacy","Home");
        }
        [Authorize]
        public IActionResult History() 
        {
            return View();
        }

        public async Task<IActionResult> GetTrasaction(string fromdate,string todate) {
            DateTime fromdat = DateTime.Parse(fromdate);
            DateTime todat = DateTime.Parse(todate);
            List<TrasactionVM> trasactionVMs=_transactionService.GetTrasactionVM(fromdat, todat);
            return Json(trasactionVMs);
        }
        public async Task<IActionResult> Privacy()
        {

      
            return View();

        }

        public IActionResult PrintReport(string fromdate, string todate)
        {
            DateTime fromdat = DateTime.Parse(fromdate);
            DateTime todat = DateTime.Parse(todate);

            ViewBag.FromDate = fromdate;
            ViewBag.ToDate = todate;

            List<TrasactionVM> trasactionVMs = _transactionService.GetTrasactionVM(fromdat, todat);

            return View("PrintReport", trasactionVMs); // Return the PrintReport view
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
