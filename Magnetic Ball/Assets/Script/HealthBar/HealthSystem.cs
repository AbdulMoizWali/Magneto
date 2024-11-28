using System;
public class HealthSystem
{
	public event EventHandler OnHealthChanged;

	private int health;
	private int healthMax;
	private float FhealthMax;
	public HealthSystem(int healthMax)
	{
		this.healthMax = healthMax;
		health = healthMax;
		FhealthMax = healthMax;
	}

	public void Damage(int damage)
	{
		health -= damage;
		if(health < 0)
		{
			health = 0;
		}
		if(OnHealthChanged != null)
		{
			OnHealthChanged(this, EventArgs.Empty);
		}
	}

	public void Heal(int heal)
	{
		health += heal;
		if(health > healthMax)
		{
			health = healthMax;
		}
		if (OnHealthChanged != null)
		{
			OnHealthChanged(this, EventArgs.Empty);
		}
	}

	public int GetHealth()
	{
		return health;
	}

	public int GetHealthByPercent(int Percentage)
	{
		return (int)((Percentage / 100f) * healthMax);
	}

	public float GetHealthPercent()
	{
		return (float)Convert.ToDouble(String.Format("{0:0.00}", health / FhealthMax));
	}

	public bool isFull()
	{
		if (health == healthMax)
		{
			return true;
		}
		return false;
	}
}
