namespace Itransition.Task3
{
    using System.Collections.Generic;

    public class GameRules
    {
        private List<string> Moves;

        public GameRules(List<string> moves)
        {
            Moves = moves;
        }

        public string DetermineResult(string playerMove, string opponentMove)
        {
            if (playerMove == opponentMove)
                return "Draw";

            int playerIndex = Moves.IndexOf(playerMove);
            int opponentIndex = Moves.IndexOf(opponentMove);
            int half = Moves.Count / 2;

            // Calculate winning moves for the player
            var winningMoves = new List<string>();
            for (int i = 1; i <= half; i++)
            {
                int index = (playerIndex + i) % Moves.Count;
                winningMoves.Add(Moves[index]);
            }

            if (winningMoves.Contains(opponentMove))
                return "Win";
            else
                return "Lose";
        }

        public string DetermineWinner(string userMove, string computerMove)
        {
            string result = DetermineResult(userMove, computerMove);
            return result switch
            {
                "Win" => "You win!",
                "Lose" => "Computer wins!",
                "Draw" => "Draw",
                _ => "Error determining winner"
            };
        }
    }

}
