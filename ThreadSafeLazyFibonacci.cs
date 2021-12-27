using System.Numerics;

public class ThreadSafeLazyFibonacci : LazyFibonacci
{
    public ReaderWriterLockSlim ReaderWriterLock { get; private set; }

    public ThreadSafeLazyFibonacci() : base()
    {
        this.ReaderWriterLock = new ReaderWriterLockSlim();
    }

    public override BigInteger Get(int seqIndex)
    {
        this.ReaderWriterLock.EnterUpgradeableReadLock();
        try
        {
            if (this.Sequence.Count <= seqIndex)
            {
                this.ReaderWriterLock.EnterWriteLock();
                try
                {
                    // second check in case another thread updated sequence
                    // while current thread waited for write lock
                    if (this.Sequence.Count <= seqIndex)
                    {
                        this.UpdateSequence(seqIndex);
                    }
                }
                finally
                {
                    this.ReaderWriterLock.ExitWriteLock();
                }
            }

            return Sequence[seqIndex];
        }
        finally
        {
            this.ReaderWriterLock.ExitUpgradeableReadLock();
        }
    }
}