using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnSceneChange()
    {
        SceneManager.LoadScene(this.name);
    }
}
