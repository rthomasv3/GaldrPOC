using System;
using System.Threading.Tasks;
using Galdr;

namespace GaldrTest.Commands;

internal sealed class CommandExamples
{
    #region Fields

    private readonly SingletonTest _someSingleton;
    private readonly Galdr.Galdr _galdr;

    #endregion

    #region Constructor

    public CommandExamples(SingletonTest someSingleton, Galdr.Galdr galdr)
    {
        _someSingleton = someSingleton;
        _galdr = galdr;
    }

    #endregion

    #region Public Methods

    [Command]
    public async Task<string> TestAsync()
    {
        await Task.Delay(5000);
        int count = _someSingleton.Increment();
        _galdr.PublishEvent("testing", new { Test = "working!" });
        return $"it worked async {count}";
    }

    [Command]
    public string TestSync(dynamic test)
    {
        int count = _someSingleton.Increment();
        return $"it worked sync {count}";
    }

    [Command]
    public string TestFailureSync()
    {
        throw new NotImplementedException("testing errors sync");
    }

    [Command]
    public async Task<string> TestFailureAsync()
    {
        await Task.Delay(5000);
        throw new NotImplementedException("testing errors async");
    }

    #endregion
}
