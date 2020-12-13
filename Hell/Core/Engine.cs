﻿using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private IHeroManager heroManager;
    private ICommandManager commandManager;

    public Engine(IInputReader reader, IOutputWriter writer, IHeroManager heroManager, ICommandManager commandManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
        this.commandManager = commandManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.ParseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ', '\n', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        string command = arguments[0] + "Command";
        arguments.RemoveAt(0);

        return this.commandManager.ProcessCommand(command, arguments);
        
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}