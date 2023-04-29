using DraftPickAnalyzer;

namespace DraftPickAnalyzerTests {
    [TestClass]
    public class Tests {
        [TestMethod]
        public void TestPickValue() {
            Pick pick1 = new Pick(1);
            Pick pick2 = new Pick(2);
            Pick pick100 = new Pick(100);

            Assert.AreEqual(1, pick1.Value);
            Assert.AreEqual(0.8673, pick2.Value);
            Assert.AreEqual(0.1186, pick100.Value);
        }

        [TestMethod]
        public void TestGetPickNum() {
            decimal pick = 4.05m;
            PickNumCalculator calc = new PickNumCalculator(12);

            int pickNum = calc.GetPickNum(pick);

            Assert.AreEqual(41, pickNum);
        } 
    }
}