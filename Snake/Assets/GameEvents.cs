﻿using UnityEngine;
using System.Collections;

public class GameEvents : MonoBehaviour 
{
	static GameObject score;
	public GameObject link;

	//number of links behind the player
	int linkCount = 0;

	// Use this for initialization
	void Start() 
	{
		if(score == null)
		score = GameObject.FindGameObjectWithTag("Score");
	}
	
	// Update is called once per frame
	void Update() 
	{

	}

	void OnTriggerEnter(Collider col)
	{
		AddToScore();
		SpawnNewLink();
	}

	void SpawnNewLink()
	{
		linkCount++;

		Vector3 vec = this.transform.position;
		vec.x += 0;
		vec.y += .7f;
		vec.z -= linkCount;

		//GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		//sphere.transform.parent = this.transform;
		//sphere.transform.Translate(vec);

		//Vector3 test = sphere.transform.parent.position;
		//link.transform.parent;

		Instantiate (link, this.transform.position, this.transform.rotation);

		int x = 0;
	}

	void AddToScore()
	{
		ScoreScript script = score.GetComponent<ScoreScript>();
		script.score += 1;
	}
}