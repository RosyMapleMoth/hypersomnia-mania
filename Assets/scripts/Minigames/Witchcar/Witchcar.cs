using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witchcar : MonoBehaviour
{
    private bool isHolding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseWorldPos.z = 0f;

        transform.position = mouseWorldPos;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        WitchcarItem item = collider.gameObject.GetComponent<WitchcarItem>();

        if(item != null && Input.GetMouseButton(0) && !isHolding)
        {
            item.isHeld = true;
            isHolding = true;
        }
        else if(item != null)
        {
            item.isHeld = false;
            isHolding = false;
        }
    }
}
