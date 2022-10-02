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

    public void startGame()
    {
        StartCoroutine(startGameHelper(1));
    }

    private IEnumerator startGameHelper(int transitionTime)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        UiGameManager.StartGameFromlevel(0);
    }
}
