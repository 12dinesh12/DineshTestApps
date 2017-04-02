using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IAssetTechnicalTest.Models
{
    public class Country
    {
        [Required]
        public string CountryName
        {
            get;
            set;
        }
    }
}