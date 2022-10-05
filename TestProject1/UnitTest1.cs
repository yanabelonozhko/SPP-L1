using NUnit.Framework;
using lab1;
using System.Threading;

namespace TestProject1
{
    public class Tests
    {
        private TraceResult result;
        [SetUp]
        public void Setup()
        {
            Tracer tracer = new Tracer();
            Foo foo = new Foo(tracer);
            foo.MyMethod();
            Thread thread = new Thread(foo.MyMethod);
            thread.Start();
            thread.Join();
            result = tracer.GetTraceResult();
        }

        [Test]
        public void TestingThreadCount()
        {
            var len = result.Threads.Length;
            Assert.AreNotEqual(len,null);
        }

        [Test]
        public void TestingTimeIsNotNull()
        {
            ThreadResult[] arr = result.Threads;
            foreach (var t in arr) {
               Assert.AreNotEqual(t.Time, null);
            }
        }

        [Test]
        public void TestingIDIsNotNull()
        {
            ThreadResult[] arr = result.Threads;
            foreach (var t in arr)
            {
                Assert.AreNotEqual(t.Id, null);
            }
        }

        [Test]
        public void TestingMethodsNotNull()
        {
            ThreadResult[] arr = result.Threads;
            foreach (var t in arr)
            {
                Assert.AreNotEqual(t.Methods, null);
            }
        }
    }
}