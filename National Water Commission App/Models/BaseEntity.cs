using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Water_Commission_App.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}
