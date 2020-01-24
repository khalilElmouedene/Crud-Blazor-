using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaysDataLibrary
{
    public class PaysDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Libelle { get; set; }
        public string LibelleArabe { get; set; }
        public int Version { get; set; } = 1;
    }
}
