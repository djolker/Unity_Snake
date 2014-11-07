/*
 * By DJ Olker
 * 
 * E-mail: dj.olker@gmail.com
 * 
 * Date: 8/25/2014
 */


using UnityEngine;
using System.Collections;
using System;

public class NodeScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		JumpToNewPosition ();
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

	void OnTriggerEnter(Collider col)
	{
		JumpToNewPosition ();
	}

	void JumpToNewPosition()
	{
		System.Random rand = new System.Random ();
		float x = float.Parse(rand.Next (-3, 13).ToString());
		float z = float.Parse(rand.Next (-3, 13).ToString ());
		
		Vector3 vec = new Vector3 ();
		vec.x = x;
		vec.z = z;
		vec.y = 0.7392902f;
		this.transform.position = vec;
	}
}
