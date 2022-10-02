using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdAndMole : MonoBehaviour
{
    public GameObject[] birds;
    public GameObject[] moles;
    public GameObject[] bombs;
    private float maxTime = 1f;
    private float curTime = 1f;

    int moleOrBomb, hole;
    bool got_it = false;

    public GameObject idle;

    enum birdPos {Left,Right,Center,up}

    private birdPos last = birdPos.up;
    private bool ChangeAvilable = true;

    public UiGameManager Ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
        AIupdate();
    }




    private void AIupdate()
    {   
        if (curTime > 0)
        {
            curTime -= Time.deltaTime;

            if ((int)last == hole)
            {
                if (moleOrBomb == 1)
                {
                    got_it = true;
                    moles[hole].SetActive(false);
                }
                else
                {
                    bombs[hole].SetActive(false);
                    curTime = -1;
                    Ui.loseMiniGame();
                    return;
                }
            }

            if (curTime <= 0)
            {
                if (moleOrBomb == 1)
                {
                    if (!got_it)
                    {
                       Ui.loseMiniGame(); 
                    }
                    moles[hole].SetActive(false);
                }
                else
                {
                    bombs[hole].SetActive(false);
                }

                moleOrBomb = Random.Range(0,2);
                hole = Random.Range(0,3);  
                got_it = false;
                curTime = maxTime;

                if (moleOrBomb == 1)
                {
                    moles[hole].SetActive(true);
                }
                else
                {
                    bombs[hole].SetActive(true);
                }
            }
        }
    }


    private void InputUpdate()
    {
        if (Input.GetKeyDown("down"))
        {
            birds[0].SetActive(false);
            birds[1].SetActive(false);
            birds[2].SetActive(true);
            idle.SetActive(false);
            last = birdPos.Center;
        }
        if (Input.GetKeyDown("left"))
        {
            birds[0].SetActive(true);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            idle.SetActive(false);
            last = birdPos.Left;
        }
        if (Input.GetKeyDown("right"))
        {
            birds[0].SetActive(false);
            birds[1].SetActive(true);
            birds[2].SetActive(false);
            idle.SetActive(false);
            last = birdPos.Right;
        }

        if (Input.GetKeyUp("down") && last == birdPos.Center)
        {
            birds[0].SetActive(false);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            last = birdPos.up;
            idle.SetActive(true);

        }
        if (Input.GetKeyUp("left") && last == birdPos.Left)
        {
            birds[0].SetActive(false);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            idle.SetActive(true);
            last = birdPos.up;
        }   
        if (Input.GetKeyUp("right") && last == birdPos.Right)
        {
            birds[0].SetActive(false);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            idle.SetActive(true);
            last = birdPos.up;
        }
    }
}
