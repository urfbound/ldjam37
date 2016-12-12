using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupAfterDeath : MonoBehaviour {
    private BoxCollider bc;
    private bool isInCleanup = false;

    private void Awake()
    {
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedBubble"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("GrnBubble"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BluBubble"))
        {
            Destroy(other.gameObject);
        }
    }

	public void startCleanUp()
    {
        bc.enabled = true;
        Invoke("endCleanUp", 0.1f);
    }

    private void endCleanUp()
    {
        bc.enabled = false;
    }
}
