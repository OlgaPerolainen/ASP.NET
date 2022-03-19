using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCreditApp.Models
{
    public class Credit
    {
        public virtual int CreditId { get; set; }
        // Навзвание
        public virtual string Head { get; set; }
        // Период, на который выдается кредит
        public virtual int Period { get; set; }
        // Максимальная сумма кредита
        public virtual int MaxSum { get; set; }
        // Процентная ставка
        public virtual int Rate { get; set; }
    }
}