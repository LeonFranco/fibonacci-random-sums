using System.Numerics;

class Fibonacci
{
    static public BigInteger DPFibonnaci(int nthFibNum) {
        List<BigInteger> sequence = new List<BigInteger>();
        sequence.Add(0);
        sequence.Add(1);

        for (int i = 2; i <= nthFibNum; ++i) {
            BigInteger firstTerm = sequence[i - 2];
            BigInteger secondTerm = sequence[i - 1];
            BigInteger nextFibNum = firstTerm + secondTerm;
            sequence.Add(nextFibNum);
        }

        return sequence[nthFibNum];
    }

    static public BigInteger MemoFibonnaci(int nthFibNum)
    {
        BigInteger[] seq = new BigInteger[nthFibNum + 1];
        Array.Fill<BigInteger>(seq, -1, 0, nthFibNum + 1);
        seq[0] = 0;
        seq[1] = 1;

        return Fibonacci.MemoFibonnaciDriver(seq, nthFibNum);
    }

    static private BigInteger MemoFibonnaciDriver(BigInteger[] seq, int nthFibNum)
    {
        if (seq[nthFibNum] == -1)
        {
            seq[nthFibNum] = 
                Fibonacci.MemoFibonnaciDriver(seq, nthFibNum - 1) + 
                Fibonacci.MemoFibonnaciDriver(seq, nthFibNum - 2);
        }

        return seq[nthFibNum];
    }
}