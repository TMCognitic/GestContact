using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Mvd.Models
{
    public class EditContactForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(50)]
        public string Prenom { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Tel { get; set; }

    }
}
