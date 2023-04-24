using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence
{
    
    public class DatabazePojistenych
    {
        List<PojistenaOsoba> seznamPojistencu;

        public DatabazePojistenych()
        {
            seznamPojistencu = new List<PojistenaOsoba>();
        }

        public void PridejPojistence(PojistenaOsoba pojistenec) // přidá nového pojištěnce do databáze
        {
            seznamPojistencu.Add(pojistenec);
        }
        public List<PojistenaOsoba> VypisSeznamPojistencu() // vrátí seznam pojištěnců
        {
            return seznamPojistencu;
        }

        public List<PojistenaOsoba> NajdiPojistence (string jmeno, string prijmeni) // vyhledá pojištěnce
        {
            List<PojistenaOsoba> nalezenyPojistenec = new List<PojistenaOsoba>();
            foreach (PojistenaOsoba pojistOs in seznamPojistencu)
            {
                if (pojistOs.JmenoPojistence == jmeno && pojistOs.PrijmeniPojistence == prijmeni)
                {
                    nalezenyPojistenec.Add(pojistOs);
                }
            }
            return nalezenyPojistenec;
        }
        
    }
}
