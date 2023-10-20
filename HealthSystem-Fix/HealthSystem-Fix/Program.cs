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

        // Main method
        
        static void Main(string[] args)
        {

            // Testing methods (Remove comment to test!)
            // UnitTestHealthSystem();
            // UnitTestXPSystem();



            Console.WriteLine("Welcome to a health system simulator!");
            Console.WriteLine();
            Console.WriteLine("Made by RyanDot Games");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit!");
            Console.WriteLine();


            health = 100;
            shield = 100;
            level = 1;
            lives = 3;



            ShowHUD();


            Console.WriteLine("You take 30 damage!");
            Console.WriteLine();

            TakeDamage(30);
            ShowHUD();


            Console.WriteLine("You've activated a buff which regenerates 20 shield!");
            Console.WriteLine();
            RegenerateShield(20);
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
            RegenerateShield(100);
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

        // testing methods
        
        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }

        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
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
                health = 0;
              
                
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

        static void RegenerateShield(int rechargeAmount)
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

       

        // method to get maximum health available
       

        static int GetMaxHealth()
        {
            if (maxHealth > 100)
            {
                Console.WriteLine("You cannot exceed 100 HP!");
                maxHealth = 100;
            }
            return maxHealth;
        }
        
        
        // Revive method
        
        static void Revive()
        {
            if (lives > 0)
            {
                lives--;
                Heal(GetMaxHealth());
                RegenerateShield(GetMaxShield());
            }
        }
        


        // ShowHUD method to display in console

        static void ShowHUD()
        {
            Console.WriteLine("Player Status:");
            Console.WriteLine("Lives Remaining: " + lives);
            Console.WriteLine("Health: " + health + " / " + maxHealth);
            Console.WriteLine("Shield: " + shield + " / " + maxShield);
            Console.WriteLine("Level:" + level);
            Console.WriteLine("Experience: " + xp + " / " + GetExperienceRequiredForNextLevel());
            Console.WriteLine();
        }





        

    }

}

   


// Main 



    
    
    
    
    
    
    
    

    

    








    








    

    

    
    



    




   



