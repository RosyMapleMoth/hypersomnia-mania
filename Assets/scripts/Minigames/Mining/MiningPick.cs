using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningPick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //mouseWorldPos.z = 0f;

        //transform.position = mouseWorldPos;

        if(Input.GetMouseButtonDown(0))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0f, 0f, 45));
        }

        if(Input.GetMouseButtonUp(0))
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0f, 0f, -15));
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Debug.Log("a");
    //        if (collision.gameObject.TryGetComponent(out Ore ore))
    //        {
    //            ore.Hit();
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Ore ore = collision.GetComponent<Ore>();

    //    if(ore != null && Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("a");
    //        ore.Hit();
    //    }
    //}
}
