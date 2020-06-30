using System;
using System.Collections.Generic;

namespace NumberGuessing
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo
            //*new game - *placar - *dificuldade - historico - *apresentar numero escolhido no final
            string playerName;
            Game game;
            List<ScoreBoard> scBoardList = new List<ScoreBoard>();
            bool playerWin = false;
            string playAgain = "S";
            int[] score = new int[2];

            int difficultyLevel;
            int roundNumber = 0;
            string winner;

            //recebe o nome do jogador
            Console.Write("Vamos jogar um jogo? Para começar, me diga seu nome:");
            playerName = Console.ReadLine();

            //Instancia um novo objeto Game informando o nome do jogador
            game = new Game(playerName);


            while (playAgain == "S" || playAgain == "H")
            {
                if (playAgain == "S")
                {
                    roundNumber++;
                    Console.WriteLine($"Rodada {roundNumber}: {playerName} escolha a dificuldade dessa partida: 1-Fácil 2-Médio 3-Difícil 4-Extremo");
                    while (!int.TryParse(Console.ReadLine(), out difficultyLevel) || (difficultyLevel < 1 || difficultyLevel > 4))
                    {
                        Console.WriteLine($"Por Favor, escolha uma das dificuldades disponíveis.");
                    }
                
                    playerWin = game.newGame(difficultyLevel);
                
                    //Monta e exibe o placar conforme o resultado da rodada
                    if (playerWin)
                    {
                        score[0]++;
                        winner = playerName;

                    }
                    else
                    {
                        score[1]++;
                        winner = "CPU";
                    }
                    Console.WriteLine($"Placar atual: {playerName} {score[0]} X CPU {score[1]}");
                    scBoardList.Add(new ScoreBoard { RoundNumber = roundNumber, DifficultyLevel = difficultyLevel, Winner = winner });
                }
                else
                {
                    Console.WriteLine($"----------------------------------------------------------------------");
                    Console.WriteLine($"HISTÓRICO");
                    foreach (ScoreBoard sc in scBoardList)
                    {
                        Console.WriteLine($"Rodada {sc.RoundNumber} - Dificuldade selecionada {sc.DifficultyLevel} - Vencedor {sc.Winner}");
                    }



                }

                //recebe e valida a opção de novo Jogo
                Console.WriteLine("Gostaria de jogar uma nova rodada(S/N)? Ou entre com \'H' para ver o histórico.");
                playAgain = Console.ReadLine().ToUpper();
                while (playAgain != "S" && playAgain != "N" && playAgain != "H")
                {
                    Console.WriteLine("Opção inválida, informe \'S', \'N' ou \'H'!");
                    playAgain = Console.ReadLine().ToUpper();
                }
            }
        }
    }
}
