using System.Numerics;
using System.Diagnostics;

class Driver
{
    private static Random rand = new Random(0);
    private static int MAX_SIZE = 100;
    private static int MIN_NTH_FIB = 10_000;
    private static int MAX_NTH_FIB = 100_000;

    private Stopwatch watch;
    private List<BigInteger> sums;
    private int[] randomNumbers;

    public Driver() 
    {
        this.watch = new Stopwatch();
        this.sums = new List<BigInteger>();
        this.randomNumbers = Enumerable.Range(0, MAX_SIZE)
            .Select(_ => rand.Next(MIN_NTH_FIB, MAX_NTH_FIB))
            .ToArray<int>();
    }

    public void RunSerialIterativeFibonnaciRandomSum() 
    {
        BigInteger sum = 0;

        watch.Reset();
        watch.Start();

        foreach (int nthFib in this.randomNumbers)
        {
            sum += Fibonacci.IterativeFibonnaci(nthFib);
        }

        watch.Stop();
        Console.WriteLine($"Serial iterative fib took {watch.Elapsed.ToString(@"m\:ss\.ff")}");

        this.sums.Add(sum);
    }

    public void RunParallelIterativeFibonnaciRandomSum() 
    {
        BigInteger sum = 0;
        object fibLock = new object();

        watch.Reset();
        watch.Start();
        
        var result = Parallel.ForEach(randomNumbers, nthFib =>
        {
            BigInteger result = Fibonacci.IterativeFibonnaci(nthFib);
            lock (fibLock) 
            {
                sum += result;
            }
        });

        watch.Stop();
        Console.WriteLine($"Parallel iterative fib took {watch.Elapsed.ToString(@"m\:ss\.ff")}");

        this.sums.Add(sum);
    }

    public void RunLazyFibonnaciRandomSum()
    {
        LazyFibonacci lazyFib = new LazyFibonacci();
        BigInteger sum = 0;

        watch.Reset();
        watch.Start();

        foreach (int nthFib in this.randomNumbers)
        {
            sum += lazyFib.Get(nthFib);
        }

        watch.Stop();
        Console.WriteLine($"Lazy fib took {watch.Elapsed.ToString(@"m\:ss\.ff")}");

        this.sums.Add(sum);
    }

    public void ValidateSums() 
    {
        for (int i = 1; i < this.sums.Count; ++i)
        {
            Debug.Assert(sums[i - 1] == sums[i]);
        }
    }
}