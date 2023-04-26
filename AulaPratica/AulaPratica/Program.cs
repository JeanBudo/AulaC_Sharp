using AulaPratica.Aula01.Entities;
using System;
using System.Linq;
using AulaPratica.Aula01.Enums;
using System.Collections.Generic;



namespace AulaPratica
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Character player = new Character("Player", 1, 3, 2, 20, EnumCharType.Player);
            Character enemyA = new Character("EnemyA", 1, 1, 1, 15, EnumCharType.Enemy);
            Character enemyB = new Character("EnemyB", 1, 1, 1, 10, EnumCharType.Enemy);
            Character enemyC = new Character("EnemyC", 1, 1, 1, 16, EnumCharType.Enemy);
            List<Character> charactersList = new List<Character>();
            charactersList.Add(player);
            charactersList.Add(enemyA);
            charactersList.Add(enemyB);
            charactersList.Add(enemyC);

            charactersList = charactersList.OrderByDescending(x => x.speed).ToList();

            foreach (Character obj in charactersList)
            {
                Console.WriteLine(obj.charName);
            }

            //variaveis do tabuleiro
            bool gameOver = false;
            string actionSelected;

            while (!gameOver)
            {
                for (int i = 0; i < charactersList.Count; i++)
                {
                    if (charactersList[i].charType == EnumCharType.Player)
                    {
                        Console.WriteLine("Vez de: " + charactersList[i].charName);
                        Console.WriteLine("Pressione Q para atacar o oponente mais próximo!");
                        CheckPlayerSuperAtaque(charactersList[i]);
                        Console.WriteLine("Pressione outra tecla para passar a vez");
                        Console.Write("Seu comando: ");
                        actionSelected = Console.ReadLine();
                        if (actionSelected == "q" || actionSelected == "Q")
                        {
                            charactersList[i].AttackCloserEnemy(charactersList);
                        }
                        else if (actionSelected == "s" || actionSelected == "S")
                        {
                            charactersList[i].SuperAttack(charactersList);
                        }
                        else
                        {
                            charactersList[i].PassTurn();
                        }
                        //Verificação de vitoria!
                        CheckIsGameOVer();
                        Console.WriteLine();
                        if (gameOver == true) { break; }
                    }
                    else if (charactersList[i].charType == EnumCharType.Enemy)
                    {
                        charactersList[i].AttackPlayer(charactersList);
                    }

                    //Verificação de vitoria!
                    CheckIsGameOVer();
                    if (gameOver == true) { break; }


                }
            }//fim do while
            Console.WriteLine("Obrigado por jogar!!!");



            //Métodos
            void CheckIsGameOVer()
            {
                bool _isPlayerWinner = true;
                bool _isEnemyWinner = true;

                for (int i = 0; i < charactersList.Count; i++)
                {
                    if (charactersList[i].charHP > 0 && charactersList[i].charType == EnumCharType.Player)
                    {
                        _isEnemyWinner = false;
                    }
                    if (charactersList[i].charHP > 0 && charactersList[i].charType == EnumCharType.Enemy)
                    {
                        _isPlayerWinner = false;
                    }
                }

                if (_isPlayerWinner == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Você Ganhou!");
                    gameOver = true;
                }
                if (_isEnemyWinner == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Você Perdeu!");
                    gameOver = true;
                }
            }
            void CheckPlayerSuperAtaque(Character character)
            {
                if (character.coolDown == 0)
                {
                    Console.WriteLine("Pressione S para realizar um SUPER ATAQUE!");
                }
                else
                {
                    Console.WriteLine("Super Ataque em espera...");
                }
            }
        }



    }

}