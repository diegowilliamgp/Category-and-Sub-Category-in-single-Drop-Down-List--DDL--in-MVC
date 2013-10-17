using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCategorySubcategoryOneDDL.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}