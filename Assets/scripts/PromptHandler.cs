using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptHandler : MonoBehaviour
{

    public static string NextLevel;
    public static Sprite Prompt;
    public static float timerMax;

    public sheepTimer sheepHandler;
    public sceneSwitcher sceneHandler;

    public float curTimer;


    // Start is called before the first frame update
    void Start()
    {
        curTimer = timerMax;
        sheepHandler.init(curTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (curTimer > 0)
        {
            curTimer -= Time.deltaTime;
            sheepHandler.TimerActiveUpdate(curTimer);

            if (curTimer <= 0)
            {
                sceneHandler.LoadLevel(NextLevel,2);
            }
        }
    }
}
