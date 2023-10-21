using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.Enum;
using SanctionExpense.Core.Services;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SanctionExpense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }



        /// <summary>
        /// Tüm masraf listesini getirir.
        /// </summary>
        /// <returns></returns>
        // GET: api/<ExpenseController>

        
        [Authorize (Roles = nameof(Roles.Accountant))]
        [HttpGet]
        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await _expenseService.GetAllAsync();
        }

        /// <summary>
        /// Tek bir masrafı getiren endpoint.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}")]
        public async Task<Expense> GetById(int id)
        {
            return await _expenseService.GetByIdAsync(id);
        }

        
        [HttpPost]
        public  void Post(Expense request)
        {
            _expenseService.AddAsync(request);
       
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPatch]
        public async Task<bool> UpdateStatus(int id)
        {
            //var updateStatus = _

            return true;
        }
    }
}
