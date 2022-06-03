using MikoBussEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikoBussUI.Models
{
    public class SehirGuzergahModel
    {
        public int GuzergahId { get; set; }
        public string GuzergahStart { get; set; }
        public string GuzergahEnd { get; set; }
        public DateTime GuzergahTarihi { get; set; }
        public decimal GuzargahFiyat { get; set; }
        public string TicketName { get; set; }
        public string TicketSurname { get; set; }
        public string TicketMail { get; set; }
        public int TicketSeatNo { get; set; }



        public List<City> Cities { get; set; }
        public List<Guzergah> Guzergahs { get; set; }
    }
}
