using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Models
{
    public class DispenserModel
    {
        public bool CameraOnOff { get; set; }

        public ConfigureModel Configure { get; set; }

        public int FoodInContainer  {get; set; }

        public int FoodInPlate { get; set; }

        public bool OnOff { get; set; }

    }
}
