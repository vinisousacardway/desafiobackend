using desafiobackend.Domain.Entities;  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiobackend.Domain.Dtos
{
    public class RetailesDto
    {
      
        public int Owner { get; set; }
        [Required]
        [DefaultValue(0)]
        public StatusTransaction Status { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}
