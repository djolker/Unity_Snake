using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public bool dead;
    public int health;
    public GameObject target;
    public GameObject score;

    public float moveSpeed = 2f;

	// Use this for initialization
	void Start () {
        health = 10;
        target = GameObject.Find("Player");    
        dead = false;

        if (score == null) 
        {
            score = GameObject.FindGameObjectWithTag("Score");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject != null)
        {
            if (Vector3.Distance(this.transform.position, this.target.transform.position) < 20)
            {
                MoveTowardsPlayer();
                //TurnTowardsPlayer();
            }

            if (health < 0)
            {
                if(!dead)
                {
                    die();
                }
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

        dead = true;
        Destroy(this.gameObject);
    }

    void MoveTowardsPlayer()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void TurnTowardsPlayer()
    {
        this.transform.Rotate(Vector3.RotateTowards(this.transform.position, target.transform.position,2f,2f));
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Bullet(Clone)")
        {
            Debug.Log("Enemy Collide");
            health--;
        }
    }
}
