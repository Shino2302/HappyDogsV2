using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Models
{
    public class PetsModel
    {

        public HistorieOfFoodsModel HistorieOfFoods { get; set; }
        public int PetAge { get; set; }
        public string PetImage { get; set; }
        public string PetName { get; set;}
        public string PetRace { get; set;}
        public string PetSize { get; set;}

    }
}
