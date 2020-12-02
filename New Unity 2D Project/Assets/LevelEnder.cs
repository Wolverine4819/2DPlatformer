using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    private int sceneIndex;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        ServiceManager.Instanse.isEndGame(sceneIndex + 1);
    }
}
