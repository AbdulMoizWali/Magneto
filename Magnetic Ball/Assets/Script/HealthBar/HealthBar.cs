using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public SpriteRenderer BarSprite;
    private HealthSystem healthSystem;


    public void Setup(HealthSystem healthSystem)
	{
		this.healthSystem = healthSystem;

		healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
	}

	private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
	{
		transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
		SpriteRenderer sr = BarSprite.GetComponent<SpriteRenderer>();
		if(healthSystem.GetHealthPercent()>= 0f && healthSystem.GetHealthPercent() <= 0.3f)
		{
			sr.color = Color.red;
		}
		else if (healthSystem.GetHealthPercent() >= 0.31f && healthSystem.GetHealthPercent() <= 0.7f)
		{
			sr.color = Color.yellow;
		}
		else
		{
			sr.color = Color.green;
		}
	}
}
