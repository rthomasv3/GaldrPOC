using System;
using Galdr;
using GaldrTest.Commands;

namespace GaldrTest;

internal class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        using Galdr.Galdr galdr = new GaldrBuilder()
            .SetTitle("Galdr + C# + Vue 3 App")
            .SetSize(1024, 768)
            .SetMinSize(800, 600)
            .AddSingleton<SingletonTest>()
            .AddService<TransientTest>()
            .AddService<CommandExamples>()
            .SetCommandNamespace("Commands")
            .SetPort(42069)
            .Build();

        galdr.Run();
    }
}
