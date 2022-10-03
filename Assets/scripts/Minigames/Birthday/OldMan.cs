using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour
{
    public float moveSpeed = 7;

    public UiGameManager ui;

    public AudioSource splatSound;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput < 0f && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontalInput > 0f && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Cake")
        {
            splatSound.Play();
            ui.loseMiniGame();
        }
    }
}
