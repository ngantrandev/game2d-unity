using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource deadthSoundEffect;
    [SerializeField] private AudioSource checkpointSound;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Transform transform;
    [SerializeField] private Text heartText;
    [SerializeField] private int maxHeart = 3; // so lan chet toi da
    private int deathCount = 0; // so lan chet

    private bool batTu = false;

    Vector2 lastPos, startPos;


    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();

        if (heartText != null)
        {
            heartText.text = "Heart: " + maxHeart;
        }

        startPos = transform.position;
        lastPos = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !batTu)
        {
            deadthSoundEffect.Play();
            ShowDeathAnimation();

            Debug.Log("collide");
            deathCount++;
            batTu = true; // loai bo va cham voi vat khac truoc khi game restart hoac respawn

            if (heartText != null && deathCount <= maxHeart)
            {
                heartText.text = "Heart: " + (maxHeart - deathCount);
            }


            if (deathCount >= maxHeart)
            {
                Debug.Log("Restart");
                StartCoroutine(RestartLevelAfterDelay(1f));
            }
            else
            {
                Debug.Log("respawn");
                StartCoroutine(RespawnAfterDelay(1f)); // delay khong chan luong chinh cua game

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On trigger");
        //if (collision.gameObject.CompareTag("FinishLevel"))
        //{
        //    ShowDisappearAnimation();
        //}
        //else
        
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpointSound.Play();
            collision.gameObject.SetActive(false);
            lastPos = collision.transform.position;
        }
    }

    public void ShowDisappearAnimation()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("disappear");
    }

    private void ShowDeathAnimation()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }

    private IEnumerator RespawnAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);

        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = lastPos;
        animator.SetTrigger("respawn");
        batTu = false;

    }

    private IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.position = startPos;
        animator.SetTrigger("respawn");
        batTu = false;
    }
}
