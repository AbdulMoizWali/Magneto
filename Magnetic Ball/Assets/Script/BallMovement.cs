using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BallMovement : MonoBehaviour
{
	[SerializeField] private Transform TopCube;
	[SerializeField] private Transform BottomCube;
	[SerializeField] private Transform LeftCube;
	[SerializeField] private Transform RightCube;

	/*[SerializeField] private float horizontalspeed = 5f;
	[SerializeField] private float verticalspeed = 3f;*/

	[SerializeField] private float ForceOfAttraction = 30f;
	private Rigidbody rb;

	private Vector3 X;
	private Vector3 Y;

	private bool buttonPressed;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (buttonPressed)
		{
			FindClosestMagneticPoleAndMove();
		}
		else
		{
			MoveTowardBottom();
		}
		/*X = Vector3.zero;
		Y = Vector3.zero;
		if (Input.GetAxis("Horizontal") > 0)
		{
			if (rb.velocity.x < horizontalspeed)
			{
				X = new Vector3(horizontalspeed, 0f, 0f);
			}
		}
		if (Input.GetAxis("Vertical") > 0)
		{
			if (rb.velocity.y < verticalspeed)
			{
				Y = new Vector3(0f, verticalspeed, 0f);
			}
		}
		rb.velocity = X + Y;*/
		//transform.position = new Vector2(Mathf.Clamp(transform.position.x, LeftCube.position.y, RightCube.position.y), Mathf.Clamp(transform.position.y, BottomCube.position.y, TopCube.position.y));
		//buttonPressed = false;
	}

	/*private void FixedUpdate()
	{
		*//*if (!buttonPressed)
		{
			//rb.velocity = rb.velocity * 0.99f * Time.deltaTime;
		}*//*
	}*/

	public void ButtonPressed()
	{
		buttonPressed = true;
	}

	public void ButtonReleased()
	{
		buttonPressed = false;
		//rb.velocity = transform.right * horizontalspeed;
	}

	private void MoveTowardBottom()
	{
		//rb.velocity = (Vector3.down - transform.position) * Time.deltaTime;
	}

	private void FindClosestMagneticPoleAndMove()
	{
		GameObject[] poles = GameObject.FindGameObjectsWithTag("MagneticPole");
		float Distance = float.MaxValue;
		float SDistance = float.MaxValue;
		Transform ClosestPole = null;
		Transform SecondClosestPole = null;

		for (int i = 0; i < poles.Length; i++)
		{
			if(Vector3.Distance(transform.position, poles[i].transform.position) < Distance)
			{
				SecondClosestPole = ClosestPole;
				SDistance = Distance;
				ClosestPole = poles[i].transform;
				Distance = Vector3.Distance(transform.position, poles[i].transform.position);
			}
		}

		MoveTowardMagneticPole(ClosestPole, ForceOfAttraction);
	}

	private void MoveTowardMagneticPole(Transform MagneticPole, float ForceOfAttraction)
	{
		//transform.position = Vector3.MoveTowards(transform.position, MagneticPole.position, ForceOfAttraction);
		Debug.DrawLine(MagneticPole.position, transform.position, Color.red, 1f);
		/*DecreasetheCurrentVelocity();
		while (rb.velocity.magnitude > 0.5)
		{
			await Task.Yield();
		}*/
		rb.AddForce((MagneticPole.position - transform.position).normalized * ForceOfAttraction, ForceMode.Force);
	}

	private void DecreasetheCurrentVelocity()
	{
		while (rb.linearVelocity.magnitude > 0.5)
		{
			rb.linearVelocity = rb.linearVelocity * 0.95f * Time.deltaTime;
		}
	}

	/*private void FixedUpdate()
	{
		rb.velocity -= new Vector3(getValueByPercentage(rb.velocity.x, 50), rb.velocity.y, 0);
		
	}

	private float getValueByPercentage(float value, int percentage)
	{
		return value * (percentage/100);
	}*/
}
