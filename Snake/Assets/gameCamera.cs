using UnityEngine;
using System.Collections;
public class gameCamera : MonoBehaviour 
{
	public GameObject player;

	public float offsetX = 0;
	public float offsetZ = -6;
	public float offsetY = 10;

	public float maximumDistance = 2;
	public float playerVelocity = 10;
	
	private float movementX;
	private float movementY;
	private float movementZ;

	void Start()
	{
		Vector3 vec = new Vector3 ();
		vec.x = 60;
		this.transform.Rotate (vec);
	}

	void Update () 
	{
		movementX = ((player.transform.position.x + offsetX - this.transform.position.x))/maximumDistance;
		movementY = ((player.transform.position.y + offsetY - this.transform.position.y)) / maximumDistance;
		movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z))/maximumDistance;

		this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), (movementY * playerVelocity * Time.deltaTime), (movementZ * playerVelocity * Time.deltaTime));
	}
}