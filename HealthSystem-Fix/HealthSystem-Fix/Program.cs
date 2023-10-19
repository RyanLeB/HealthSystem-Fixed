﻿using System;

class HealthSystem
{
    private int maxHealth;
    private int currentHealth;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}

class ShieldSystem
{
    private int maxShield;
    private int currentShield;

    public ShieldSystem(int maxShield)
    {
        this.maxShield = maxShield;
        this.currentShield = maxShield;
    }

    public void TakeDamage(int damageAmount)
    {
        currentShield -= damageAmount;
        if (currentShield < 0)
        {
            currentShield = 0;
        }
    }

    public void Recharge(int rechargeAmount)
    {
        currentShield += rechargeAmount;
        if (currentShield > maxShield)
        {
            currentShield = maxShield;
        }
    }

    public int GetCurrentShield()
    {
        return currentShield;
    }

    public int GetMaxShield()
    {
        return maxShield;
    }
}

class ExpSystem
{
    private int experience;
    private int level;

    public ExpSystem()
    {
        experience = 0;
        level = 1;
    }

    public void GainExperience(int expAmount)
    {
        experience += expAmount;
        while (experience >= GetExperienceRequiredForNextLevel())
        {
            experience -= GetExperienceRequiredForNextLevel();
            level++;
        }
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public int GetCurrentExperience()
    {
        return experience;
    }

    public int GetExperienceRequiredForNextLevel()
    {
        return level * 100;
    }
}

class Player
{
    private HealthSystem health;
    private ShieldSystem shield;
    private ExpSystem exp;

    public Player(int maxHealth, int maxShield)
    {
        health = new HealthSystem(maxHealth);
        shield = new ShieldSystem(maxShield);
        exp = new ExpSystem();
    }

    public void TakeDamage(int damageAmount)
    {
        if (shield.GetCurrentShield() > 0)
        {
            int remainingDamage = damageAmount - shield.GetCurrentShield();
            if (remainingDamage > 0)
            {
                shield.TakeDamage(shield.GetCurrentShield());
                health.TakeDamage(remainingDamage);
            }
            else
            {
                shield.TakeDamage(damageAmount);
            }
        }
        else
        {
            health.TakeDamage(damageAmount);
        }
    }

    public void Heal(int healAmount)
    {
        health.Heal(healAmount);
    }

    public void RechargeShield(int rechargeAmount)
    {
        shield.Recharge(rechargeAmount);
    }

    public void GainExperience(int expAmount)
    {
        exp.GainExperience(expAmount);
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Player Status:");
        Console.WriteLine("Health: " + health.GetCurrentHealth());
        Console.WriteLine("Shield: " + shield.GetCurrentShield());
        Console.WriteLine("Level:" + exp.GetCurrentLevel());
        Console.WriteLine("Experience: " + exp.GetCurrentExperience() + " / " + exp.GetExperienceRequiredForNextLevel());
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to a health system simulator!");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();


        Player player = new Player(100, 50);

        player.DisplayStatus();

        Console.WriteLine("You take 30 damage!");
        Console.WriteLine();

        player.TakeDamage(30);
        player.DisplayStatus();

        player.RechargeShield(20);
        player.DisplayStatus();

        player.GainExperience(150);
        player.DisplayStatus();

        player.Heal(25);
        player.DisplayStatus();
        Console.ReadKey();
    }
}
