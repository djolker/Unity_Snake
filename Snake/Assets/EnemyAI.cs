using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public int health;
    public GameObject target;

    public float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
        health = 10;
        target = GameObject.FindGameObjectWithTag("Player");    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Vector3.Distance(this.transform.position, this.target.transform.position) < 20)
        {

        }
	}
}
