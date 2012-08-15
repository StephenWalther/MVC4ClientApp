using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Persistence.EF.Infrastructure {
    internal class DatabaseInitializer:DropCreateDatabaseAlways<DataContext> {

        protected override void Seed(DataContext context) {
            var payments = new List<Payment> {
                new Payment {
                    UserName="Stephen",
                    Amount=200.23m, 
                    DateCreated= DateTime.Parse("1/13/2007")
                },
                new Payment {
                    UserName="Stephen",
                    Amount=78.02m, 
                    DateCreated= DateTime.Parse("3/10/2007")
                },
                new Payment {
                    UserName="Stephen",
                    Amount=500.01m, 
                    DateCreated= DateTime.Parse("2/24/2008")
                }
            };

            payments.ForEach(p => context.Payments.Add(p));
        }
    }
}
