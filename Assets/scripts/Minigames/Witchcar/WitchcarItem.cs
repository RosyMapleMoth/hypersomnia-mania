using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchcarItem : MonoBehaviour
{
    public bool isHeld;
    private GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            transform.position = player.transform.position;

            if(!rb.IsSleeping())
            {
                rb.Sleep();
            }
        }
        else
        {
            if(rb.IsSleeping())
            {
                rb.WakeUp();
            }
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name == "Cauldron")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
