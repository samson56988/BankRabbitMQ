using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _transferDbContext;

        public TransferRepository(TransferDbContext context)
        {
            _transferDbContext =  context;
        }

        public IEnumerable<TransferLog> GetTransfers()
        {
            return _transferDbContext.Transfers;
        }
    }
}
