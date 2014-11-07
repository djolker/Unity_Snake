using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public int health;
    public GameObject target;

    public GameObject score;

    public float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
        health = 10;
        target = GameObject.FindGameObjectWithTag("Player");    
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject != null)
        {
            if (Vector3.Distance(this.transform.position, this.target.transform.position) < 20)
            {
                MoveTowardsPlayer();
            }

            if (health < 0)
            {
                die();
            }
        }
        else
        {
            this.enabled = false;
        }
	}

    void die()
    {
        ScoreScript script = score.GetComponent<ScoreScript>();
        script.score += 2;

        Destroy(this.gameObject);
    }

    void MoveTowardsPlayer()
    {

    }
}
