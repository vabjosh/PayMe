using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.DBContext
{
    public class PaymentState
    {
        [ForeignKey("Id")]
        public Payment payment { get; set; }
        public string status { get; set; }
        public string details { get; set; }

        public int Id { get; set; }
    }
}
