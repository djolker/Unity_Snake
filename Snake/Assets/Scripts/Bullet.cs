/*
 * By DJ Olker
 * 
 * E-mail: dj.olker@gmail.com
 * 
 * Date: 8/24/2014
 */


using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 20f;

	public Vector3 startingPos = new Vector3();

    public float damage;

	public GameObject self;

    public Vector3 basePos;

	// Use this for initialization
	void Start () 
	{
		startingPos = this.transform.position;

		self = this.gameObject;

		basePos = new Vector3 (-100, 0, 0);
	}

    public void setDamage(float dam)
    {
        this.damage = dam;
    }

	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject != null) 
		{
            if(this.transform.position != basePos)
            {
			    this.transform.Translate (Vector3.forward);
            }

			if (this.transform.position.z> 100 || this.transform.position.z<-100 || this.transform.position.x>100 || this.transform.position.x < -100)
			{
				Destroy (this.gameObject);
			}
		} 
		else 
		{
			this.enabled = false;
		}
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(this.gameObject);
    }
}
