using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildSettings : MonoBehaviour
{
    public void GameScene() 
    {
        StartCoroutine(D_GameScene());
    }

    public void Back() 
    {
        StartCoroutine(D_Back());
    }

    public void BacktoMainMenu() 
    {
        StartCoroutine(D_BacktoMainMenu());
    }

    public void Options() 
    {
        StartCoroutine(D_Options());
    }

    IEnumerator D_GameScene() 
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    IEnumerator D_Back() 
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator D_BacktoMainMenu() 
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(0);
    }

    IEnumerator D_Options() 
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(1);
    }
}
