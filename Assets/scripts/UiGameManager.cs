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
    private const int STARTING_LIVES = 3;
    private const int STARTING_LEVEL = 0;

    // this is the worst way to check if a game has ended
    public bool GameOver = false;
    public GameObject GameOverUi;

    public TextMeshProUGUI levelCount;
    public lifeCounter lifeHandler;
    public sheepTimer timerHandler;


    public static UiGameManager CurrentGM;

    public static void startGame()
    {
        level = STARTING_LEVEL;
        lives = STARTING_LIVES;

        // TODO set up scenes in code
        // e.g 
        // scenes = new string[numberOfScenes]
        // scenes[i] = "sceneName" 
        // to use copy above line and replace numberOfScenes with the number of scenes and replicate the line below that for each new scene
    }


    

    void Awake()
    {
        CurrentGM = this;
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
        if (GameOver)
        {

        }
        else
        {
            levelTimer -= Time.deltaTime;
            levelCount.text = level.ToString("N");
            timerHandler.TimerActiveUpdate(levelTimer); 
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
            // TODO SceneManager.LoadScene(scenes[level]);

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
    public bool removeLife()
    {
        lifeHandler.removeLife();
        lives--; 
        return lives > 0;
    }

    // Call when your mini game has ended if player was killed, will automatically be called on scene load if player has zero lives
    public void EndGame()
    {
        GameOver = true;
        GameOverUi.SetActive(true);
    }
}
