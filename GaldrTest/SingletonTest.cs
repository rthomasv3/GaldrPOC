namespace GaldrTest;

internal sealed class SingletonTest
{
    private int _count = 0;

    public int Increment()
    {
        _count++;
        return _count;
    }
}
