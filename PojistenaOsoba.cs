using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evidence

{
   public class PojistenaOsoba
    {
        public string JmenoPojistence { get; set; }
        public string PrijmeniPojistence { get; set; }
        public int VekPojistence { get; set; }
        public int TelefonPojistence { get; set; }


        public override string ToString()
        {
            return JmenoPojistence + " " + PrijmeniPojistence + " " + VekPojistence + " " + TelefonPojistence;
        }


    }
}
