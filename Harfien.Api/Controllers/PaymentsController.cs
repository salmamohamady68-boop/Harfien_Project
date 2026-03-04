using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using Harfien.Application.DTO.Error;
using Harfien.Application.DTO.Payment;
using Harfien.Application.Helpers;
using Harfien.Application.Interfaces.payment_interfaces;
using Harfien.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Harfien.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IWalletService _walletService;

        public PaymentsController(IPaymentService paymentService,IWalletService walletService)
        {
            _paymentService = paymentService;
            this._walletService = walletService;
        }


        [HttpPost("pay-card")]
        public async Task<IActionResult> PayWithCard([FromBody] CreatePaymentDto dto)
        {
            var errorslist = new List<FieldErrorDto>() ;
            string clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            if (string.IsNullOrEmpty(clientId))
       
            {
                var errors = new List<FieldErrorDto>
                {
                   new FieldErrorDto 
                   {
                        Field = "id",
                        Message = $"User not authenticated"
                    }
                };
          
                 return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Get user operation failed",
                statusCode: StatusCodes.Status401Unauthorized);
            }
        
        
     

        var result = await _paymentService.PayOrderWithCardAsync(dto, clientId);

            if (!ModelState.IsValid)
            {
                ErrorHelper.HandleErrors(this, errorslist, message: "payment operation failed");
            }
            if (!result.Success)
       
            {
                var errors = new List<FieldErrorDto>
                {
                   new FieldErrorDto
                   {
                        Field = "payment",
                        Message = $"{result.Message}"
                    }
                };

                return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Payment operation failed",
               statusCode: StatusCodes.Status400BadRequest);
            }
            var trans = await _walletService
          .GetPaymentsByClientIdAsync(clientId, 1, 1);

            var firstTransaction = trans.Items.FirstOrDefault();

            return Ok(new
            {
                paymentMessage = result.Message,
                Data = firstTransaction
            });
        }
    }
}
