using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchcarCauldron : MonoBehaviour
{
    public UiGameManager ui;
    public AudioSource sound;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<WitchcarItem>(out WitchcarItem item))
        {
            Destroy(item.gameObject);
            score++;
            sound.Play();

            if(score >= 4)
            {
                ui.winMiniGame();
            }
        }
    }
}
