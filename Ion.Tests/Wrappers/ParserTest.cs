using Ion.Core;
using Ion.Tests.Core;
using NUnit.Framework;

namespace Ion.Tests.Wrappers
{
    [TestFixture]
    public class ParserTest
    {
        public ParserTestWrapper Wrapper { get; private set; }

        [SetUp]
        public void Setup()
        {
            // Reset the name counter before every test.
            NameCounter.ResetAll();

            // Prepare a new parser test wrapper instance.
            this.Wrapper = new ParserTestWrapper();
        }
    }
}