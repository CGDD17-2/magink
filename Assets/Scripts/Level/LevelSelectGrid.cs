using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectGrid : MonoBehaviour {

    public int col, row;

	// Use this for initialization
	void Update () {
        GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup>();
        RectTransform parent = gameObject.GetComponent<RectTransform>();
        grid.cellSize = new Vector2(parent.rect.width / col, parent.rect.height / row);
	}
}
