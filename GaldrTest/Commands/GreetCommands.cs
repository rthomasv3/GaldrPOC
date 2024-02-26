using Galdr;

namespace GaldrTest.Commands;

internal sealed class GreetCommands
{
    [Command]
    public static string Greet(string name)
    {
        return $"Hello, {name}! You've been greeted from C#!";
    }
}
