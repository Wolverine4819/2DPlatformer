using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private ServiceManager serviceManager;
    private int sceneIndex;

    private void Start()
    {
        serviceManager = GameObject.Find("ServiceManager").GetComponent<ServiceManager>();
    }

    private void OnDestroy()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        serviceManager.isEndGame(0);
    }
}