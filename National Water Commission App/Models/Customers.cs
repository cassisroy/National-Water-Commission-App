using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Water_Commission_App.Models
{
    [Table("customers")]
    public class Customers1 : BaseEntity
    {
        public string FirstName1 { get; set; }
        public string LastName1 { get; set; }
        public string Address1 { get; set; }
        public string Telephone1 { get; set; }
        public string TRN1 { get; set; }
        [MaxLength(9), Unique]
        public string EmailAddress1 { get; set; }

        
    }
}
