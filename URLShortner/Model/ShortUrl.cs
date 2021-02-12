using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortner.Model
{
    public class ShortUrl
    {
        [Key]
        public String ShortKey { get; set; }

        [Required]
        public String Url { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
