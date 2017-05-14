using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneTrans : MonoBehaviour {
	public Texture2D fade;
	public float fadeSpeed = 0.8f;
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;

	void OnGui(){
        
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fade);
	}
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public float BeginFade(int dir){
		fadeDir = dir;
		return(fadeSpeed);
	}

	void OnSceneLoaded(Scene scene,LoadSceneMode mode){
		BeginFade (1);
	}
}
