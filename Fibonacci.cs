using System.Numerics;

class Fibonacci
{
    static public BigInteger RecursiveFibonnaci(int nthFibNum)
    {
        if (nthFibNum <= 1) {
            return nthFibNum;
        }

        return Fibonacci.RecursiveFibonnaci(nthFibNum - 1) + Fibonacci.RecursiveFibonnaci(nthFibNum - 2);
    }

    static public BigInteger IterativeFibonnaci(int nthFibNum) {
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
}