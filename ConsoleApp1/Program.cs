public class TraceResult
{
    public string MethodName;
    public string ClassName;
    public float MethodTime;
}

public interface ITracer
{
    // Вызвается в начале замеряемого метода 
    void StartTrace();

    // Вызывается в конце замеряемого метода 
    void StopTrace();

    TraceResult GetTraceResult();
}
namespace lab1 {
    class Program {
        static void Main() {
            Console.WriteLine("Отслеживание времени выполнения методов:");
        } 
    }
}