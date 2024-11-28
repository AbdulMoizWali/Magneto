using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : Health
{
	[SerializeField] private TextMeshProUGUI HealthText;
	[SerializeField] private Slider HealthBarSlider;

	public override void Start()
	{
		base.Start();
		if (HealthText == null)
		{
			try
			{
				HealthText = GameObject.FindWithTag("HealthText").GetComponent<TextMeshProUGUI>();
				HealthBarSlider = GameObject.FindWithTag("HealthBarSlider").GetComponent<Slider>();
			}
			catch
			{
				return;
			}
		}
		updateHealthLife();
	}

	public override void OnCollisionEnter(Collision collision)
	{
		base.OnCollisionEnter(collision);
	}

	public void updateHealthLife()
	{
		if (HealthText != null)
		{
			HealthText.text = (healthSystem.GetHealthPercent() * 100).ToString() + "%";
		}
		if (HealthBarSlider != null)
		{
			HealthBarSlider.value = healthSystem.GetHealthPercent();
		}
	}

	public void updateHealthText(int health)
	{
		if (HealthText != null)
		{
			HealthText.text = health * 100 + "%";
		}
		if (HealthBarSlider != null)
		{
			HealthBarSlider.value = health;
		}
	}

	public override void Damage(int damage)
	{
		base.Damage(damage);
		updateHealthLife();
	}

	public override void Heal(int multiplyby)
	{
		base.Heal(multiplyby);
		updateHealthLife();
	}
}
