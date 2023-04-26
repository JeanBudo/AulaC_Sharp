using AulaPratica.Aula01.Entities;
using System;
using System.Linq;



namespace AulaPratica
{
    internal class Program
    {



        static void Main(string[] args)
        {

            Character[] characterArray = new Character[4];
            characterArray[0] = new Character("Player", 1, 3, 2, 1, true);
            characterArray[1] = new Character("EnemyA", 1, 1, 1, 15, false);
            characterArray[2] = new Character("EnemyB", 1, 1, 1, 10, false);
            characterArray[3] = new Character("EnemyC", 1, 1, 1, 16, false);

            characterArray = characterArray.OrderByDescending(x => x.speed).ToArray();

            foreach(Character obj in characterArray)
            {
                Console.WriteLine(obj.charName);
            }

            //variaveis do tabuleiro
            bool gameOver = false;
            string actionSelected;

            while (!gameOver)
            {
                for (int i = 0; i < characterArray.Length; i++)
                {
                    if (characterArray[i].isPlayer == true)
                    {
                        Console.WriteLine("Vez de: " + characterArray[i].charName);
                        Console.WriteLine("Pressione Q para atacar o oponente mais próximo!");
                        CheckPlayerSuperAtaque(characterArray[i]);
                        Console.WriteLine("Pressione outra tecla para passar a vez");
                        Console.Write("Seu comando: ");
                        actionSelected = Console.ReadLine();
                        if (actionSelected == "q" || actionSelected == "Q")
                        {
                            characterArray[i].AttackCloserEnemy(characterArray);
                        }
                        else if (actionSelected == "s" || actionSelected == "S")
                        {
                            characterArray[i].SuperAttack(characterArray);
                        }
                        else
                        {
                            characterArray[i].PassTurn();
                        }
                        //Verificação de vitoria!
                        CheckIsGameOVer();
                        Console.WriteLine();
                        if (gameOver == true) { break; }
                    }
                    else if (characterArray[i].isPlayer == false)
                    {
                        characterArray[i].AttackPlayer(characterArray);
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

                for (int i = 0; i < characterArray.Length; i++)
                {
                    if (characterArray[i].charHP > 0 && characterArray[i].isPlayer == true)
                    {
                        _isEnemyWinner = false;
                    }
                    if (characterArray[i].charHP > 0 && characterArray[i].isPlayer == false)
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