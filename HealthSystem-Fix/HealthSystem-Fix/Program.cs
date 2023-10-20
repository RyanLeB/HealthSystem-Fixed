using System;
using System.Diagnostics;

namespace HealthSystem
{
    internal class Program
    {
        // creating variables

        static int maxHealth = 100;
        static int health;
        static int maxShield = 100;
        static int shield;
        static int xp;
        static int level;
        static int lives;


        
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to a health system simulator!");
            Console.WriteLine();
            Console.WriteLine("Made by RyanDot Games");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit!");
            Console.WriteLine();

            health = 100;
            shield = 100;
            level = 1;





            ShowHUD();


            Console.WriteLine("You take 30 damage!");
            Console.WriteLine();

            TakeDamage(30);
            ShowHUD();


            Console.WriteLine("You've activated a buff which regenerates 20 shield!");
            Console.WriteLine();
            RechargeShield(20);
            ShowHUD();

            Console.WriteLine("You take 100 damage!");
            Console.WriteLine();
            TakeDamage(100);
            ShowHUD();


            Console.WriteLine("You defeat the monster and gain 150 experience!");
            Console.WriteLine();
            Console.WriteLine("You leveled up! You are now level 2!");
            Console.WriteLine();
            IncreaseXP(150);
            ShowHUD();


            Console.WriteLine("You drink a potion and heal 10 hp");
            Heal(10);
            ShowHUD();

            Console.WriteLine("You take a rest and regenerate your shield");
            RechargeShield(100);
            ShowHUD();

            Console.WriteLine("You encounter another monster!");
            Console.WriteLine();
            ShowHUD();

            Console.WriteLine("You take 200 damage!");
            TakeDamage(200);
            ShowHUD();

            Console.WriteLine("You have died, you will revive in a safe location");
            Revive();
            Console.WriteLine();
            ShowHUD();











            Console.ReadKey();
        }



        // take damage method

        static void TakeDamage(int damage)
        {
            if (damage < 0)

                damage = 0;




            if (shield > 0)
            {
                int remainingDamage = damage - shield;
                if (remainingDamage > 0)
                {
                    shield = 0;
                    health -= remainingDamage;
                }
                else
                {
                    shield -= damage;
                }
            }
            else
            {
                health -= damage;
            }
            if (health < 0)
            {
                if (lives > 0)
                {
                    lives--;
                    health = maxHealth;
                    shield = maxShield;
                }
                else
                {
                    health = 0;
                }
            }
        }




        // healing and shield recharge method
        static void Heal(int healAmount)
        {
            if (healAmount < 0)

                healAmount = 0;



            health += healAmount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }

        }

        static void RechargeShield(int rechargeAmount)
        {
            if (rechargeAmount < 0)

                rechargeAmount = 0;

            shield += rechargeAmount;
            if (shield > maxShield)
            {

                shield = maxShield;
            }
        }

        // "Get" methods

        static int GetCurrentShield()
        {
            return shield;

        }
        static int GetMaxShield()
        {
            if (maxShield > 100)
            {
                Console.WriteLine("You cannot exceed 100 shield!");
                maxShield = 100;
            }
            return maxShield;
        }
        static int GetExperienceRequiredForNextLevel()
        {
            return level * 100;
        }


        // Increase XP method

        static void IncreaseXP(int expAmount)
        {
            if (expAmount < 0)

                return;




            xp += expAmount;

            while (xp >= GetExperienceRequiredForNextLevel())
            {
                xp -= GetExperienceRequiredForNextLevel();
                level++;
            }



        }

        // methods to get current and maximum health available
        static int GetCurrentHealth()
        {
            return health;


        }

        // Get methods

        static int GetMaxHealth()
        {
            if (maxHealth > 100)
            {
                Console.WriteLine("You cannot exceed 100 HP!");
                maxHealth = 100;
            }
            return maxHealth;
        }
        static void Revive()
        {
            if (lives > 0)
            {
                lives--;
                Heal(GetMaxHealth());
                RechargeShield(GetMaxShield());
            }
        }
        static int GetLives()
        {
            return lives;
        }

        static int GetCurrentLevel()
        {
            return level;
        }

        static int GetCurrentExperience()
        {
            return xp;
        }


        // ShowHUD method to display in console

        static void ShowHUD()
        {
            Console.WriteLine("Player Status:");
            Console.WriteLine("Lives Remaining: " + lives);
            Console.WriteLine("Health: " + GetCurrentHealth() + " / " + GetMaxHealth());
            Console.WriteLine("Shield: " + GetCurrentShield() + " / " + GetMaxShield());
            Console.WriteLine("Level:" + GetCurrentLevel());
            Console.WriteLine("Experience: " + GetCurrentExperience() + " / " + GetExperienceRequiredForNextLevel());
            Console.WriteLine();
        }





        

    }

}

   


// Main 



    
    
    
    
    
    
    
    

    

    








    








    

    

    
    



    




   



