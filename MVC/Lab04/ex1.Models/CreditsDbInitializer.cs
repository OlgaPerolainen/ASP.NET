using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcCreditApp.Models
{
    public class CreditsDbInitializer : DropCreateDatabaseIfModelChanges<CreditContext>
    {
        protected override void Seed(CreditContext context)
        {
            context.Credits.Add(new Credit { Head = "Ипотечный кредит", Period = 10, MaxSum = 1000000, Rate = 15 });
            context.Credits.Add(new Credit { Head = "Образовательный кредит", Period = 7, MaxSum = 300000, Rate = 10 });
            context.Credits.Add(new Credit { Head = "Потребительский кредит", Period = 5, MaxSum = 500000, Rate = 19 });

            base.Seed(context);
        }
    }
}