using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
