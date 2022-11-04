using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 10f;
	public Vector3 offset;

	[SerializeField] private Transform UpperBoundary;
	[SerializeField] private Transform LowerBoundary;
	[SerializeField] private Transform RightBoundary;
	[SerializeField] private Transform LeftBoundary;

	private float height = 0f;
	private float width = 0f;
	private Camera cam;

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
	}

	void Start()
	{
		cam = Camera.main;
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

		/*height = 2f * cam.orthographicSize;
		width = height * cam.aspect;
		float x = Mathf.Clamp(transform.position.x, LeftBoundary.position.x, RightBoundary.position.x);
		//float y = Mathf.Clamp(transform.position.y, LowerBoundary.position.y , UpperBoundary.position.y - cam.orthographicSize);
		transform.position = new Vector3(x, transform.position.y, 0f);*/
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
