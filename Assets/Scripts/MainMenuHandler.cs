using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public string SceneToLoad;
    public void CloseGame()
    {
        Application.Quit();
    }

    public void SwitchScenes()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }
}
