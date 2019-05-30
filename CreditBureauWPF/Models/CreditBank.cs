using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CreditBureauWPF.Models
{
    public class CreditBank
    {
        public int Id { get; set; }
        public string Bank { get; set; }
        public int Sum { get; set; }
        public int Percent { get; set; }
        public DateTime? Begin { get; set; }
        public string Mounth { get; set; }
        public bool Status { get; set; }
        public int Score { get; set; }
        public string Description { get; set; } 

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
