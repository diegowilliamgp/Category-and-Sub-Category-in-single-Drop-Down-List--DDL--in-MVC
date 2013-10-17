using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCategorySubcategoryOneDDL.Models
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }
}