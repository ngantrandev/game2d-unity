using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource deadthSoundEffect;
    private Animator animation;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            deadthSoundEffect.Play();
            ShowDeathAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinishLevel"))
        {
            ShowDisappearAnimation();
        }
    }

    private void ShowDisappearAnimation()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animation.SetTrigger("disappear");
    }

    private void ShowDeathAnimation()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animation.SetTrigger("death");
    }

    private void RestartLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
