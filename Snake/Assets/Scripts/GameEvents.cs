/*
 * By DJ Olker
 * 
 * E-mail: dj.olker@gmail.com
 * 
 * Date: 8/25/2014
 */

using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class GameEvents : MonoBehaviour 
{
	static GameObject score;
	public GameObject link;
    public int health;

    public Transform lastLink;

	public List<Vector3> path = new List<Vector3> ();

	//number of links behind the player
	int linkCount = 0;

	// Use this for initialization
	void Start() 
	{
        health = 10;

        //SpawnNewLink();
		if (score == null) 
		{
			score = GameObject.FindGameObjectWithTag ("Score");
		}
	}
	
	// Update is called once per frame
	void Update() 
	{
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            SpawnNewLink();
        }
    }

	void OnTriggerEnter(Collider col)
	{
        if (col.name == "Node")
        {
            AddToScore(1);
            SpawnNewLink();
        }
        else if(col.name == "Enemy")
        {
            BounceBack();
        }
	}

	void SpawnNewLink()
	{
        try
        {
            if (lastLink == null)
            {
                lastLink = this.gameObject.transform.Find("HingeAttach");
            }
    		linkCount++;

    		Vector3 vec = this.transform.position;
    		vec.x += 0;
    		vec.y += .7f;
    		vec.z -= linkCount;

    		//GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);

    		//sphere.transform.parent = this.transform;
    		//sphere.transform.Translate(vec);

    		//Vector3 test = sphere.transform.parent.position;
    		
    		GameObject newLink = Instantiate (link, this.transform.position, this.transform.rotation) as GameObject;

            HingeJoint obj = newLink.hingeJoint;

            obj.connectedBody = lastLink.transform.rigidbody;


            lastLink = newLink.transform;
    		int x = 0;
        }
        catch
        {

        }
	}

    void BounceBack()
    {
        this.transform.Translate(Vector3.back * Time.deltaTime * 20);
    }

	void AddToScore(int add)
	{
		ScoreScript script = score.GetComponent<ScoreScript>();
		script.score += add;
	}
}