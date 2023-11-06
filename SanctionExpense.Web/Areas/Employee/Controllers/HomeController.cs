using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.ViewModel;
using SanctionExpense.Core.Services;

namespace SanctionExpense.Web.Areas.Employee.Controllers
{
    /// <summary>
    /// Burası kendim için not: area alanını koymazsak, sayfayı bulamıyor. Bunu fark etmediğim için 2 saat çözüm aradım. 
    /// </summary>
    [Area("Employee")]
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExpenseService _expenseService;

        public HomeController(IMapper mapper, IExpenseService expenseService)
        {
            _mapper = mapper;
            _expenseService = expenseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ExpenseViewModel model)
        {
            ExpenseResponseModel expenseResponseModel = new ExpenseResponseModel();
            model.Status = 2;
            var mappedRequest = _mapper.Map<Expense>(model);
            await _expenseService.AddAsync(mappedRequest);
            return View(expenseResponseModel);
        }
    }
}
