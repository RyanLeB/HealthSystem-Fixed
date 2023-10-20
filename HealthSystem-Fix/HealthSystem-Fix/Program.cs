using System;


class Player
{
    // creating variables

    private int maxHealth = 100;
    private int health;
    private int maxShield = 100;
    private int shield;
    private int xp;
    private int level;
    private int lives;

    
    // defining player
    
    public Player(int maxHealth, int maxShield, int startingLives)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;
        this.maxShield = maxShield;
        this.shield = maxShield;
        this.xp = 0;
        this.level = 1;
        this.lives = startingLives;
    }


    // take damage method

    public void TakeDamage(int damageAmount)
    {
        if (shield > 0)
        {
            int remainingDamage = damageAmount - shield;
            if (remainingDamage > 0)
            {
                shield = 0;
                health -= remainingDamage;
            }
            else
            {
                shield -= damageAmount;
            }
        }
        else
        {
            health -= damageAmount;
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
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
    }

    public void RechargeShield(int rechargeAmount)
    {
        shield += rechargeAmount;
        if (shield > maxShield)
        { 
            
            shield = maxShield;
        }
    }
    
    // "Get" methods
    
    public int GetCurrentShield()
    {
        return shield;
       
    }
    public int GetMaxShield()
    {
        if (maxShield > 100)
        {
            Console.WriteLine("You cannot exceed 100 shield!");
            maxShield = 100;
        }
        return maxShield;
    }
    public int GetExperienceRequiredForNextLevel()
    {
        return level * 100;
    }
   
    
    // Increase XP method
    
    public void IncreaseXP(int expAmount)
    {
        if (expAmount < 0)
        {
            Console.WriteLine();
            Console.WriteLine("Warning! cannot receive negative XP!, number has been changed to a positive value.");
            Console.WriteLine();
            expAmount *= -1;
        }
        
        
        xp += expAmount;
        
        while (xp >= GetExperienceRequiredForNextLevel())
        {
            xp -= GetExperienceRequiredForNextLevel();
            level++;
        }



    }

    // methods to get current and maximum health available
    public int GetCurrentHealth()
    {

        if (health == 100)
        {
            Console.WriteLine();
            Console.WriteLine("You are in perfect health!");
            Console.WriteLine();

        }
        if (health <= 90)
        {
            Console.WriteLine();
            Console.WriteLine("You are Healthy!");
            Console.WriteLine();
        }

        if (health <= 75)
        {
            Console.WriteLine();
            Console.WriteLine("You are Hurt!");
            Console.WriteLine();
        }

        if (health <= 50)
        {
            Console.WriteLine();
            Console.WriteLine("You are badly Hurt! Seek healing!");
            Console.WriteLine();
        }

        if (health <= 10)
        {
            Console.WriteLine();
            Console.WriteLine("You are in Imminent Danger!!! Find Assistance!");
            Console.WriteLine();

        }
        
        return health;

    }

    // Get methods

    public int GetMaxHealth()
    {
        if (maxHealth > 100)
        {
            Console.WriteLine("You cannot exceed 100 HP!");
            maxHealth = 100;
        }
        return maxHealth;
    }
    public void Revive()
    {
        if (lives > 0)
        {
            lives--;
            Heal(GetMaxHealth());
            RechargeShield(GetMaxShield());
        }
    }
    public int GetLives()
    {
        return lives;
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public int GetCurrentExperience()
    {
        return xp;
    }

    
    // ShowHUD method to display in console
    
    public void ShowHUD()
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


// Main 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to a health system simulator!");
        Console.WriteLine();
        Console.WriteLine("Made by RyanDot Games");
        Console.WriteLine();
        Console.WriteLine();


        Player player = new Player(100, 100, 3);

        player.ShowHUD();
        

        Console.WriteLine("You take 30 damage!");
        Console.WriteLine();

        player.TakeDamage(30);
        player.ShowHUD();


        Console.WriteLine("You've activated a buff which regenerates 20 shield!");
        Console.WriteLine();   
        player.RechargeShield(20);
        player.ShowHUD();

        Console.WriteLine("You take 100 damage!");
        Console.WriteLine();   
        player.TakeDamage(100);
        player.ShowHUD();


        Console.WriteLine("You defeat the monster and gain 150 experience!") ;
        Console.WriteLine();
        Console.WriteLine("You leveled up! You are now level 2!");
        player.IncreaseXP(-150);
        player.ShowHUD();


        Console.WriteLine("You drink a potion and heal 10 hp");
        player.Heal(10);
        player.ShowHUD();
        
        Console.WriteLine("You take a rest and regenerate your shield") ;
        player.RechargeShield(100);
        player.ShowHUD();

        Console.WriteLine("You encounter another monster!");
        Console.WriteLine();
        player.ShowHUD();

        Console.WriteLine("You take 200 damage!");
        player.TakeDamage(200);
        player.ShowHUD();

        Console.WriteLine("You have died, you will revive in a safe location");
        player.Revive();
        Console.WriteLine();
        player.ShowHUD();

        
        
        
        
        
        
        
        
        
        
        Console.ReadKey();
    }
}
    
    

    

    








    








    

    

    
    



    




   



