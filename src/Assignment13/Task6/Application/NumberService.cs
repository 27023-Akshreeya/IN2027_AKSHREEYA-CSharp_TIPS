namespace Task6.Application;

public class NumberService
{
    public int SumOfElements(IEnumerable<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        return sum;
    }
}
