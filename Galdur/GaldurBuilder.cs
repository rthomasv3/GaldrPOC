﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SharpWebview.Content;

namespace Galdur;

public sealed class GaldurBuilder
{
    #region Fields

    private readonly ServiceCollection _services = new ServiceCollection();
    private string _title = "Galdur";
    private int _width = 1024;
    private int _height = 768;
    private int _minWidth = 800;
    private int _minHeight = 600;
    private int _port = 42069;
    private bool _debug = true;
    private string _commandNamespace = "commands";

    #endregion

    #region Public Methods

    public GaldurBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }

    public GaldurBuilder SetSize(int width, int height)
    {
        _width = width;
        _height = height;
        return this;
    }

    public GaldurBuilder SetMinSize(int minWidth, int minHeight)
    {
        _minWidth = minWidth;
        _minHeight = minHeight;
        return this;
    }

    public GaldurBuilder SetPort(int port)
    {
        _port = port;
        return this;
    }

    public GaldurBuilder SetDebug(bool debug)
    {
        _debug = debug;
        return this;
    }

    public GaldurBuilder SetCommandNamespace(string commandNamespace)
    {
        _commandNamespace = commandNamespace;
        return this;
    }

    public GaldurBuilder AddService<T>() 
        where T : class
    {
        _services.AddTransient<T>();
        return this;
    }

    public GaldurBuilder AddService<T1, T2>()
        where T1 : class
        where T2 : class, T1
    {
        _services.AddTransient<T1, T2>();
        return this;
    }

    public GaldurBuilder AddSingleton<T>()
        where T : class
    {
        _services.AddSingleton<T>();
        return this;
    }

    public GaldurBuilder AddSingleton<T1, T2>()
        where T1 : class
        where T2 : class, T1
    {
        _services.AddSingleton<T1, T2>();
        return this;
    }

    public Galdur Build()
    {
        return new Galdur(new GaldurOptions()
        {
            Commands = GetCommands(),
            Content = new EmbeddedContent(_port),
            Debug = _debug,
            Height = _height,
            MinHeight = _minHeight,
            MinWidth = _minWidth,
            Services = _services,
            Title = _title,
            Width = _width,
        });
    }

    #endregion

    #region Private Methods

    private IWebviewContent GetContent()
    {
        bool serverIsRunning = false;

        try
        {
            using TcpClient client = new();
            IAsyncResult result = client.BeginConnect("localhost", _port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(50);
            client.EndConnect(result);
            serverIsRunning = true;
        }
        catch (SocketException) { }

        return serverIsRunning ? new UrlContent($"http://localhost:{_port}") : new EmbeddedContent(_port);
    }

    private Dictionary<string, MethodInfo> GetCommands()
    {
        Dictionary<string, MethodInfo> commandMap = new Dictionary<string, MethodInfo>();

        IEnumerable<Type> commandTypes = Assembly
            .GetEntryAssembly()
            .GetTypes()
            .Where(x => x.Namespace?.Contains(_commandNamespace) == true);

        foreach (Type commandType in commandTypes)
        {
            IEnumerable<MethodInfo> commands = commandType
                .GetMethods()
                .Where(x => x.IsPublic &&
                            x.CustomAttributes.Any(y => y.AttributeType == typeof(CommandAttribute)));

            foreach (MethodInfo command in commands)
            {
                CommandAttribute commandAttribute = command.GetCustomAttribute<CommandAttribute>();

                string name = String.IsNullOrWhiteSpace(commandAttribute.Name) ? command.Name : commandAttribute.Name;
                name = Char.ToLowerInvariant(name[0]) + name.Substring(1);

                if (!commandMap.ContainsKey(name))
                {
                    commandMap.Add(name, command);
                }
            }
        }

        return commandMap;
    }

    #endregion
}