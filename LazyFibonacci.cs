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
        if (this.sequence.Count <= seqIndex)
        {
            this.UpdateSequence(seqIndex);
        }

        return sequence[seqIndex];
    }

    private void UpdateSequence(int seqIndex)
    {
        for (int i = this.sequence.Count; i <= seqIndex; ++i) {
            BigInteger firstTerm = this.sequence[i - 2];
            BigInteger secondTerm = this.sequence[i - 1];
            BigInteger nextFibNum = firstTerm + secondTerm;
            this.sequence.Add(nextFibNum);
        }
    }
}