using System;
using System.Data;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score;
        private int player2Score;


        public TennisGame1(string player1Name, string player2Name)
        {
            
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
            {
                return ScoreAreEqual(player1Score);
            }

            if (player1Score >= 4 || player2Score >= 4)
            {
                return ScoreAreAdvantage(player1Score, player2Score);
            }

            return TranslateScores(player1Score) + "-" + TranslateScores(player2Score);
        }

        private string TranslateScores(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new InvalidExpressionException();
            }
        }

        private string ScoreAreAdvantage(int player1Score, int player2Score)
        {

            if (IsPlayerAdvantage(player1Score, player2Score)) return "Advantage player1";

            if (IsPlayerAdvantage(player2Score, player1Score))
            {
                return "Advantage player2";
            }

            return player1Score > player2Score ? "Win for player1" : "Win for player2";
        }

        private static bool IsPlayerAdvantage(int player1Score, int player2Score)
        {
            var minusResult = player1Score - player2Score;
            return minusResult == 1;
        }



        private string ScoreAreEqual(int scoreInt)
        {
            string score;
            switch (scoreInt)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}

