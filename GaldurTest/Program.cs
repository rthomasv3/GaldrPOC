using System;
using Galdur;
using GaldurTest.commands;

namespace GaldurTest;

internal class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        using Galdur.Galdur galdur = new GaldurBuilder()
            .SetTitle("Galdur + C# + Vue 3 App")
            .SetSize(1024, 768)
            .SetMinSize(800, 600)
            .AddSingleton<SingletonTest>()
            .AddService<TransientTest>()
            .AddService<CommandsTest>()
            .SetCommandNamespace("commands")
            .SetPort(42069)
            .Build();

        galdur.Run();
    }
}
