namespace MoqKata.Main.Interfaces;

public interface IDependency3
{

    string NestedProperty1 { get; set; }

    IEnumerable<string> NestedProperty2 { get; set; }

    int NestedCalculate(int a, int b);

}