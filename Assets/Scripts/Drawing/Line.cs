using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    [HideInInspector] public float length;
    [HideInInspector] public List<Vector2> pointList;
    [HideInInspector] public Color startColor;
    [HideInInspector] public Color endColor;


    void Awake()
    {
        pointList = new List<Vector2>();
        length = 0f;
        SetRandomColor();
    }

	public void UpdateLine (Vector2 mousePos)
    {
        // Create pointList
        if (pointList == null)
        {

        }
        // Check if mousepos is not on the same position as the last one
        if (!pointList.Contains(mousePos))
        {
            if(pointList.Count > 1)
            {
                length += Vector2.Distance(pointList.Last(), mousePos);
            }

            SetPoints(mousePos);
        }
    }

    void SetPoints(Vector2 point)
    {
        // Updating list
        pointList.Add(point);

        // Updating lineRenderer
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPosition(pointList.Count - 1, point);

        // Collider has to have at least 2 points
        if (pointList.Count > 1)
            edgeCollider.points = pointList.ToArray();
    }

    private void SetRandomColor()
    {
        startColor = new Color(Random.value, Random.value, Random.value);
        endColor = new Color(Random.value, Random.value, Random.value);

        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }
}
