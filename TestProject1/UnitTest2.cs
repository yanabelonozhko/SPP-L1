using NUnit.Framework;
using lab1;
using System.Threading;

namespace TestProject1
{
    public class Tests2
    {
        private TraceResult result;

        [SetUp]
        public void Setup()
        {
            Tracer tracer = new Tracer();
            Foo foo = new Foo(tracer);
            Bar bar = new Bar(tracer);
            Thread thread = new Thread(foo.MyMethod);
            Thread thread2 = new Thread(bar.InnerMethod);
            thread2.Start();
            thread.Start();
            thread.Join();
            thread2.Join();
            result = tracer.GetTraceResult();
        }

        [Test]
        public void TestingThreadCountEqTo2()
        {
            var len = result.Threads.Length;
            Assert.AreEqual(len,2);
        }

        public void TestingMethodsCountEqTo2()
        {
            ThreadResult[] arr = result.Threads;
            Assert.AreEqual(arr[0].Methods.Count,2);
        }

        [Test]
        public void TestingClassNameEqToFoo()
        {
            var className = result.Threads[0].Methods[0].Class;
            Assert.That("Foo", Is.EqualTo(className));
        }

        [Test]
        public void MethodNameEqToMyMethod()
        {
            var className = result.Threads[0].Methods[0].Name;
            Assert.That("MyMethod", Is.EqualTo(className));
        }
    }
}