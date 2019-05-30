using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CreditBureauWPF.Models
{
    public class Appeal
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime? Date { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
