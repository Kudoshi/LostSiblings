using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PauseMenuManager : MonoBehaviour
{
    [Header("Pause UI")]
    public GameObject pauseMenu;
    public static bool isPaused = false;
    [Header("Victory UI")]
    public GameObject victoryMenu;
    public SO_PlayerResource playerResource;
    public GameObject goldText;

    private int coinCount;
    // Start is called before the first frame update
    private void Awake()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        victoryMenu.SetActive(false);
    }
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else if (isPaused)
                ResumeGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        goldText.GetComponent<TextMeshProUGUI>().text = playerResource.Gold.ToString() + 
                                                        " / " + playerResource.totalGoldInLevel.ToString();
        victoryMenu.SetActive(true);
    }

    public void PlayButtonHover()
    {
        AudioManager.PlayOneShotSound(gameObject, "MouseHover");
    }
    public void PlayButtonClick()
    {
        AudioManager.PlayOneShotSound(gameObject, "MouseClick");
    }
}
