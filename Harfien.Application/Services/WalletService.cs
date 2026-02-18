using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Harfien.Application.DTO.Payment;
using Harfien.Application.Interfaces.payment_interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Interface_Repository.Repositories;
using Harfien.Domain.Shared;
using Harfien.Domain.Shared.Repositories;

namespace Harfien.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWalletTransactionRepository _transactionRepository;

        public WalletService(
            IWalletRepository walletRepo, IUserRepository userRepo,  IMapper mapper,IWalletTransactionRepository transactionRepository)
        {
            _walletRepo = walletRepo;
            _userRepo = userRepo;
            _mapper = mapper;
            this._transactionRepository = transactionRepository;
        }

        
        public async Task<WalletDto> GetWalletByUserIdAsync(string userId)
        {
            var wallet = await _walletRepo
                .GetByUserIdWithTransactionsAsync(userId);

            if (wallet == null)
                return null;

            var walletDto = _mapper.Map<WalletDto>(wallet);

            walletDto.Transactions = walletDto.Transactions?
                .OrderByDescending(t => t.CreatedAt)
                .ToList();

            return walletDto;
        }

      
        public async Task<WalletDto> CreateWalletAsync(string userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var existingWallet = await _walletRepo.GetByUserIdAsync(userId);
           
                if (existingWallet != null)
                    return _mapper.Map<WalletDto>(existingWallet);

            var wallet = new Wallet
            {
                UserId = userId,
                Balance = 0,
                IsActive = true,
                Transactions = new List<WalletTransaction>()
            };

            await _walletRepo.AddAsync(wallet);
            await _walletRepo.SaveAsync();

            return _mapper.Map<WalletDto>(wallet);
        }

         
        public async Task<decimal> GetBalanceAsync(string userId)
        {
            var wallet = await _walletRepo.GetByUserIdAsync(userId);

            if (wallet == null)
                throw new Exception("Wallet not found");

            return wallet.Balance;
        }

        
        public async Task<bool> DeleteWalletAsync(string userId)
        {
            var wallet = await _walletRepo
                .GetByUserIdWithTransactionsAsync(userId);

            if (wallet == null)
                return false;

            if (wallet.Balance != 0)
                throw new Exception("Cannot delete wallet with remaining balance");

            _walletRepo.Delete(wallet);

            await _walletRepo.SaveAsync();

            return true;
        }

        public async Task<PagedResult<WalletTransactionDto>> GetTransactionsAsync(
     string userId, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(userId))
                throw new Exception("Invalid user");

            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0 || pageSize > 50) pageSize = 10;

            var skip = (pageNumber - 1) * pageSize;
 
            var totalCount = await _transactionRepository.GetTransactionsCountByUserIdAsync(userId);

           
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync (userId, skip, pageSize);

            var result = new PagedResult<WalletTransactionDto>
            {
                Items = _mapper.Map<List<WalletTransactionDto>>(transactions),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            return result;
        }


    }
}
