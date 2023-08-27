using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbScript : MonoBehaviour
{
    public LogicScript logic;
    public Rigidbody2D rigidBody;
    public float flapStrength;
    public bool birdIsAlive = true;
    public Animator wingAnimator;
    public Animator birbAnimator;
    public AudioSource pipeSFX;
    public AudioSource wingFlapSFX;
    public AudioSource wetFartSFX;
    private bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    rigidBody.velocity = Vector2.up * 10;
        //}

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) wingFlap();

        if ((transform.position.y > 10 || transform.position.y < -10) && !gameEnded)
        {
            wetFartSFX.Play();
            endGame();
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        pipeSFX.Play();
        endGame();
    }

    private void wingFlap()
    {
            rigidBody.velocity = Vector2.up * flapStrength;
            wingAnimator.SetTrigger("hola");
            wingFlapSFX.Play();
    }

    private void endGame()
    {
        gameEnded = true;
        birbAnimator.SetTrigger("it die");
        //pipeSFX.Play();
        logic.gameOver();
        birdIsAlive = false;
        GetComponent<Collider2D>().enabled = false;
    }
}