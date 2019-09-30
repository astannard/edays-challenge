using System;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public interface IDailyMessageService
    {

        DailyMessage GetTodaysMessage(DateTime today);

    }

   
}
