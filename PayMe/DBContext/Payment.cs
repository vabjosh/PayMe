using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.DBContext
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string cardNumber  { get; set; }
        public string cardHolder { get; set; }
        public string cardExp { get; set; }
        public int cardCVV { get; set; }
        public string cardPin { get; set; }
        public string? _cardTypes { get; set; }
        
    }
}
