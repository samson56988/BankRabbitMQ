using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IEventBus _bus;
        private readonly ITransferRepository _transferRespository;

        public TransferService(IEventBus bus,ITransferRepository transfer)
        {
            _bus = bus;
            _transferRespository = transfer;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRespository.GetTransfers();
        }
    }
}
