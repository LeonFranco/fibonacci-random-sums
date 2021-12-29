using System.Numerics;
using System.Diagnostics;

class Driver
{
    private static int MAX_SIZE = 100;
    private static int MIN_NTH_FIB = 10_000;
    private static int MAX_NTH_FIB = 100_000;

    private List<BigInteger> sums;
    private int[] randomNumbers;

    public Driver() 
    {
        this.sums = new List<BigInteger>();

        Random rand = new Random(0);
        this.randomNumbers = Enumerable.Range(0, MAX_SIZE)
            .Select(_ => rand.Next(MIN_NTH_FIB, MAX_NTH_FIB))
            .ToArray<int>();
    }
    public void RunSerialMemoFibonnaciRandomSum() 
    {
        Console.Write("Serial Memo ");
        this.GetStat(() =>
        {
            BigInteger sum = 0;

            foreach (int nthFib in this.randomNumbers)
            {
                sum += Fibonacci.MemoFibonnaci(nthFib);
            }

            return sum;
        });
    }

    public void RunSerialDPFibonnaciRandomSum() 
    {
        Console.Write("Serial DP ");
        this.GetStat(() =>
        {
            BigInteger sum = 0;

            foreach (int nthFib in this.randomNumbers)
            {
                sum += Fibonacci.DPFibonnaci(nthFib);
            }

            return sum;
        });
    }

    public void RunParallelDPFibonnaciRandomSum() 
    {
        Console.Write("Parallel DP ");
        this.GetStat(() =>
        {
            BigInteger sum = 0;
            object fibLock = new object();

            Parallel.ForEach(randomNumbers, nthFib =>
            {
                BigInteger result = Fibonacci.DPFibonnaci(nthFib);
                lock (fibLock) 
                {
                    sum += result;
                }
            });

            return sum;
        });
    }

    public void RunSerialLazyFibonnaciRandomSum()
    {
        Console.Write("Serial lazy ");
        this.GetStat(() =>
        {
            LazyFibonacci lazyFib = new LazyFibonacci();
            BigInteger sum = 0;

            foreach (int nthFib in this.randomNumbers)
            {
                sum += lazyFib.Get(nthFib);
            }

            return sum;
        });
    }

    public void RunParallelLazyFibonnaciRandomSum()
    {
        Console.Write("Parallel lazy ");
        this.GetStat(() =>
        {
            ThreadSafeLazyFibonacci tsLazyFib = new ThreadSafeLazyFibonacci();
            BigInteger sum = 0;
            object fibLock = new object();

            Parallel.ForEach(randomNumbers, nthFib =>
            {
                BigInteger result = tsLazyFib.Get(nthFib);
                lock (fibLock) 
                {
                    sum += result;
                }
            });

            return sum;
        });
    }

    public void ValidateSums() 
    {
        for (int i = 1; i < this.sums.Count; ++i)
        {
            Debug.Assert(sums[i - 1] == sums[i]);
        }
    }

    private void GetStat(Func<BigInteger> fib) 
    {
        BigInteger sum = 0;
        Stopwatch watch = new Stopwatch();

        watch.Reset();
        watch.Start();

        sum += fib();

        watch.Stop();
        Console.WriteLine($"fib took {watch.Elapsed.ToString(@"m\:ss\.ff")}");

        this.sums.Add(sum);
    }
}