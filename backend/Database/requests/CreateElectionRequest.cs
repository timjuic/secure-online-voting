using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.requests
{
    public class CreateElectionRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
