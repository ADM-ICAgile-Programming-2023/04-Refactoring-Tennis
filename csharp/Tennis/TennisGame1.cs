using System;
using System.Data;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;


        public TennisGame1(string player1Name, string player2Name)
        {
            
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
            {
                return ScoreAreEqual(m_score1);
            }

            if (m_score1 >= 4 || m_score2 >= 4)
            {
                return ScoreAreAdvantage(m_score1, m_score2);
            }

            return translateScores(m_score1) + "-" + translateScores(m_score2);
        }

        private string translateScores(int score)
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

        private string ScoreAreAdvantage(int m_score1, int m_score2)
        {
            var minusResult = m_score1 - m_score2;

            if (minusResult == 1) return "Advantage player1";

            if (minusResult == -1)
            {
                return "Advantage player2";
            }

            if (minusResult >= 2) return "Win for player1";

            return "Win for player2";
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

