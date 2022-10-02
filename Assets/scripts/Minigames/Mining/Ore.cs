using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer image;

    public int maxHP = 10;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        if ((hp < maxHP * 0.33f) && image.sprite == sprites[1])
        {
            image.sprite = sprites[2];
        }
        else if ((hp < maxHP * 0.66f) && image.sprite == sprites[0])
        {
            image.sprite = sprites[1];
        }

        if(Input.GetMouseButtonDown(0))
        {
            hp--;
        }
    }

    public void Hit()
    {
        hp--;
    }
}
