using System;
using System.Threading.Tasks;
using Galdur;

namespace GaldurTest.commands;

internal class CommandsTest
{
    #region Fields

    private readonly SingletonTest _someSingleton;
    private readonly Galdur.Galdur _galdur;

    #endregion

    #region Constructor

    public CommandsTest(SingletonTest someSingleton, Galdur.Galdur galdur)
    {
        _someSingleton = someSingleton;
        _galdur = galdur;
    }

    #endregion

    #region Public Methods

    [Command]
    public async Task<string> TestAsync()
    {
        await Task.Delay(5000);
        int count = _someSingleton.Increment();
        _galdur.PublishEvent("testing", new { Test = "working!" });
        return $"it worked async {count}";
    }

    [Command]
    public string TestSync()
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
