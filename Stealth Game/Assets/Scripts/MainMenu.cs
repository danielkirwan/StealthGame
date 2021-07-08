using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Button clicked");
        SceneManager.LoadScene("LoadingBar", LoadSceneMode.Single);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
