using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAB2_TestyJednostkowe;

namespace LAB2_TestyJednostkowe
{
    [TestClass]
    public class UnitTestPESELWalidator
    {
        PESELWalidator peselWalidator = new PESELWalidator("95100882445");
        PESELWalidator peselWalidatorDwa = new PESELWalidator("92092056355");
        PESELWalidator peselWalidatorTrzy = new PESELWalidator("05222798487");

        [TestMethod]
        public void TestSprawdzPeselCzyPoprawny()
        {
            bool result = peselWalidator.SprawdzPesel("92092056355");

            Assert.IsTrue(result);

        }
        
        [TestMethod]
        public void TestSprawdzPeselCzyPoprawnyLiteraWSrodku()
        {
            bool result = peselWalidator.SprawdzPesel("951008a2445");

            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void TestSprawdzPeselCzyJestZaDlugi()
        {
            bool result = peselWalidator.SprawdzPesel("95100882445123");

            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void TestSprawdzPeselCzyJestZaKrotki()
        {
            bool result = peselWalidator.SprawdzPesel("9510088244");

            Assert.IsTrue(!result);
        }
        [TestMethod]
        public void TestSumaKontrolnaPESEL()
        {
            int result = peselWalidator.SumaKontrolna("95100882445");
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void TestSumaKontrolnaPESELDruga()
        {
            int result = peselWalidatorDwa.SumaKontrolna("92092056355");
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void TestSumaKontrolnaPESELTrzy()
        {
            int result = peselWalidatorDwa.SumaKontrolna("03281491567");
            Assert.AreEqual(7, result);
        }
        [TestMethod]
        public void TestDataUrodzenia()
        {
            string result = peselWalidator.DataUrodzenia();
            Assert.AreEqual("08.10.1995", result);
        }
        [TestMethod]
        public void TestDataUrodzeniaRocznik2000()
        {
            string result = peselWalidatorTrzy.DataUrodzenia();
            Assert.AreEqual("27.02.2005", result);
        }


        [TestMethod]
        public void TestPlecMezczyzna()
        {
            string result = peselWalidatorDwa.Plec();

            Assert.AreEqual("Mê¿czyzna", result);
        }

        [TestMethod]
        public void TestPlecKobieta()
        {
            string result = peselWalidator.Plec();

            Assert.AreEqual("Kobieta", result);
        }
    }
}
