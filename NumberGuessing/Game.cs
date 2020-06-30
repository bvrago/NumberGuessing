using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuessing
{
    public class Game
    {
        string guess;
        int number;
        int numberGuess;
        bool guessValidation = true;
        bool playerWin = false;
        Random rand = new Random();

        string playerName;
        int difficultyLevel;
        int maxRange;
        int maxGuesses;

        public Game(string plyName)
        {
            playerName = plyName;
        }

        public bool newGame(int difficulty)
        {
            SetDifficulty(difficulty);

            Console.WriteLine($"Olá {playerName}! Vou pensar em um número entre 0 e {maxRange-1}. Voce tem {maxGuesses} tentativas para tentar adivinhar!");
            number = rand.Next(maxRange);

            for (int i = 0; i < maxGuesses; i++)
            {
                Console.Write($"{i + 1}º tentativa: ");
                guess = Console.ReadLine();
                guessValidation = int.TryParse(guess, out numberGuess);
                while (!guessValidation || (numberGuess < 0 || numberGuess > maxRange-1))
                {
                    Console.WriteLine($"Tentativa inválida, informe um número válido entre 0 e {maxRange-1}!");
                    Console.Write($"{i + 1}º tentativa: ");
                    guess = Console.ReadLine();
                    guessValidation = int.TryParse(guess, out numberGuess);
                }
                if (numberGuess == number)
                {
                    playerWin = true;
                    Console.WriteLine("Parabéns, você venceu!!!!!");
                    break;
                }
                else
                {
                    if (i != maxGuesses - 1)
                    {
                        if (numberGuess > number)
                        {
                            Console.WriteLine("Hummmmm... Não acertou! Tente novamente um pouco mais pra baixo!");
                        }
                        else
                        {
                            Console.WriteLine("Hummmmm... Não acertou! Tente novamente um pouco mais pra cima!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ERRRRRROU!!!!!!!!!! Eu venci, o número é {number}!");
                        playerWin = false;
                    }
                }
            }
            return playerWin;
        }

        public void SetDifficulty(int difficulty)
        {
            switch(difficulty)
            {
                case 1:
                    difficultyLevel = 1;
                    maxRange = 51;
                    maxGuesses = 7;
                    break;
                case 2:
                    difficultyLevel = 2;
                    maxRange = 101;
                    maxGuesses = 7;
                    break;
                case 3:
                    difficultyLevel = 3;
                    maxRange = 101;
                    maxGuesses = 5;
                    break;
                case 4:
                    difficultyLevel = 4;
                    maxRange = 11;
                    maxGuesses = 1;
                    break;
            }
        }
    }

}