using UnityEngine;
using System.Collections;

public class GameEvents : MonoBehaviour {

	static GameObject score;
	int linkCount = 0;
	// Use this for initialization
	void Start () {
		if(score == null)
		score = GameObject.FindGameObjectWithTag("Score");
	}
	
	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter(Collider col)
	{
		AddToScore ();

		SpawnNewLink ();
	}

	void SpawnNewLink()
	{
		linkCount++;

		Vector3 vec;
		vec.x = 20;
		vec.z = 20;
		vec.y = 1;


		GameObject.CreatePrimitive (PrimitiveType.Sphere).transform.position = vec;
	}

	void AddToScore()
	{
		ScoreScript script = score.GetComponent<ScoreScript>();
		script.score += 1;
	}
}
