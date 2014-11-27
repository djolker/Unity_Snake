using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GMController : MonoBehaviour {

    public GameObject enemy;
    public GameObject healthItem;

    private object currentHealthItem;
    private Object currentEnemy;

    private List<object> enemies = new List<object>();

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    //if (currentEnemy == null)
        //{
        //    currentEnemy = Instantiate(enemy, JumpToNewPosition(), this.transform.rotation);
        //}

        if (enemies.Count != 4)
        {
            enemies.Add(Instantiate(enemy, JumpToNewPosition(), this.transform.rotation));
        }

        if (player == null)
        {
            GameOver();
        }

        if (currentHealthItem == null)
        {
            currentHealthItem = Instantiate(healthItem, spawnHealth(), this.transform.rotation);
        }
	}

    /// <summary>
    /// Jumps to new position.
    /// </summary>
    Vector3 JumpToNewPosition()
    {
        System.Random rand = new System.Random ();
        float x = float.Parse(rand.Next (-3, 13).ToString());
        float z = float.Parse(rand.Next (-3, 13).ToString());
        
        Vector3 vec = new Vector3 ();
        vec.x = x;
        vec.z = z;
        vec.y = .98f;

        return vec;
    }

    /// <summary>
    /// Spawns the health object.
    /// </summary>
    /// <returns>NewPositionForHealthObject</returns>
    Vector3 spawnHealth()
    {
        System.Random rand = new System.Random();
        float x = float.Parse(rand.Next(-3, 13).ToString());
        float z = float.Parse(rand.Next(-3, 3).ToString());

        Vector3 vec = new Vector3();
        vec.x = x;
        vec.z = z;
        vec.y = .98f;

        return vec;
    }

    void GameOver()
    {
        //GUIText gameOver = new GUIText();
        //gameOver.text = "Game Over!";
        //gameOver.enabled = true;
        Application.Quit();
    }
}
