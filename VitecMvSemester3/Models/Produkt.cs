using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecMvSemester3.Models
{
    public class Produkt
    {
        public long Id { get; set; }
        public string Navn { get; set; }
        public int Pris { get; set; }
        public string Type { get; set; }
        public string Beskrivelse { get; set; }

    }
}
