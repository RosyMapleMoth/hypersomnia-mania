using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlanUFO : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }
}
