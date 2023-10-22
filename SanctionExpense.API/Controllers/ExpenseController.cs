using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.DTO;
using SanctionExpense.Core.Models.Enum;
using SanctionExpense.Core.Services;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SanctionExpense.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : CustomBaseController
    {
        #region ctor - initializing
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;
        public ExpenseController(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }
        #endregion

        #region GetAllExpenses

        /// <summary>
        /// Tüm masraf listesini getirir.
        /// </summary>
        /// <returns></returns>        
        [Authorize(Roles = nameof(Roles.Accountant))]
        [HttpGet("GetAllExpenses")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var getList = await _expenseService.GetAwaitingRequest();
            var listDTO = _mapper.Map<List<ExpenseDTO>>(getList).ToList();
            return CreateResponse(CustomResponseDTO<List<ExpenseDTO>>.Success(200,listDTO));
        }
        #endregion

        #region GetById
        /// <summary>
        /// Tek bir masrafı getiren endpoint.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expense= await _expenseService.GetByIdAsync(id);
            var expenseDTO = _mapper.Map<ExpenseDTO>(expense);
            return CreateResponse(CustomResponseDTO<ExpenseDTO>.Success(200, expenseDTO));
        }
        #endregion

        #region Add

        [HttpPost("Add")]
        // expense add dto gibi bi isimli bir nesne ile ekleme yapalım. bazı alanlar zorunlu değil ama swagger'da görünüyor.
        public async Task<IActionResult> Add(Expense request)
        {
            await _expenseService.AddAsync(request);
            return Ok();
        }
        #endregion

        #region Update
        /// <summary>
        /// ExpenseDTO nesnesi alarak güncelleme yapan endpoint. 
        /// Yeterli vakit bulabilirsem Patch metodu ile burasını ayırmak istiyorum.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost("Update")]
        public async Task<IActionResult> Update(Expense dto)
        {
            await _expenseService.UpdateAsync(dto);
            return Ok();
        }

        #endregion
    }
}
