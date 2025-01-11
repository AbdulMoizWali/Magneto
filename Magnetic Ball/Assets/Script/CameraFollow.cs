using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 10f;
	public Vector3 offset;
	[SerializeField] private float z_Max_Rotation = -10f;
	[SerializeField] private float z_Min_Rotation = 10f;
	[SerializeField] private float rotationSpeed;

	/*[SerializeField] private Transform UpperBoundary;
	[SerializeField] private Transform LowerBoundary;
	[SerializeField] private Transform RightBoundary;
	[SerializeField] private Transform LeftBoundary;*/

	private float height = 0f;
	private float width = 0f;
	private Camera cam;
	private Transform Mcam;
	private Quaternion OrgRotation;
	private float rotation;

	//public bool ReachedtoBoundary = false;

	private void Awake()
	{
		try
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		catch
		{
			target = null;
			StartCoroutine(waitForPlaneSpawn());
		}
		OrgRotation = transform.rotation;
	}

	void Start()
	{
		cam = Camera.main;
		Mcam = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
		height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		/*UpperBoundary = GameObject.Find("UpperBoundary").GetComponent<Transform>();
		LowerBoundary = GameObject.Find("LowerBoundary").GetComponent<Transform>();
		RightBoundary = GameObject.Find("RightBoundary").GetComponent<Transform>();
		LeftBoundary = GameObject.Find("LeftBoundary").GetComponent<Transform>();*/
	}

	private void FixedUpdate()
	{
		if (target == null)
		{
			return;
		}
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

		/*
		//Working
		if (target.position.y > 1)
		{
			if (rotation <= z_Max_Rotation)
			{
				return;
			}
			rotation -= rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}
		else if (target.position.y < -1)
		{
			if(rotation >= z_Min_Rotation)
			{
				return;
			}
			rotation += rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}
		else
		{
			rotation = Mathf.MoveTowardsAngle(rotation, 0, rotationSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}*/

		
		/*Debug.Log(Vector3.Dot(target.GetComponent<Rigidbody>().velocity.normalized, new Vector3(1f, 1f, 0)));
		Debug.DrawLine(Vector3.zero, target.GetComponent<Rigidbody>().velocity, Color.blue, 5f);
		Debug.DrawLine(Vector3.zero, new Vector3(1f, 1f, 0), Color.yellow, 1f);*/
		if ((Facing_Direction(1f, 1f) <= (Facing_Direction(0f, 1f)) && (Facing_Direction(1f, 1f) >= (Facing_Direction(1f, 0f)))) || (Facing_Direction(-1f, -1f) <= (Facing_Direction(0f, -1f)) && (Facing_Direction(-1f, -1f) >= (Facing_Direction(-1f, 0f)))))
		{
			//Debug.Log("/ Diagonal");
			if (rotation <= z_Max_Rotation)
			{
				return;
			}
			rotation -= rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}
		else if ((Facing_Direction(1f, -1f) <= (Facing_Direction(0f, 1f)) && (Facing_Direction(1f, -1f) >= (Facing_Direction(1f, 0f)))) || (Facing_Direction(-1f, 1f) <= (Facing_Direction(0f, -1f)) && (Facing_Direction(-1f, 1f) >= (Facing_Direction(-1f, 0f)))))
		{
			if (rotation >= z_Min_Rotation)
			{
				return;
			}
			//Debug.Log("Diagonal \\");
			rotation += rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}


		/*
		Debug.Log(Vector3.Dot(target.GetComponent<Rigidbody>().velocity.normalized, new Vector3(0.5f, 0.5f, 0)));
		Debug.DrawLine(Vector3.zero, target.GetComponent<Rigidbody>().velocity, Color.blue, 1f);
		Debug.DrawLine(Vector3.zero, new Vector3(0.5f, 0.5f, 0), Color.yellow, 1f);
		if ((Facing_Direction(-1, -0.8f) <= 1.08f) && (Facing_Direction(-1, -0.8f) >= 0.6f))
		{
			if (rotation <= z_Max_Rotation)
			{
				return;
			}
			rotation -= rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}
		else if ((Facing_Direction(1, 0.8f) <= 1.08f) && (Facing_Direction(1, 0.8f) >= 0.6f))
		{
			if (rotation >= z_Min_Rotation)
			{
				return;
			}
			Debug.Log("True");
			rotation += rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}
		 */


		/*else
		{
			rotation = Mathf.MoveTowardsAngle(rotation, 0, rotationSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Euler(OrgRotation.eulerAngles.x, OrgRotation.eulerAngles.y, rotation);
		}*/



		/*height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		float x = Mathf.Clamp(transform.position.x, LeftBoundary.position.x, RightBoundary.position.x);
		//float y = Mathf.Clamp(transform.position.y, LowerBoundary.position.y , UpperBoundary.position.y - cam.orthographicSize);
		transform.position = new Vector3(x, transform.position.y, 0f);*/
	}

	private float Facing_Direction(float x, float y)
	{
		return Vector3.Dot(target.GetComponent<Rigidbody>().linearVelocity.normalized, new Vector3(x, y, 0));
	}

	IEnumerator waitForPlaneSpawn()
	{
		yield return new WaitWhile(() => GameObject.FindGameObjectWithTag("Player") == null);
		try
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		catch
		{
			target = null;
		}
	}

}
