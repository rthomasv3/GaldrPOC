using System;
using Galdr;
using GaldrPOC.Commands;

namespace GaldrPOC;

internal class Program
{
    [STAThread]
    static void Main()
    {
        using Galdr.Galdr galdr = new GaldrBuilder()
            .SetTitle("Galdr + C# + Vue 3 App")
            .SetSize(1024, 768)
            .SetMinSize(800, 600)
            .AddSingleton<SingletonExample>()
            .AddService<TransientExample>()
            .AddService<CommandExamples>()
            .SetCommandNamespace("Commands")
            .SetPort(42069)
            .SetDebug(true)
            .Build()
            .Run();
    }
}
