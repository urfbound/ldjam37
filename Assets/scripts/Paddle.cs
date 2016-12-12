using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float paddleSpd = 1.0f;

    private Vector3 playerPos = new Vector3(0.0f, -0.8f, 0.0f);

	// Use this for initialization
    /*
	void Start () {
		
	}
    */
	
	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpd);
        playerPos = new Vector3(Mathf.Clamp(xPos, -6.6f, 6.7f), -0.8f, 0.0f);
        transform.position = playerPos;
	}
}
