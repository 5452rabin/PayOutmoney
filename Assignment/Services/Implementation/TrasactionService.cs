using Assignment.Areas.Identity.Data;
using Assignment.GenericRepository.Implementation;
using Assignment.GenericRepository.Interface;
using Assignment.Models;
using Assignment.Services.Interface;
using Assignment.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using System.Threading.Tasks;
namespace Assignment.Services.Implementation
{
    public class TrasactionService : ITransactionService
    {

        private readonly UserManager<AssignmentUser> _userManager;
        private readonly SignInManager<AssignmentUser> _signInManager;


        private IMapper _mapper;
        private readonly IGenericRepository<Transaction> _genericRepo;
        public TrasactionService(IMapper mapper, IGenericRepository<Transaction> genericRepo, UserManager<AssignmentUser> userManager, SignInManager<AssignmentUser> signInManager) {

            _signInManager=signInManager;
            _userManager=userManager;
            _genericRepo = genericRepo;   
            _mapper = mapper;
        }
        public List<TrasactionVM> GetTrasactionVM(DateTime fromdate, DateTime todate)
        {
            string userid = _userManager.GetUserId(_signInManager.Context.User);
            List<Transaction> transactions = _genericRepo.GetAll().Where(x => x.date >= fromdate && x.date <= todate && x.UserId==userid).ToList();
            List<TrasactionVM> trasactionVMs = _mapper.Map<List<TrasactionVM>>(transactions);
            return trasactionVMs;
        }

        public TrasactionVM GetTrasactionVM(int id)
        {
            throw new NotImplementedException();
        }

        public async void SaveTraction(TrasactionVM trasactionVM)
        {
           Transaction transaction=_mapper.Map<Transaction>(trasactionVM);
            transaction=_genericRepo.Add(transaction);


        }
    }
}
