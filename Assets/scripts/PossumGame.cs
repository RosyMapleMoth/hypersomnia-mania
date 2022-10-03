using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossumGame : MonoBehaviour
{


    private float power;
    private Vector2 dir;

    public Animator Angel, Power;

    private enum PossomState {getAngle, getPower, Shoot, wait}

    private PossomState mystate = PossomState.getAngle;
    public GameObject PossomBall,Arrow;

    public Transform angleTarget, angelOrign;  
    public bool Goingup = true;

    public UiGameManager UI;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mystate == PossomState.getAngle)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                mystate = PossomState.getPower;
                Angel.SetTrigger("select");
            }
        }
        else if (mystate == PossomState.getPower)
        {
            if (Goingup)
            {
                power += Time.deltaTime;
                if (power >= 1f)
                {
                    Goingup = false;
                    power = 1f;
                }
            }
            else
            {
                power -= Time.deltaTime;
                if (power <= 0)
                {
                    Goingup = true;
                    power = 0f;
                } 
            }
            Power.SetFloat("power",power);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                mystate = PossomState.Shoot;
            }

        }
        else if (mystate == PossomState.Shoot)
        {
            PossomBall.GetComponent<Rigidbody2D>().simulated = true;
            PossomBall.GetComponent<Rigidbody2D>().AddForce((angleTarget.position - angelOrign.position) * ( power * 450), ForceMode2D.Force);
            mystate = PossomState.wait;
        }
        else
        {

        }

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision");

        if (col.CompareTag("goal"))
        {
            UI.winMiniGame();
        }
    }
}
