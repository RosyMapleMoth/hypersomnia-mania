using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyMoose : MonoBehaviour
{
    public AudioSource sound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a");
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(transform.gameObject);
        }
    }
}
