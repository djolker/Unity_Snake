using UnityEngine;
using System.Collections;
using System;

public class NodeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{
		System.Random rand = new System.Random ();
		float x = float.Parse(rand.Next (-10, 10).ToString());
		float y = float.Parse(rand.Next (-10, 10).ToString ());

		Vector3 vec = new Vector3 ();
		vec.x = x;
		vec.z = y;

		this.transform.Translate (vec);
	}
}
