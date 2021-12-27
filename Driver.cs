using System.Numerics;
using System.Diagnostics;

class Driver
{
    private static Random rand = new Random(0);
    private static int MAX_SIZE = 100;
    private static int MIN_NTH_FIB = 1;
    private static int MAX_NTH_FIB = 400000;

    private Stopwatch watch;
    private LazyFibonacci lazyFib;
    private List<BigInteger> sums;
    private int[] randomNumbers;

    public Driver() 
    {
        this.watch = new Stopwatch();
        this.lazyFib = new LazyFibonacci();
        this.sums = new List<BigInteger>();
        this.randomNumbers = Enumerable.Range(0, MAX_SIZE)
            .Select(_ => rand.Next(MIN_NTH_FIB, MAX_NTH_FIB))
            .ToArray<int>();
    }

    public void RunIterativeFibonnaciRandomSum() {
        watch.Reset();
        watch.Start();

        BigInteger sum = 0;
        foreach (int nthFib in this.randomNumbers)
        {
            sum += Fibonacci.IterativeFibonnaci(nthFib);
        }

        watch.Stop();
        Console.WriteLine($"Regular iterative fib took {watch.Elapsed.ToString(@"m\:ss\.ff")}");

        this.sums.Add(sum);
    }

    public void RunLazyFibonnaciRandomSum()
    {
        watch.Reset();
        watch.Start();

        BigInteger sum = 0;
        foreach (int nthFib in this.randomNumbers)
        {
            sum += lazyFib.Get(nthFib);
        }

        watch.Stop();
        Console.WriteLine($"Lazy fib took {watch.Elapsed.ToString(@"m\:ss\.ff")}");

        this.sums.Add(sum);
    }

    public void validateSums() {
        for (int i = 1; i < this.sums.Count; ++i)
        {
            Debug.Assert(sums[i - 1] == sums[i]);
        }
    }
}