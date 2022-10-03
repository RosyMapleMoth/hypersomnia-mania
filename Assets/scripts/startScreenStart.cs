using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenStart : MonoBehaviour
{

    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGameNoraml()
    {
        StartCoroutine(startGameHelper(1, UiGameManager.GameMode.Normal));
    }

    public void startGameEasy()
    {
        StartCoroutine(startGameHelper(1, UiGameManager.GameMode.Relaxed));
    }

    public void startGameManic()
    {
        StartCoroutine(startGameHelper(1, UiGameManager.GameMode.Manic));
    }

    private IEnumerator startGameHelper(int transitionTime, UiGameManager.GameMode mode)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        UiGameManager.StartGameFromlevel(0, mode);
    }
}
