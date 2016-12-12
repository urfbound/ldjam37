using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEverythingCollider : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        int test = 1;
        Destroy(other.gameObject);
    }
}