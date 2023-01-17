using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.SpectacleViewModels
{
    public class SpectacleCreateForm
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string nom { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
    }
}
