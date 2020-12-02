using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServiceManager : MonoBehaviour
{
    /*public static ServiceManager Instanse;*/
    public static ServiceManager Instanse = null;
    int sceneIndex;
    int levelComplete;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }

    public void isEndGame(int loadScene)
    {
        if(sceneIndex == 5)
        {
            LoadMainMenu();
        }
        if (levelComplete < sceneIndex)
        {
            PlayerPrefs.SetInt("LevelComplete", sceneIndex);
        }
        EndLevel(loadScene);
    }

    private void Awake()
    {
        if (Instanse == null)
        {
            Instanse = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel(int loadScene)
    {
        SceneManager.LoadScene(loadScene);
        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainManu");
    }
}
