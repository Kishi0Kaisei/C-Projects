﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedSim
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            int playerHP = 100;
            int enemyHP = 75;
            int playerAttack = 10;
            int enemyAttack = 20;
            int healAmount = 5;
            Random random = new Random();

            Console.WriteLine(" Welcome Player. Let's Begin Our Journey! ");
            Console.WriteLine(" Tell us your name ");

            playerName = Console.ReadLine();

            Console.WriteLine(" Player HP " + playerHP + " Enemy HP " + enemyHP);

            while (playerHP >= 0 && enemyHP >= 0)
            {
                // Player turn
                Console.WriteLine($"--- {playerName}'s turn ---");
                Console.WriteLine(" Player HP " + playerHP + " Enemy HP " + enemyHP);
                Console.WriteLine("Press 'a' to attack or 'h' to heal.");

                string choice = Console.ReadLine().ToLower();

                if (choice == "a")
                {
                    enemyHP -= playerAttack;
                    Console.WriteLine($"{playerName} lands an attack and deals" + playerAttack + "damage!");
                }
                else
                {
                    playerHP += healAmount;
                    Console.WriteLine($"{playerName} restores health by " + healAmount + "points!");
                }
               

                //Enemy turn
                if (enemyHP > 0)
                {
                    Console.WriteLine("--- Enemy's turn ---");
                    Console.WriteLine(" Player HP " + playerHP + " Enemy HP" + enemyHP);
                    int enemyChoice = random.Next(0, 3);

                    if (enemyChoice == 0)
                    {

                        playerHP -= enemyAttack;
                        Console.WriteLine("The enemy lands an attack and deals " + enemyAttack + $"damage to {playerName}");
                    }
                    else if (enemyChoice == 1)
                    {

                        playerHP -= enemyAttack+5;
                        Console.WriteLine("The enemy lands a critical attack and deals " + enemyAttack + $"damage to {playerName}");
                    }
                    else
                    {
                        enemyHP += healAmount;
                        Console.WriteLine("The Enemy restores health by " + healAmount + "points!");

                    }

                }

            }
            if (playerHP <= 0)
            {
                Console.WriteLine("You have perished !");
            }
            else if (enemyHP <= 0)
            {
                Console.WriteLine("Congratulations! You defeated the Enemy!");
            }

            Console.WriteLine(" Thank you for playing! ");
        }
    }
}