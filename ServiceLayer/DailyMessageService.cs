using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class DailyMessageService : IDailyMessageService
    {
        private DataLayer.MessageDataContext _ctx;
        private readonly ILogger<DailyMessageService> _logger;

        public DailyMessageService(ILogger<DailyMessageService> logger, DataLayer.MessageDataContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public DailyMessage GetTodaysMessage(DateTime today)
        {
            var todaysMessage = _ctx.Messages.FirstOrDefault(x => x.ShowOn == today);

            if(todaysMessage == null)
            {
                todaysMessage = _ctx.Messages.OrderByDescending(x => x.Created).First();
            }

            //Noting specifically configured so take the latest item
            var todaysDailyMessage = new DailyMessage
            {
                De = todaysMessage.De,
                EnGb = todaysMessage.EnGb,
                Fr = todaysMessage.Fr,
                ImageUrl = todaysMessage.ImageUrl
            };

            return todaysDailyMessage;
        }
    }
}
