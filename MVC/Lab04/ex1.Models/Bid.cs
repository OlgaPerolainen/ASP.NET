using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCreditApp.Models
{
    public class Bid
    {
        public virtual int BidId { get; set; }
        // Имя заявителя
        public virtual string ClientName { get; set; }
        // Название кредита
        public virtual string CreditHead { get; set; }
        // Дата подачи заявки
        public virtual DateTime bidDate { get; set; }
    }
}