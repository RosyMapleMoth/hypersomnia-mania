using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyMoose : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("a");
        if(collision.gameObject.CompareTag("Player"))
        {
            //win
            Destroy(transform.gameObject);
        }
    }
}
