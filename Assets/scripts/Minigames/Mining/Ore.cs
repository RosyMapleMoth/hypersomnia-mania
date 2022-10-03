using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource explodeSound;
    public Sprite[] sprites;
    public Sprite[] gumdrops;

    private SpriteRenderer image;

    public int maxHP = 10;
    private int hp;

    public UiGameManager ui;

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
            explodeSound.Play();
            ui.failsOnTimeOut = false;
            SpawnGumdrops();
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
            Hit();
        }
    }

    public void Hit()
    {
        hitSound.Play();
        hp--;
    }

    private void SpawnGumdrops()
    {
        int numberOfGumdrops = Random.Range(5, 10);

        for(int i = 0; i < numberOfGumdrops; i++)
        {
            GameObject drop = new GameObject();
            drop.transform.position = transform.position;
            drop.transform.localScale = new Vector3(0.25f, 0.25f, 1);

            Rigidbody2D rb = drop.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0.1f;
            rb.drag = 0.5f;
            rb.freezeRotation = true;
            rb.AddForce(new Vector2(Random.Range(-400f, 400f), 200f));

            drop.AddComponent<SpriteRenderer>();
            drop.GetComponent<SpriteRenderer>().sprite = gumdrops[Random.Range(0, gumdrops.Length)];
            drop.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
    }
}
