using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dconfianza.Entity
{
    public class WorkerReview
    {
        public int ID { get; set; }
        public int WorkerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Review { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public string CreatedByFirstName { get; set; }
        public string CreatedByLastName { get; set; }

    }
}
