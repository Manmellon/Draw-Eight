using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Drawer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _linesParent;
    [SerializeField] private LineRenderer _lineRendererPrefab;
    [SerializeField] private TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(_lineRendererPrefab, _linesParent);
            }

            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

            var lineRenderers = _linesParent.GetComponentsInChildren<LineRenderer>();
            lineRenderers[lineRenderers.Length - 1].positionCount += 1;
            lineRenderers[lineRenderers.Length - 1].SetPosition(lineRenderers[lineRenderers.Length - 1].positionCount - 1, mousePos);
        }
    }

    public void Clear()
    {
        foreach (var lineRenderer in _linesParent.GetComponentsInChildren<LineRenderer>())
        {
            Destroy(lineRenderer.gameObject);
            //_lineRenderer.positionCount = 0;
        }
        
        resultText.text = "";
    }
}
