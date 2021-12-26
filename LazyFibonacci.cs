using System.Numerics;

public class LazyFibonacci
{
    private List<BigInteger> sequence;

    public LazyFibonacci()
    {
        this.sequence = new List<BigInteger>();
        this.sequence.Add(0);
        this.sequence.Add(1);
    }

    public BigInteger Get(int seqIndex)
    {
        return sequence[seqIndex];
    }
}