using System.Numerics;

public class LazyFibonacci
{
    protected List<BigInteger> Sequence { get; private set; }

    public LazyFibonacci()
    {
        this.Sequence = new List<BigInteger>();
        this.Sequence.Add(0);
        this.Sequence.Add(1);
    }

    public BigInteger Get(int seqIndex)
    {
        if (this.Sequence.Count <= seqIndex)
        {
            this.UpdateSequence(seqIndex);
        }

        return Sequence[seqIndex];
    }

    private void UpdateSequence(int seqIndex)
    {
        for (int i = this.Sequence.Count; i <= seqIndex; ++i) {
            BigInteger firstTerm = this.Sequence[i - 2];
            BigInteger secondTerm = this.Sequence[i - 1];
            BigInteger nextFibNum = firstTerm + secondTerm;
            this.Sequence.Add(nextFibNum);
        }
    }
}