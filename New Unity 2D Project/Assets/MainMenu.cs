using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*public Button level1B;*/
    public Button level2B;
    public Button level3B;
    public Button level4B;
    int levelComplete;

    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
        level2B.interactable = false;
        level3B.interactable = false;
        level4B.interactable = false;

        switch (levelComplete)
        {
            case 1:
                level2B.interactable = true;
                break;
            case 2:
                level2B.interactable = true;
                level3B.interactable = true;
                break;
            case 3:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                break;
            case 4:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                break;
        }
    }

    public void LoadTo (int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        level2B.interactable = false;
        level3B.interactable = false;
        level4B.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
