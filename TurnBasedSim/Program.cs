using System;
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
            int enemyAttack = 15;
            int attackCounter = 0;
            int healAmount = 5;

            Random random = new Random();

            Console.WriteLine("Welcome Player. Let's Begin Our Journey!");
            Console.WriteLine("Tell us your name:");

            playerName = Console.ReadLine();

            Console.WriteLine("Player HP " + playerHP + " Enemy HP " + enemyHP);

            while (playerHP > 0 && enemyHP > 0)
            {
                // Player turn
                Console.WriteLine($"--- {playerName}'s turn ---");
                Console.WriteLine("Player HP " + playerHP + " Enemy HP " + enemyHP);

                // Prompt the user until a valid choice is made
                string choice = "";
                while (choice != "a" && choice != "h")
                {
                    Console.WriteLine("Press 'a' to attack or 'h' to heal.");
                    choice = Console.ReadLine().ToLower();
                }

                if (choice == "a")
                {
                    attackCounter++;

                    if (attackCounter == 3)
                    {
                        enemyHP -= (playerAttack * 2);
                        Console.WriteLine($"{playerName} lands a critical attack and deals " + (playerAttack * 2) + " damage!");
                        if (enemyHP < 0) enemyHP = 0;
                        attackCounter = 0;
                    }
                    else
                    {
                        enemyHP -= playerAttack;
                        Console.WriteLine($"{playerName} lands an attack and deals " + playerAttack + " damage!");
                        if (enemyHP < 0) enemyHP = 0; // Ensure enemy HP doesn't go negative
                    }


                }
                else
                {
                    playerHP += healAmount;
                    Console.WriteLine($"{playerName} restores health by " + healAmount + " points!");
                }

                // Enemy turn
                if (enemyHP > 0)
                {
                    Console.WriteLine("--- Enemy's turn ---");
                    Console.WriteLine("Player HP " + playerHP + " Enemy HP " + enemyHP);
                    int enemyChoice = random.Next(0, 3);

                    if (enemyChoice == 0)
                    {
                        playerHP -= enemyAttack;
                        Console.WriteLine("The enemy lands an attack and deals " + enemyAttack + $" damage to {playerName}");
                        if (playerHP < 0) playerHP = 0; // Ensure player HP doesn't go negative
                    }
                    else if (enemyChoice == 1)
                    {
                        playerHP -= enemyAttack + 5;
                        Console.WriteLine("The enemy lands a critical attack and deals " + (enemyAttack + 5) + $" damage to {playerName}");
                        if (playerHP < 0) playerHP = 0; // Ensure player HP doesn't go negative
                    }
                    else
                    {
                        enemyHP += healAmount;
                        Console.WriteLine("The Enemy restores health by " + healAmount + " points!");
                        if (enemyHP < 0) enemyHP = 0; // Ensure enemy HP doesn't go negative
                    }
                }
            }

            if (playerHP <= 0)
            {
                Console.WriteLine("You have perished!");
            }
            if (enemyHP <= 0)
            {
                Console.WriteLine("Congratulations! You defeated the Enemy!");
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}
