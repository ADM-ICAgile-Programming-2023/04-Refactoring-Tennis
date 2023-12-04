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
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                score = ScoreAreEqual(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                score = ScoreAreAdvantage(m_score1, m_score2);
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    score = ScoreDefault(i, score, tempScore);
                }
            }
            return score;
        }

        private string ScoreDefault(int i, string score, int tempScore) 
        {
            if (i == 1) tempScore = m_score1;
            else { score += "-"; tempScore = m_score2; }
            switch (tempScore)
            {
                case 0:
                    score += "Love";
                    break;
                case 1:
                    score += "Fifteen";
                    break;
                case 2:
                    score += "Thirty";
                    break;
                case 3:
                    score += "Forty";
                    break;
            }
            return score;
        }

        private string ScoreAreAdvantage(int m_score1, int m_score2)
        {
            string score;
            var minusResult = m_score1 - m_score2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
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

