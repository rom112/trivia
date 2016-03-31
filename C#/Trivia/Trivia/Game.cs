using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyTrivia
{
    public class Game
    {
        List<Player> players = new List<Player>();

        private Dictionary<int, QuestionStack> questionAccordingPosition = new Dictionary<int, QuestionStack>();

        int currentPlayer = 0;

        bool isGettingOutOfPenaltyBox;

        public Game()
        {
            questionAccordingPosition.Add(0,new QuestionStack("Pop"));
            questionAccordingPosition.Add(1,new QuestionStack("Science"));
            questionAccordingPosition.Add(2,new QuestionStack("Sports"));
            questionAccordingPosition.Add(3,new QuestionStack("Rock"));
        }

        public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool isPlayable()
        {
            return (players.Count >= 2);
        }

        public bool add(String playerName)
        {
            players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public void roll(int roll)
        {
            Console.WriteLine(players[currentPlayer].Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (players[currentPlayer].InPenaltyBox)
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players[currentPlayer].Name + " is getting out of the penalty box");
                    players[currentPlayer].MovePlace(roll);

                    Console.WriteLine(players[currentPlayer].Name
                            + "'s new location is "
                            + players[currentPlayer].Place);
                    Console.WriteLine("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    Console.WriteLine(players[currentPlayer].Name + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                players[currentPlayer].MovePlace(roll);

                Console.WriteLine(players[currentPlayer].Name
                        + "'s new location is "
                        + players[currentPlayer].Place);
                Console.WriteLine("The category is " + currentCategory());
                askQuestion();
            }
        }

        private void askQuestion()
        {
            questionAccordingPosition[players[currentPlayer].Place%4].AskNextQuestion();
        }


        private String currentCategory()
        {
            switch (players[currentPlayer].Place % 4)
            {
                case 0:
                    return "Pop";
                case 1:
                    return "Science";
                case 2:
                    return "Sports";
                default:
                    return "Rock";
            }
        }

        public bool wasCorrectlyAnswered()
        {
            if (players[currentPlayer].InPenaltyBox)
            {
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine("Answer was correct!!!!");
                    players[currentPlayer].AddOnePurse();
                    Console.WriteLine(players[currentPlayer].Name
                            + " now has "
                            + players[currentPlayer].Purse
                            + " Gold Coins.");

                    bool winner = didPlayerWin();
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;

                    return winner;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == players.Count) currentPlayer = 0;
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Answer was corrent!!!!");
                players[currentPlayer].AddOnePurse();
                Console.WriteLine(players[currentPlayer].Name
                        + " now has "
                        + players[currentPlayer].Purse
                        + " Gold Coins.");

                bool winner = didPlayerWin();
                currentPlayer++;
                if (currentPlayer == players.Count) currentPlayer = 0;

                return winner;
            }
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer].Name + " was sent to the penalty box");
            players[currentPlayer].GoToPrison();

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool didPlayerWin()
        {
            return !(players[currentPlayer].Purse == 6);
        }
    }

    internal class QuestionStack
    {
        private LinkedList<string> questions = new LinkedList<string>();

        public QuestionStack(string CategoryName)
        {
            for (int i = 0; i < 50; i++)
            {
                questions.AddLast(CategoryName + " Question " + i);
            }
        }

        public string CategoryName { get; private set; }

        public void AskNextQuestion()
        {
            Console.WriteLine(questions.First());
            questions.RemoveFirst();
        }
    }
}
