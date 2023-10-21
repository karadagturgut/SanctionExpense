using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanctionExpense.Core.Models.DTO;

namespace SanctionExpense.API.Controllers
{

    public class CustomBaseController : ControllerBase
    {

        [NonAction]
        public IActionResult CreateResponse<T>(CustomResponseDTO<T> responseDTO)
        {
            if (responseDTO.StatusCode==204)
            {
                return new ObjectResult(null) { StatusCode = responseDTO.StatusCode };
            }

            return new ObjectResult(responseDTO) ;

        }

    }
}
