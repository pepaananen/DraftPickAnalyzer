using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftPickAnalyzer {
    public class PickNumCalculator {
        private int Teams;
        public PickNumCalculator(int teams) {
            Teams = teams;
        }

        public int GetPickNum(decimal roundPick) {
            int pickNum = (int)((Teams * (Math.Floor(roundPick) - 1)) + ((roundPick - Math.Floor(roundPick)) * 100));
            return pickNum;
        }
    }
}
