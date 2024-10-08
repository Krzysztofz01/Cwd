﻿using System;

namespace Cwd;

public static class Help
{
    private static readonly string _title = @$"{Environment.NewLine}          _            _             _        {Environment.NewLine}        /\ \          / /\      _   /\ \      {Environment.NewLine}       /  \ \        / / /    / /\ /  \ \____ {Environment.NewLine}      / /\ \ \      / / /    / / // /\ \_____\{Environment.NewLine}     / / /\ \ \    / / /_   / / // / /\/___  /{Environment.NewLine}    / / /  \ \_\  / /_//_/\/ / // / /   / / / {Environment.NewLine}   / / /    \/_/ / _______/\/ // / /   / / /  {Environment.NewLine}  / / /         / /  \____\  // / /   / / /   {Environment.NewLine} / / /________ /_/ /\ \ /\ \/ \ \ \__/ / /    {Environment.NewLine}/ / /_________\\_\//_/ /_/ /   \ \___\/ /     {Environment.NewLine}\/____________/    \_\/\_\/     \/_____/      {Environment.NewLine}";
    
    public static void Print()
    {
        Console.WriteLine(_title);

        Console.WriteLine($"cwd (Copy Working Directory) - Simple as that...{Environment.NewLine}Created by: Krzysztofz01{Environment.NewLine}https://github.com/Krzysztofz01/Cwd{Environment.NewLine}Version: 1.2.0");

        Console.WriteLine($@"{Environment.NewLine}-h --help - Print informations and available commands.{Environment.NewLine}-p --print - Additionaly print the current directory.{Environment.NewLine}-j --jump - The current path is between ,,cd'' and new line symbol.");
    }
}
