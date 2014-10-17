using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour 
{
	public CharacterController controller;
	public float playerSpeed = 3f;
	public float turnSpeed = 300f;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate (0, horizontal, 0);

		if (!(Input.GetKey (KeyCode.LeftShift)))
		{
			float vertical = Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;
			transform.Translate (0, 0, vertical);
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			Debug.Log("space hit!");
		}
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Collision!!");
	}
}
