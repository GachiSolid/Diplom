using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CreditBureauWPF.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Snils { get; set; }
        public string Familiya { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public string Gender { get; set; }
        public DateTime? Date { get; set; }
        public string User { get; set; }
    }
}
