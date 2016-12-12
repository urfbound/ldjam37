using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBall : MonoBehaviour {
    private float ballInitForce = 5f;

    private Rigidbody rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        //startMovement();
	}
    
    public void startMovement()
    {
        //rb.AddForce(new Vector3(0f, ballInitForce, 0f)); //fire the ball (consider adding a random x-component to the force)
    }
    
}
