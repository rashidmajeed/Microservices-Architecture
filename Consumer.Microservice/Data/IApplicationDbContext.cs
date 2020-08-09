using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Microservice.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Consumer> Consumers{ get; set; }
        Task<int> SaveChanges();
    }
}
