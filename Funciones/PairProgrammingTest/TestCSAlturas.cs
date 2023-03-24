using PairProgrammingGA;

namespace PairProgrammingTest
{
    [TestClass]
    public class TestCSAlturas
    {
        [TestMethod]
        public void PersonaMasAltaTest()
        {
            Personas p = new Personas();
            p.Nombre = "Pepe";
            p.Altura = 1;
            Personas[] arrP ={ p };
            string result = CSAlturas.personaMasAlta(arrP);

            Assert.AreEqual(p.Nombre, result);
        }
    }
}