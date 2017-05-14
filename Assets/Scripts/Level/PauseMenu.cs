using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject pausePanel;
    private bool cursorGameStatus;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
                PauseGame();
            else
                ContinueGame();
        }
    }
    public void PauseGame()
    {
        cursorGameStatus = Cursor.visible;
        Cursor.visible = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        FindObjectOfType<DrawController>().enabled = false;
        //Disable scripts that still work while timescale is set to 0
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        FindObjectOfType<DrawController>().enabled = true;

        Cursor.visible = cursorGameStatus;
    }
}
