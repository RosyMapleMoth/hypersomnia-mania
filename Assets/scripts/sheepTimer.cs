using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sheepTimer : MonoBehaviour
{
    public Image SheepOne;
    public TextMeshProUGUI SheepOneCount;
    public Image SheepTwo;
    public TextMeshProUGUI SheepTwoCount;
    public Image SheepThree; 
    public TextMeshProUGUI SheepThreeCount;
    public TextMeshProUGUI TimerCounter;

    public bool start = false;

 

    // Update is called once per frame

    public void TimerActiveUpdate(float timer)
    {
        TimerCounter.text = timer.ToString("N2");
        float remainder = (timer / 2f) % 1;
        if (remainder > 0.66f)
        {
            SheepOne.gameObject.SetActive(true);
            SheepOneCount.text = Mathf.Ceil(timer).ToString("0.##");
            //SheepTwo.gameObject.SetActive(false);
            SheepThree.gameObject.SetActive(false);
        }
        else if (remainder > 0.33f)
        {
            SheepOne.gameObject.SetActive(false);
            SheepTwo.gameObject.SetActive(true);
            //SheepTwoCount.text = Mathf.Ceil(timer).ToString("0.##");
            SheepThree.gameObject.SetActive(false);
        }
        else
        {   
            SheepOne.gameObject.SetActive(false);
            SheepTwo.gameObject.SetActive(false);
            SheepThree.gameObject.SetActive(true);
            SheepThreeCount.text = Mathf.Ceil(timer).ToString("0.##");

        }
    }

    public void init(float time)
    {
        SheepOne.gameObject.SetActive(true);
        //SheepOneCount.text = Mathf.Ceil(time).ToString("0.##");
        SheepTwo.gameObject.SetActive(false);
        SheepThree.gameObject.SetActive(false);
    }
}
