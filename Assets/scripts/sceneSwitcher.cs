using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public Animator transition;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="levelToLoad"></param>
    public void LoadLevel(string levelToLoad, int transitionTime)
    {
        StartCoroutine(sceneloadHelper(levelToLoad, transitionTime));
    }

    private IEnumerator sceneloadHelper(string levelToLoad, int transitionTime)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelToLoad);
    }
}
