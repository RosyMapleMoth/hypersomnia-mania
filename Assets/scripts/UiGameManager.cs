using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiGameManager : MonoBehaviour
{

    private static string[] scenes;
    private static int level;
    private static int lives;
    private const int STARTING_LIVES = 3;
    private const int STARTING_LEVEL = 0;



    public static void startGame()
    {
        level = STARTING_LEVEL;
        lives = STARTING_LIVES;
        

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
