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
    public class WalletController : ControllerBase
    {

        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("my-wallet")]
        public async Task<IActionResult> GetMyWallet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var wallet = await _walletService.GetWalletByUserIdAsync(userId);

            if (wallet == null)
            { var errors = new List<FieldErrorDto>
                    {
                        new FieldErrorDto
                        {
                            Field = "id",
                            Message = $"Wallet for user {userId} not found."
                        }
                    };
                    return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Get wallet operation failed",
                statusCode: StatusCodes.Status404NotFound);
            }

            return Ok(wallet);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateWallet()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var wallet = await _walletService.CreateWalletAsync(userId);

            return Ok(wallet);
        }

        [HttpGet("balance")]
        public async Task<IActionResult> GetBalance()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var balance = await _walletService.GetBalanceAsync(userId);

            return Ok(new { Balance = balance });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteWallet()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var deleted = await _walletService.DeleteWalletAsync(userId);

                if (!deleted)
                {
                    var errors = new List<FieldErrorDto>
                        {
                           new FieldErrorDto
                           {
                                Field = "id",
                                Message = $"No Wallet found for this User"
                            }
                        };

                    return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Get Wallet operation failed",
                   statusCode: StatusCodes.Status404NotFound);

                }
                   

                return Ok("Wallet deleted successfully");
            }
            catch (Exception ex) { 
                  
                var errors = new List<FieldErrorDto>
                        {
                           new FieldErrorDto
                           {
                                Field = "wallet",
                                Message = $"Wallet operation failed"
                            }
                        };

                return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: " Wallet operation failed",
               statusCode: StatusCodes.Status400BadRequest);
            }

            
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetMyTransactions(  int pageNumber = 1,  int pageSize = 10)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var transactions = await _walletService  .GetTransactionsAsync(userId, pageNumber, pageSize);
            if (!transactions.Items.Any())
            {
                var errors = new List<FieldErrorDto>
                        {
                           new FieldErrorDto
                           {
                                Field = "transaction",
                                Message = $"No transactions found for this User"
                            }
                        };

                return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Get transactions operation failed",
               statusCode: StatusCodes.Status404NotFound);
            }


            return Ok(transactions);
        }

        [HttpGet("my-payments")]
        public async Task<IActionResult> GetMyPayments( int pageNumber = 1,  int pageSize = 10)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
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

          
            var result = await _walletService
                .GetPaymentsByClientIdAsync(userId, pageNumber, pageSize);
            if (!result.Items.Any())
            {
                var errors = new List<FieldErrorDto>
                        {
                           new FieldErrorDto
                           {
                                Field = " wallet transaction",
                                Message = $"No wallet transactions found for this User"
                            }
                        };

                return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Get wallet transactions operation failed",
               statusCode: StatusCodes.Status404NotFound);
            }
            return Ok(result);
        }


        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequestDto request)
        {
            var errors = new List<FieldErrorDto>();
            if (!ModelState.IsValid)
              { 

                return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "withdraw operation failed",
               statusCode: StatusCodes.Status400BadRequest);
            }
            

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var result = await _walletService.WithdrawAsync(userId, request,errors);

                if (errors.Any())
                {
                    return ErrorHelper.HandleErrors(this, serviceErrors: errors, message: "Withdraw operation failed");
                }
                return Ok(new
                {
                    message = "Withdrawal successful",
                    wallet = result
                });
            }
            catch (Exception ex)
            {
                 
                return ErrorHelper.HandleErrors(
                    this,
                    message: ex.Message,
                    statusCode: StatusCodes.Status400BadRequest
                );
            }
        }

    }
}
