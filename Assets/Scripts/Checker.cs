using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checker : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        Vector3[] positions = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(positions);

        //Find min and max x,y coordinates
        Vector2 minPos = positions[0];
        Vector2 maxPos = positions[0];

        foreach (Vector3 pos in positions)
        {
            if (pos.x < minPos.x)
            {
                minPos.x = pos.x;
            }
            else if (pos.x > maxPos.x)
            {
                maxPos.x = pos.x;
            }

            if (pos.y < minPos.y)
            {
                minPos.y = pos.y;
            }
            else if (pos.y > maxPos.y)
            {
                maxPos.y = pos.y;
            }

            //Check focus distance
            float distance = Mathf.Pow((pos.x * pos.x + pos.y * pos.y), 2) / (pos.x * pos.x - pos.y * pos.y);
            Debug.Log(distance);
        }

        if (maxPos.x - minPos.x > maxPos.y - minPos.y)
        {
            resultText.text = "Horizontal";
        }
        else
        {
            resultText.text = "Vertical";
        }
    }
}
