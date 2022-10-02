using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyMoose : MonoBehaviour
{
    public UiGameManager game;
    public AudioSource sound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            game.winMiniGame();
        }
    }
}
