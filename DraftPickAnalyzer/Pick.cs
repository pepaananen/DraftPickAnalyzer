using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftPickAnalyzer {
    public class Pick {
        public int Number;
        public double Value;

        public Pick(int num) {
            Number = num;
            Value = CalculatePickValue(num);
        }

        public double CalculatePickValue(int num) {
            double val = Math.Round((-0.1914*(Math.Log(num)))+1.0,4);
            return val;
        }
    }
}
