using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        GameManager.instance.LoadLevel(sceneIndex);
    }
    public void LoadCurrentLevel()
    {
        GameManager.instance.LoadCurrentLevel();
    }
    public void LoadMainMenu()
    {
        GameManager.instance.LoadMainMenu();
		Cursor.visible = true;
    }
}
