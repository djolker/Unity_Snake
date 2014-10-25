/*
 * By DJ Olker
 * 
 * E-mail: dj.olker@gmail.com
 * 
 * Date: 8/24/2014
 */

using UnityEngine;
using System.Collections;
using System.Threading;

public class PlayerControls : MonoBehaviour 
{
	public CharacterController controller;
	public float playerSpeed = 3f;
	public float turnSpeed = 300f;

	public GameObject bullet;

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
		Instantiate (bullet, this.transform.position, this.transform.rotation);
	}
}