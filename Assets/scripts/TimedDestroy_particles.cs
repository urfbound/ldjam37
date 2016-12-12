using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy_particles : MonoBehaviour {
    public float destroyTime = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
