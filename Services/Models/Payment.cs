using System;
using System.Collections.Generic;

namespace Services.Models
{
    public partial class Payment
    {
        public int ReceiptNumber { get; set; }
        public string? EmployeeNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? AccountNumber { get; set; }
        public double? AmountCharged { get; set; }
        public double? TaxRate { get; set; }

        public virtual Customer? AccountNumberNavigation { get; set; }
        public virtual Employee? EmployeeNumberNavigation { get; set; }
    }
}
