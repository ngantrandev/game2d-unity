using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{

    private AudioSource finishSoundEffect;
    private bool isCompletedLevel = false;

    // Start is called before the first frame update
    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isCompletedLevel)
        {
            finishSoundEffect.Play();
            isCompletedLevel = true;
            Invoke("CompleteLevel", 1f);
        }

    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
