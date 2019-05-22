using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Models
{
    public class SeriesCastAndCrew
    {
        public Cast[] cast { get; set; }
        public Crew[] crew { get; set; }
        public int id { get; set; }
    }
}
