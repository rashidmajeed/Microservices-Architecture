using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Billing> Billings { get; set; }
        Task<int> SaveChanges();
    }
}
