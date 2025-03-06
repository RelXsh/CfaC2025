using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject taskPanel;
    public GameObject pauseMenu;
    public bool taskActive = false;
    public bool isPaused = false;
    public static event Action onTaskClosed;

    // Update is called once per frame

    private void Start()
    {
        bedNightSkipper.onSleep += OpenTask;
    }
    public void OpenTask()
    {
        pauseMenu.SetActive(false);
        isPaused = false ;
        taskActive = true ;
        taskPanel.SetActive(true);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void CloseTask()
    {
        taskActive = false ;
        taskPanel.SetActive(false); 
        taskActive=false ;
        onTaskClosed?.Invoke();

    }


    void Update()
    {
        //Task open/close
        if (Input.GetKeyDown(KeyCode.T) && !isPaused)
        {
            taskActive = !taskActive;
            if (taskActive)
            {
                taskPanel.gameObject.SetActive(true);

            }
            else
            {
                taskPanel.gameObject.SetActive(false);
            }
        }


        //Pause/unpause
        if (Input.GetKeyDown(KeyCode.P) && !taskActive)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            Cursor.visible = isPaused ? true : false;
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            pauseMenu.SetActive(isPaused);
        }
    }
}
