using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	private const string Obstacle = "Obstacle";
	[SerializeField] private int Life;
	[SerializeField] private int DamagePercemtageWhenHitByObstacle;
	[SerializeField] private HealthBar healthBar;
	

	[HideInInspector] public int HealthChangeby;
	[HideInInspector] public HealthSystem healthSystem;

	public virtual void Start()
	{
		healthSystem = new HealthSystem(Life);
		healthBar.Setup(healthSystem);
		HealthChangeby = healthSystem.GetHealthByPercent(DamagePercemtageWhenHitByObstacle);
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag(Obstacle))
		{
			Damage(HealthChangeby);
			//Debug.Log("Damage: " + HealthChangeby * -1);
			if(healthSystem.GetHealthPercent() == 0 && gameObject.tag == "Player")
			{
				//For Online Multiplayer
				//collision.gameObject.GetComponent<Bullet>().MKillCount?.IncreaseKillCount();
				/*GetComponent<PlaneAnimation>()?.onDead();
				GetComponent<MultiplayerAnimation>()?.onDead();*/
			}
			if(healthSystem.GetHealthPercent() == 0 && gameObject.tag == "Robot")
			{
				/*if(collision.gameObject.GetComponent<Bullet>().firedby == Bullet.Planes.Player)
				{
					try
					{
						FindObjectOfType<MultiplayerKillCount>().IncreaseKillCount();
					}
					catch
					{
						return;
					}
				}*/
			}
		}
		else if(collision.gameObject.CompareTag("Heart"))
		{
			Heal();
		}
	}

	public virtual void Damage(int damage)
	{
		healthSystem.Damage(damage);
		
	}

	public void DamageByPercentage(int damagePercent)
	{
		Damage(healthSystem.GetHealthByPercent(damagePercent));
	}

	public float GetHealthPercentage()
	{
		return healthSystem.GetHealthPercent();
	}

	public void Heal()
	{
		Heal(1);
	}

	public virtual void Heal(int multiplyby)
	{
		healthSystem.Heal(HealthChangeby * multiplyby);
		
	}

	public int getHealthChangeBy()
	{
		return HealthChangeby;
	}

	public int getCurrentHealth()
	{
		return healthSystem.GetHealth();
	}

	public bool isHealthFull()
	{
		return healthSystem.isFull();
	}

	
}
