using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int loadSceneIndex;
    

    public void LoadScene()
    {
        SceneManager.LoadScene(loadSceneIndex);
    }

    public void  QuitGame()
    {
        Application.Quit();
    }
}
