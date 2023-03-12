using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }
    }
}