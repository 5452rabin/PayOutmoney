using Assignment.ViewModel;

namespace Assignment.Services.Interface
{
    public interface ITransactionService
    {
        void SaveTraction(TrasactionVM trasactionVM);
        List<TrasactionVM> GetTrasactionVM(DateTime fromdate,DateTime todate);

        TrasactionVM GetTrasactionVM(int id);
    }
}
