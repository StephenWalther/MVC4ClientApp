using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Models {
    public class PaymentDTO {
        public int Id { get; set; }

        public Decimal Amount { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
