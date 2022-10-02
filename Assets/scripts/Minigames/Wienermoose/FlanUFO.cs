using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlanUFO : MonoBehaviour
{
    public float moveSpeed = 10f;

    public AudioSource bounceSound;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceSound.Play();
    }
}
