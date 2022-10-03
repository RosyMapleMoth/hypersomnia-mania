using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloGoal : MonoBehaviour
{

    public  UiGameManager UI;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision the worst");

        if (col.CompareTag("player"))
        {
            Debug.Log("Collision");
            UI.winMiniGame();
        }
    }
}
