using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject brickParticle;
    public GameObject bubbleToGen;

    private float bubbleOutInitForce = 650f;
    private string tgtTag;

    void Awake()
    {
        if (this.tag == "GrnBrick") { tgtTag = "GrnBubble"; }
        else if(this.tag == "RedBrick") { tgtTag = "RedBubble"; }
        else { tgtTag = "BluBubble"; }
    }

    void OnCollisionEnter(Collision other)
    {
        int breakMe = 69;
        //if (other.gameObject.tag != null)//only balls can break bricks
        //{
            if (other.gameObject.tag == "PlayerBall")//only the player ball can break bricks of any colour
            {
                Instantiate(brickParticle, transform.position, Quaternion.identity);
                GameManager.instance.destroyBrick();
                Destroy(gameObject);
                GameObject myBubble = Instantiate(bubbleToGen, transform.position, Quaternion.identity);
                Rigidbody myBubRb = myBubble.GetComponent<Rigidbody>();
                myBubRb.AddForce(0f, bubbleOutInitForce, 0f);
            }
            else if(other.gameObject.tag == tgtTag)
            {
                Instantiate(brickParticle, transform.position, Quaternion.identity);
                GameManager.instance.destroyBrick();
                //TODO scoring
                Destroy(gameObject);
            }
        //}
    }
}
