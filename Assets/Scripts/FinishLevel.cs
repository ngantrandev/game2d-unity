using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{

    [SerializeField] private AudioSource finishSoundEffect;
    private bool isCompletedLevel = false;
    public int scoreRequired;
    [SerializeField] ItemCollector itemCollector;
    [SerializeField] PlayerLife playerLife;

    // Start is called before the first frame update
    private void Start()
    {
        scoreRequired = FindCherries();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinishLevel") && !isCompletedLevel)
        {
            Debug.Log(itemCollector.GetScore());
            if(itemCollector.GetScore() == scoreRequired)
            {
                finishSoundEffect.Play();
                playerLife.ShowDisappearAnimation();

                isCompletedLevel = true;
                Invoke("CompleteLevel", 1f);
            }
        }

    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private int FindCherries()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Cherry");

        return gameObjects.Length;
    }
}
