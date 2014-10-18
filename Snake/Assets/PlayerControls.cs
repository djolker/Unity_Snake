using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerControls : MonoBehaviour 
{
	public CharacterController controller;
	public float playerSpeed = 3f;
	public float turnSpeed = 300f;

	private Vector3 shot = new Vector3(.1f,.1f,.1f);

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
			Fire();
		}
	}

	void Fire()
	{

		GameObject.CreatePrimitive (PrimitiveType.Cube).transform.localScale = shot;
	}
}