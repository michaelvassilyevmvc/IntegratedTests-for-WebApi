using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryServiceApi.Interfaces;

namespace DeliveryServiceApi.Services
{
    public class OrderService : IOrderService
    {
        public bool IsFreeCourierAvailable()
        {
            return true;
        }
    }
}