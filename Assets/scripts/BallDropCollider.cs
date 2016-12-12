using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropCollider : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != null)
        {
            if (other.gameObject.CompareTag("PlayerBall"))
            {
                GameManager.instance.loseLife();
            }
            else if (other.gameObject.CompareTag("RedBubble"))
            {
                rmBubbleFromPlay(other.gameObject.GetComponent<Rigidbody>());
                //do the scoring TODO
            }
            else if (other.gameObject.CompareTag("GrnBubble"))
            {
                rmBubbleFromPlay(other.gameObject.GetComponent<Rigidbody>());
                //do the scoring TODO
            }
            else if (other.gameObject.CompareTag("BluBubble"))
            {
                rmBubbleFromPlay(other.gameObject.GetComponent<Rigidbody>());
                //do the scoring TODO
            }
        }
    }

    private void rmBubbleFromPlay(Rigidbody bubbleToRm)
    {
        bubbleToRm.isKinematic = false;
        bubbleToRm.useGravity = true;
    }
}
