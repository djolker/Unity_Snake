using UnityEngine;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System;

public class Path : MonoBehaviour {

	public GameObject player = new GameObject();
	public List<Vector3> path = new List<Vector3>();

	public DateTime timeA = new DateTime();

	// Use this for initialization
	void Start () {
		timeA = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeA.AddSeconds (10) == DateTime.Now) 
		{
			path.Add (player.transform.position);
			timeA = DateTime.Now;
		}

	}
}
