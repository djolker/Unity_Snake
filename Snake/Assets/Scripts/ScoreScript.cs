/*
 * By DJ Olker
 * 
 * E-mail: dj.olker@gmail.com
 * 
 * Date: 8/24/2014
 */


using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = "Score: " + score.ToString();
	}
}
