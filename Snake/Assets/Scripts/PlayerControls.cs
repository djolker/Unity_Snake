/*
 * By DJ Olker
 * 
 * E-mail: dj.olker@gmail.com
 * 
 * Date: 9/22/2014
 */

using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class PlayerControls : MonoBehaviour 
{
	public CharacterController controller;
    public GameObject bullet;

    public float playerSpeed = 3f;
    public float turnSpeed = 300f;
    public int missles;
    public float increasedAttackSpeed;

    public DateTime lastFired;
    public int fireRate = 40;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
        missles++;

        lastFired = DateTime.Now.AddHours(-1);
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (this.gameObject != null)
        {
            float horizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            transform.Rotate(0, horizontal, 0);

            if (!(Input.GetKey(KeyCode.LeftShift)))
            {
                float vertical = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
                transform.Translate(0, 0, vertical);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                //DateTime currentTime = DateTime.Now;

                //if(lastFired.AddSeconds(fireRate) < currentTime)
                //{
                    Fire();
                //}
            }
        } else
        {
            this.enabled = false;
        }
	}

	void Fire()
	{
        float angle = 180 / (missles + 1);
        float currentAngle = 0;

        for (int i=0; i<missles; i++)
        {
            Debug.Log(currentAngle);
            bullet.transform.rotation = this.transform.rotation * Quaternion.AngleAxis(currentAngle, Vector3.down);
            bullet.transform.position = this.transform.position;
            bullet.transform.Translate(Vector3.forward * 1.5f);

            Instantiate (bullet, bullet.transform.position, bullet.transform.rotation);
            currentAngle += angle;
        }
        lastFired = DateTime.Now;
	}
}