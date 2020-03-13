using NUnit.Framework;

namespace TesteNUnit
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}