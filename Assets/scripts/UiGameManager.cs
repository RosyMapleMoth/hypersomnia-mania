using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UiGameManager : MonoBehaviour
{
    /// <summary>
    /// the scenes to go through in order DO NOT UPDATE OUTSIDE OF PREFAB
    /// </summary>
    private static string[] scenes = {"example"};

    /// <summary>
    /// Turn on to reload the the DEBUG Scene 
    /// </summary>
    public bool DEBUG_MODE;

    /// <summary>
    /// set to the name of the scene you want to load
    /// </summary>
    //public string DEBUG_SCENE;

    // current level
    private static int level;
    // current lives
    private static int lives;

    // tacks how long we have been in level
    private float levelTimer = 10f;

    // STARTING values
    private const int STARTING_LIVES = 3;
    private const int STARTING_LEVEL = 0;



    /// <summary>
    /// track what state the game is in
    /// TODO change to enums
    /// </summary>
    public bool GameOver = false;
    public static bool Puased = true;
    
    public GameObject GameOverUi;


    // UI handlers see other files
    public TextMeshProUGUI levelCount;
    public lifeCounter lifeHandler;
    public sheepTimer timerHandler;



    /// <summary>
    /// depricated switch over to startGamefromLevel
    /// </summary>
    private static void startGame()
    {
        level = STARTING_LEVEL;
        lives = STARTING_LIVES;
        Puased = false; 
    }


    /// <summary>
    /// Use to start game from a scene using scene index, review const scenes variable at top of file to know index
    /// </summary>
    /// <param name="levelToStartFrom">index of scene to start at</param>
    public static void StartGameFromlevel(int levelToStartFrom)
    {
        startGame();
        SceneManager.LoadScene(scenes[levelToStartFrom]);
    }

    /// <summary>
    /// Use this to start at a specific scene if you do not know the index of the scene in order
    /// </summary>
    /// <param name="levelToStartFrom">Name of scene to load</param>
    public static void StartGameFromScene(string levelToStartFrom)
    {
        startGame();
        SceneManager.LoadScene(levelToStartFrom);
    }


    void Awake()
    {
        if (DEBUG_MODE)
        {
            startGame();
        }
        //startGame();
        lifeHandler.init(lives);
        timerHandler.init(levelTimer);
        levelCount.text = "Level : "+ ((int)(level+1)).ToString();

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
            timerHandler.TimerActiveUpdate(levelTimer); 
        }
        else
        {
           loadNextScene(); 
        }
    }


    /// <summary>
    /// internal use only, will handle loading next scene
    /// </summary>
    private void loadNextScene()
    {
        // while in debug mode reload the same scene over and over level will not tic up properly nor will game over screen occure
        if (DEBUG_MODE)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {

        }


        level++;
        if (lives <= 0)
        {
            // if zero lives end game
            EndGame();
        }
        else
        {
            try
            {
                SceneManager.LoadScene(scenes[level]);
            }
            catch
            {
                // if we do not have any more levels continuasly reload last scene
                SceneManager.LoadScene(scenes[scenes.Length-1]);
            }

        }
    }


    /// <summary>
    /// call to make game add a life 
    /// TODO IDK if this should be handled internally lets talk about it more
    /// </summary>
    public void gainLife()
    {
        lifeHandler.addLife();
        lives++;
    }

    /// returns true if player is still alive
    public void removeLife()
    {
        lifeHandler.removeLife();
        lives--; 
    }

    /// <summary>
    /// run to check if the game is over
    /// </summary>
    /// <returns>true if game is over</returns>
    public bool isGameOver()
    {
        return lives <= 0;
    }

    /// <summary>
    /// Call this when the mini game is won
    /// </summary>
    public void winMiniGame()
    {
        loadNextScene();
    }


    /// <summary>
    /// if you lose a mini game and want to end it early call this.
    /// </summary>
    public void loseMiniGame()
    {
        //TBD
        removeLife();
        loadNextScene();
    }


    public float GetTimeleftInGame()
    {
        return levelTimer;
    } 

    // Call when your mini game has ended if player was killed, will automatically be called on scene load if player has zero lives
    public void EndGame()
    {
        GameOver = true;
        GameOverUi.SetActive(true);
    }

    [System.Serializable]
    public class UiGameManagerException : System.Exception
    {
        public UiGameManagerException() { }
        public UiGameManagerException(string message) : base(message) { }
        public UiGameManagerException(string message, System.Exception inner) : base(message, inner) { }
        protected UiGameManagerException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
