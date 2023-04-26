using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaPratica.Aula01.Entities
{
    public class Character
    {
        //Personagem principal
      public  string charName = "Rodrigo";
        public int level;
        public int constituition;
        public int attack;
        public int charHP;
        public int speed;
        public bool isPlayer;
        //SuperAtaque
        public int coolDown = 0;

        public Character(string charName, int level, int constituition, int attack, int speed, bool isPlayer)
        {
            this.charName = charName;
            this.level = level;
            this.constituition = constituition;
            this.attack = attack;
            this.speed = speed;
            this.isPlayer = isPlayer;
            charHP = CalculateHP(this.constituition, this.level);
        }

        int CalculateHP(int constituition, int level)
        {
            return (constituition + level) * 3;
        }
        public void AttackCloserEnemy(Character[] charArray)
        {
            int _damange = attack + level;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i].charHP > 0 && charArray[i].isPlayer == false)
                {
                    charArray[i].charHP -= _damange;
                    Console.WriteLine(charName + " atacou " + charArray[i].charName + ":  ele recebeu " + _damange + " pontos de dano, ficando com HP= " + charArray[i].charHP);
                    if (coolDown > 0) { coolDown--; }
                    return;
                }
            }


        }
        public void SuperAttack(Character[] charArray)
        {
            int _damange = attack + level;
            if (coolDown == 0)
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i].charHP > 0 && charArray[i].isPlayer == false)
                    {
                        charArray[i].charHP -= _damange;
                        Console.WriteLine(charName + " atacou " + charArray[i].charName + ":  ele recebeu " + _damange + " pontos de dano, ficando com HP= " + charArray[i].charHP);

                    }
                }
                coolDown++;
            }
            else
            {
                AttackCloserEnemy(charArray);
            }

        }
        public void AttackPlayer(Character[] charArray)
        {
            if (charHP > 0)
            {
                for(int i=0;i>charArray.Length;i++)
                {
                    if (charArray[i].isPlayer == true)
                    {
                        int _enemyDamange = attack + level;
                        charArray[i].charHP -= _enemyDamange;
                        Console.WriteLine(charName + " atacou " + charArray[i].charName + ": ele recebeu " + _enemyDamange + " pontos de dano, ficando com HP= " + charArray[i].charHP);
                        Console.WriteLine();
                        return;
                    }

                }
            }


        }
        public void PassTurn()
        {
            Console.WriteLine("Passou o turno!");
            if (coolDown > 0) { coolDown--; }
        }

    }
}
