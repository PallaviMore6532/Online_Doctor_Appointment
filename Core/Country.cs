using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Table("CountryTbl")]
    public class Country
    {
        [Key]
        public Int64 CountryID {  get; set; }
        [Required(ErrorMessage ="Country Name Required")]
        public String CountryName { get; set; }

        public virtual List<State> States { get; set; }
        public virtual List<User> Users { get; set; }

        public Country() 
        { 
          this.Users = new List<User>();
        }

    }
}
