using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCake : MonoBehaviour
{
    private float TTL;

    // Start is called before the first frame update
    void Start()
    {
        TTL = Time.time + 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(TTL < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
