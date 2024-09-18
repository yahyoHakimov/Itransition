using Itransition.Task3;
using Spectre.Console;
using System;
using System.Collections.Generic;

public class HelpTable
{
    private readonly List<string> moves;

    public HelpTable(List<string> moves)
    {
        this.moves = moves;
    }

    public void DisplayHelp()
    {
        // Create the table
        var table = new Table();

        // Add a column for "Moves"
        table.AddColumn("Moves");

        // Add columns for each move
        foreach (var move in moves)
        {
            table.AddColumn(move);
        }

        // Add rows for each move
        for (int i = 0; i < moves.Count; i++)
        {
            var row = new List<string> { moves[i] };  // Start with the move name
            for (int j = 0; j < moves.Count; j++)
            {
                if (i == j)
                {
                    row.Add("Draw");
                }
                else
                {
                    var gameRules = new GameRules(moves);
                    row.Add(gameRules.DetermineWinner(moves[i], moves[j]));
                }
            }

            // Add the row to the table
            table.AddRow(row.ToArray());
        }

        // Render the table
        AnsiConsole.Write(table);
    }
}
