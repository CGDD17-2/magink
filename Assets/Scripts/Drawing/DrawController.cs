using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class DrawController : MonoBehaviour
{

    public GameObject linePrefab;
    public int numberOfLines;
    public float initialMaginkPool;
    public float maginkPool;

    // GUI
    public GameObject maginkPoolSlider;
    public GameObject maginkLines;

    private float lengthMultiplier;
    GameObject currLineGO;
    Line currLine;
    Vector2 mousePos;
    List<GameObject> allLines;

    void Start()
    {

        allLines = new List<GameObject>();
        maginkPool = initialMaginkPool;
        lengthMultiplier = 100f;

        if (numberOfLines < 0)
            numberOfLines = 0;
        
        UpdateUI();
    }

    void Update()
    {
        // Drawing
        UpdateLeftButton();
        // Cleaning
        UpdateRightButton();
        // UI
        UpdateUI();
    }

    void UpdateLeftButton()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartDrawing();
        }
        else if (currLine != null && Input.GetButtonUp("Fire1"))
        {
            StopDrawing();
        }
        if (currLine != null)
        {
            ValidateNumberOfLines();

            float tmpLength = currLine.length;
            DrawLine();
            UpdateMaginkPool(tmpLength);
        }
    }

    void UpdateRightButton()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            DestroyLine();
        }
    }

    void UpdateUI()
    {
        
        // MaginkLines
        if (maginkLines != null)
        {

            bool drawingX = false;
            for (int i = 0; i < maginkLines.transform.childCount; i++)
            {
                if (i >= numberOfLines)
                {
                    maginkLines.transform.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    maginkLines.transform.GetChild(i).gameObject.SetActive(true);

                    if (allLines.Count > i)
                    {
                        maginkLines.transform.GetChild(i).gameObject.GetComponent<Image>().color = allLines[i].GetComponent<Line>().startColor;
                    }
                    else
                    {
                        if (!drawingX && currLine != null && currLine.pointList.Count > 1)
                        {
                            maginkLines.transform.GetChild(i).GetComponent<Image>().color = currLine.startColor;
                            drawingX = true;
                        }
                        else
                        {
                            maginkLines.transform.GetChild(i).GetComponent<Image>().color = new Color(1,1,1,0.2f);
                        }
                    }
                }
            }
        }

        if (maginkPoolSlider != null)
        {
            if (initialMaginkPool == 0)
                maginkPoolSlider.SetActive(false);
            else if (!maginkPoolSlider.activeSelf)
                maginkPoolSlider.SetActive(true);

            if (maginkPool < 0)
                maginkPoolSlider.GetComponentInChildren<Slider>().value = 0;
            else
                maginkPoolSlider.GetComponentInChildren<Slider>().value = Mathf.Round((maginkPool / initialMaginkPool) * 20) / 20;
        }
    }

    void ValidateNumberOfLines()
    {
        if (((allLines.Count >= numberOfLines)
                || maginkPool <= 0)
                    && allLines.Count != 0)
        {
            DestroyLine();
        }
    }

    void StartDrawing()
    {
        // Make new line
        currLineGO = Instantiate(linePrefab);
        currLineGO.transform.parent = transform;
        currLine = currLineGO.GetComponent<Line>();

    }

    void StopDrawing()
    {
        if (currLine.pointList.Count > 1)
            allLines.Add(currLineGO);
        currLine = null;
        currLineGO = null;
    }

    void DrawLine()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        if (currLine.pointList.Count > 0)
            hits = Physics2D.RaycastAll(mousePos, currLine.pointList.Last(), Vector2.Distance(mousePos, currLine.pointList.Last())).ToList<RaycastHit2D>();

        bool collider = false;

        foreach (RaycastHit2D hit in hits)
        {
            if (!hit.collider.isTrigger
                && hit.collider.tag != "Line"
                && hit.collider.tag != "Inklet"
                && hit.collider.tag != "Ground"
                && hit.collider.tag != "Arrow"
                && hit.collider.tag != "Projectile")
            {
                collider = true;
            }

        }

        if (!collider)
            currLine.UpdateLine(mousePos);
        else
            StopDrawing();
    }

    void UpdateMaginkPool(float tmpLength)
    {
        if (currLine)
        {
            float changer = (tmpLength - currLine.length);
            changer *= lengthMultiplier;
            maginkPool += changer;

            if (maginkPool <= 0 && allLines.Count <= 0)
                StopDrawing();
        }
    }

    public void DestroyLine()
    {
        if (allLines.Count != 0)
        {
            maginkPool += (allLines[0].GetComponent<Line>().length * lengthMultiplier);
            Destroy(allLines[0]);
            allLines.RemoveAt(0);
        }

        if (allLines.Count == 0 && currLine == null)
            maginkPool = initialMaginkPool;
    }

    public void DestroyLine(Line line)
    {
        int tmpIndex = 0;

        foreach (GameObject tmpLine in allLines)
        {
            Line tmptmpLine = tmpLine.GetComponent<Line>();
            if (tmptmpLine == line)
            {
                maginkPool += (tmptmpLine.length * lengthMultiplier);
                Destroy(tmpLine, 0.1f);
                allLines.RemoveAt(tmpIndex);

                if (allLines.Count == 0 && currLine == null)
                    maginkPool = initialMaginkPool;
                
            }
            tmpIndex++;
        }

    }
}
