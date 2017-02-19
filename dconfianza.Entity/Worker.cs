using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dconfianza.Entity
{
    public class Worker
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public double Rating { get; set; }
        public string Resume { get; set; }
        public Boolean Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public string CreatedByFirstName { get; set; }
        public string CreatedByLastName { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
    }
}
