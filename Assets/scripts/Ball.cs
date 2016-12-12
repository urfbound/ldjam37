using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float ballInitForce = 5f;

    private Rigidbody rb;
    private bool ballInPlay;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        ballInPlay = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && !ballInPlay)
        {
            transform.parent = null; //unparent the ball from the paddle so it can move freely
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitForce, ballInitForce, 0.0f)); //fire the ball
        }
	}
}
