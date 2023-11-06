using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.Enum;
using SanctionExpense.Core.Models.ViewModel;
using SanctionExpense.Core.Services;
using System.Security.Claims;

namespace SanctionExpense.Web.Areas.Employee.Controllers
{
    /// <summary>
    /// Burası kendim için not: area alanını koymazsak, sayfayı bulamıyor. Bunu fark etmediğim için 2 saat çözüm aradım. 
    /// </summary>
    [Area("Employee")]
    [Authorize(Roles =Roles.Employee +","+ Roles.Executive + "," + Roles.Accountant)]
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
            ExpenseViewModel expenseViewModel = new ExpenseViewModel(); 
            return View(expenseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ExpenseViewModel model)
        {

            model.Status = 2;
            model.Owner = User.FindFirstValue(ClaimTypes.Name) ;
            var mappedRequest = _mapper.Map<Expense>(model);
            if(await _expenseService.AddAsync(mappedRequest))
                return View();
            return BadRequest();
        }
    }
}
