using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public string nextLevel;
    public float delay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("NextScene", delay);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
