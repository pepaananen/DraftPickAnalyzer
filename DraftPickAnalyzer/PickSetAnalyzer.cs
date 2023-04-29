using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftPickAnalyzer {
    public class PickSetAnalyzer {
        public PickSetAnalyzer() { }

        public double Analyze(List<Pick> giving, List<Pick> getting) {
            double givingVal = 0;
            double gettingVal = 0;
            foreach (Pick pick in giving) {
                givingVal += pick.Value;
            }
            foreach (Pick pick in getting) {
                gettingVal += pick.Value;
            }
            double percentImproved = ((gettingVal - givingVal) / givingVal) * 100;

            return percentImproved;
        }
    }
}
