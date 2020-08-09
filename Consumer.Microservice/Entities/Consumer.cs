using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Microservice.Entities
{
public class Consumer : BaseEntity
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
}
}
