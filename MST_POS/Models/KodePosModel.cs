using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MST_POS.Models
{
    public class KodePosModel
    {
        public int ID { get; set; }
        public int NoKodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string Jenis { get; set; }
        public string Kabupaten { get; set; }
        public string Propinsi { get; set; }
    }
}