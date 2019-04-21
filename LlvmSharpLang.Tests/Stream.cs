using NUnit.Framework;
using LlvmSharpLang.Core;
using LlvmSharpLang.Misc;

namespace LlvmSharpLang.Tests
{
    public class StreamTests
    {
        protected Stream<int> stream;

        [SetUp]
        public void Setup()
        {
            this.stream = new Stream<int>
            {
                1,
                2,
                3
            };
        }

        [Test]
        public void Get()
        {
            Assert.AreEqual(1, this.stream.Get());
            Assert.Pass();
        }

        [Test]
        public void IndexBeZero()
        {
            Assert.AreEqual(0, this.stream.Index);
            Assert.Pass();
        }

        [Test]
        public void DoesIndexOverflow()
        {
            Assert.True(this.stream.DoesIndexOverflow(-1));
            Assert.True(this.stream.DoesIndexOverflow(3));
            Assert.False(this.stream.DoesIndexOverflow(2));
            Assert.False(this.stream.DoesIndexOverflow(1));
            Assert.False(this.stream.DoesIndexOverflow(0));
            Assert.Pass();
        }

        [Test]
        public void Peek()
        {
            Assert.AreEqual(2, this.stream.Peek());
            Assert.Pass();
        }

        [Test]
        public void PeekWithAmount()
        {
            Assert.AreEqual(2, this.stream.Peek());
            Assert.AreEqual(2, this.stream.Peek(1));
            Assert.AreEqual(3, this.stream.Peek(2));
            Assert.Pass();
        }

        [Test]
        public void Next()
        {
            Assert.AreEqual(2, this.stream.Next());
            Assert.AreEqual(1, this.stream.Index);
            Assert.AreEqual(2, this.stream.Get());
            Assert.Pass();
        }
    }
}
