using Spectre.Console;

namespace Itransition.Task3
{
    public class HelpTableGenerator
    {
        private List<string> Moves;
        private GameRules GameRules;

        public HelpTableGenerator(List<string> moves)
        {
            Moves = moves;
            GameRules = new GameRules(Moves);
        }

        public void DisplayHelpTable()
        {
            var table = new Table();

            // Add columns
            table.AddColumn("You \\ Computer");
            foreach (var move in Moves)
            {
                table.AddColumn(move);
            }

            // Add rows
            foreach (var yourMove in Moves)
            {
                var row = new List<string> { yourMove };
                foreach (var computerMove in Moves)
                {
                    string result = GameRules.DetermineResult(yourMove, computerMove);

                    // Color-code the result
                    string displayResult = result switch
                    {
                        "Win" => "[green]Win[/]",
                        "Lose" => "[red]Lose[/]",
                        "Draw" => "[yellow]Draw[/]",
                        _ => result
                    };

                    row.Add(displayResult);
                }
                table.AddRow(row.ToArray());
            }

            // Render the table to the console
            AnsiConsole.Write(table);
        }
    }
}
