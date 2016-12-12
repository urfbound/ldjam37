using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTopCollider : MonoBehaviour {
    //public members
    public GameObject ballDissolveParticle;
    public GameObject cupDissolveParticle;

    //private members
    private int scoreMultiplier = 1;
    private int myColor = 0; //r=1, g=2, b=3 //it would have been cleaner to have a global enum for colours
    private bool multiColored = false;
    private List<GameObject> capturedBalls = new List<GameObject>();

	void OnTriggerEnter(Collider other)
    {
        if(myColor == 0) //this cup hasn't captured any bubbles
        {
            if (other.gameObject.CompareTag("RedBubble")) { capturedBalls.Add(other.gameObject); myColor = 1; }
            else if (other.gameObject.CompareTag("GrnBubble")) { capturedBalls.Add(other.gameObject); myColor = 2; }
            else if (other.gameObject.CompareTag("BluBubble")) { capturedBalls.Add(other.gameObject); myColor = 3; }
        }
        else //this cup has captured bubbles
        {
            if (other.gameObject.CompareTag("RedBubble"))
            {
                capturedBalls.Add(other.gameObject);
                if (myColor == 1) { GameManager.instance.addScore(100 * scoreMultiplier); updateMultiplier(); }
                else { multiColored = true; doScores(); }
            }
            else if (other.gameObject.CompareTag("GrnBubble"))
            {
                capturedBalls.Add(other.gameObject);
                if (myColor == 2) { GameManager.instance.addScore(100 * scoreMultiplier); updateMultiplier(); }
                else { multiColored = true; doScores(); }
            }
            else if (other.gameObject.CompareTag("BluBubble"))
            {
                capturedBalls.Add(other.gameObject);
                if (myColor == 3) { GameManager.instance.addScore(100 * scoreMultiplier); updateMultiplier(); }
                else { multiColored = true; doScores(); }
            }
            else { Destroy(other.gameObject); }//is this safe?
        }
    }

    public void doScores()
    {
        int scoreOut = 0;
        if(capturedBalls.Count > 16) { scoreOut += 10000; }
        else if(capturedBalls.Count > 12) { scoreOut += 4000; }
        else if (capturedBalls.Count > 8) { scoreOut += 2000; }
        else if (capturedBalls.Count > 4) { scoreOut += 1000; }
        else if (capturedBalls.Count > 2) { scoreOut += 500; }
        else { scoreOut += 100; }
        scoreOut *= scoreMultiplier;
        GameManager.instance.addScore(scoreOut);
        emptyCup();
    }

    private void updateMultiplier()
    {
        if (capturedBalls.Count > 16) { scoreMultiplier = 8; doScores(); }//16 is the most you can put in a cup
        else if (capturedBalls.Count > 12) { scoreMultiplier = 5; }
        else if (capturedBalls.Count > 8) { scoreMultiplier = 3; }
        else if (capturedBalls.Count > 4) { scoreMultiplier = 2; }
    }

    public void emptyCup()
    {
        //generate particle effects
        for(int i=0; i<capturedBalls.Count; i++)
        {
            GameObject objToDel = capturedBalls[i];
            Instantiate(ballDissolveParticle, objToDel.transform.position, Quaternion.identity);
            Destroy(objToDel);
        }
        capturedBalls = new List<GameObject>();
        multiColored = false; myColor = 0;
    }
}
