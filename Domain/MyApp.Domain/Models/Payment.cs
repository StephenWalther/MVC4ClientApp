using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Models {
    public class Payment {

        public int Id { get; set; }

        public string UserName { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateCreated { get; set; }

        // Complicated Domain Business Logic
        public decimal CalculateLatePenalty() {
            return Amount * 0.05m;
        }
    }
}
