using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int level = 3;
	public Texture2D handCursor;
    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
		//Cursor.SetCursor (handCursor, Vector2.zero, CursorMode.ForceSoftware);
        LoadCurrentLevel();
    }

    public void LoadMainMenu()
    {
        level = 0;
        LoadCurrentLevel();
        
    }

    public void LoadNextLevel()
    {
        level += 1;
        LoadCurrentLevel();
    }

    public void LoadCurrentLevel()
    {
        //Debug.Log("FADING0");
		var fader = new FadeTransition()
		{
			nextScene = level,
			fadedDelay = 0.2f,
			duration = 0.2f,
			fadeToColor = Color.black
		};
		TransitionKit.instance.transitionWithDelegate(fader);
    }

    public void LoadLevel(int index)
    {

        level = index;
        LoadCurrentLevel();
    }
}