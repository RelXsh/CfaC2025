using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject taskPanel;
    public GameObject pauseMenu;
    public bool taskActive = false;
    public bool isPaused = false;

    // Update is called once per frame
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
