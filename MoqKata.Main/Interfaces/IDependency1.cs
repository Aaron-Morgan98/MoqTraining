namespace MoqKata.Main.Interfaces
{
    using Models;

    public interface IDependency1
    {

        string Property1 { get; set; }

        IEnumerable<string> Property2 { get; set; }

        int Calculate(int a, int b);

        void SendMessage(Message msg);
    }
}
