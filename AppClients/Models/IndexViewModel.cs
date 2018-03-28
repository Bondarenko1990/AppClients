using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppClients.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}