using System;
using System.Collections.Generic;
using System.Text;

namespace PaysDataLibrary
{
    public class AddPays
    {
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string LibelleArabe { get; set; }
        public int Version { get; set; } = 1;
    }
}
