using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchcarItem : MonoBehaviour
{
    public bool isHeld;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            transform.position = player.transform.position;
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
