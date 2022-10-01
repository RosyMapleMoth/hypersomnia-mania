using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UiGameManager : MonoBehaviour
{

    
    private static string[] scenes;
    private static int level;
    private static int lives;
    private float levelTimer = 10f;
    private const int STARTING_LIVES = 6;
    private const int STARTING_LEVEL = 0;

    // this is the worst way to check if a game has ended
    public bool GameOver = false;
    public static bool Puased = true;
    public GameObject GameOverUi;

    public TextMeshProUGUI levelCount;
    public lifeCounter lifeHandler;
    public sheepTimer timerHandler;

    public static void startGame()
    {
        level = STARTING_LEVEL;
        lives = STARTING_LIVES;
        Puased = false; 
        
        // TODO set up scenes in code
        // e.g 
        // scenes = new string[numberOfScenes]
        // scenes[i] = "sceneName" 
        // to use copy above line and replace numberOfScenes with the number of scenes and replicate the line below that for each new scene
    }


    

    void Awake()
    {
        //startGame();
        lifeHandler.init(lives);
        timerHandler.init(levelTimer);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Puased)
        {

        }
        else if (GameOver)
        {

        }
        else if (levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;
            levelCount.text = "Level : "+ ((int)(level+1)).ToString("N");
            timerHandler.TimerActiveUpdate(levelTimer); 
        }
        else
        {
           loadNextScene(); 
        }
    }


    public void loadNextScene()
    {

        level++;
        if (lives <= 0)
        {
            EndGame();
        }
        else
        {
            // load level index scene
            //SceneManager.LoadScene(scenes[level]);
            SceneManager.LoadScene("example");

            // TODO add animation logic
        }
    }

    public void gainLife()
    {
        lifeHandler.addLife();
        lives++;
    }

    /// returns true if player is still alive
    // MAKE SURE TO HALT MINI GAME IF ON FALSE
    public void removeLife()
    {
        lifeHandler.removeLife();
        lives--; 
    }

    // Call when your mini game has ended if player was killed, will automatically be called on scene load if player has zero lives
    public void EndGame()
    {
        GameOver = true;
        GameOverUi.SetActive(true);
    }
}
