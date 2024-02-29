using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Models
{
    public class Mdispenser
    {
        public Mconfigure configDispenser { get; set; }
        public int FootContainer { get; set; }
        public int FootPlate { get; set; }
        public bool OnOff { get; set; }
    }
}
