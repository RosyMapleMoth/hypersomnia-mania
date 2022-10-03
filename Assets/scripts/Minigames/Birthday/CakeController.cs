using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    public FallingCake cakePrefab;
    public float timeBetweenCakes = 1f;
    private float timeOfNextCake;

    // Start is called before the first frame update
    void Start()
    {
        timeOfNextCake = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOfNextCake < Time.time)
        {
            timeOfNextCake = Time.time + timeBetweenCakes;
            FallingCake cake = Instantiate(cakePrefab);
            cake.name = "Cake";
            cake.transform.position = new Vector3(Random.Range(-8, 8), 6f, 0f);
        }
    }
}
