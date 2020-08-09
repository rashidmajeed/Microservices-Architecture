using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Microservice.Entities
{
    public class Billing : BaseEntity
    {
        public string Utility { get; set; }
        public string Provider { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
}
