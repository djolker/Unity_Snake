using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public bool dead;
    public int health;
    public GameObject target;
    public GameObject score;

    public float moveSpeed = 2f;

    private Vector3 dir;

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
            MoveTowardsPlayer();
            TurnTowardsPlayer();
            

            if (health <= 0)
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
        if (target)
        {
            dir = target.transform.position - this.transform.position;
            dir.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 3f * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Bullet(Clone)")
        {
            Debug.Log("Enemy Collide");
            health--;
        } else if (col.name == "Player")
        {
            //Debug.Log("PlayerHit");
            this.rigidbody.AddForce(Vector3.back * 30f);
        }
    }

    void BounceBack()
    {

    }
}
