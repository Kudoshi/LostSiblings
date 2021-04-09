using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "Data_Levels", menuName = "ScriptableObject/Data_Levels")]
public class SO_Levels : ScriptableObject
{
    public int currentScene = 0;

    public void ChangeNextScene()
    {
        currentScene++;

        if (currentScene >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            return;
        }
        SceneManager.LoadScene(sceneBuildIndex: currentScene);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: currentScene);

    }
    public void ReturnToMainMenu()
    {
        currentScene = 0;
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void SetSceneToMainMenu()
    {
        currentScene = 0;
    }
}
