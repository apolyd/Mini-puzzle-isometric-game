using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu, endMenu;
    private bool isPaused, isOver;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOver == false)
        {
            if(isPaused == false)
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
            
        }

        if(isOver == true)
        {
            Time.timeScale = 0;
            isPaused = true;
            endMenu.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        isOver = false;
        SceneManager.LoadScene(1);
    }

    public bool GetPauseStatus()
    {
        return isPaused;
    }
    public void SetOverStatus(bool status)
    {
        isOver = status;
    }

}
