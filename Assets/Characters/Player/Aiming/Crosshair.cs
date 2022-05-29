using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Crosshair : MonoBehaviour
{
    private UILineRenderer lineRenderer;    
    public float thickness = 2.5f;
    public static Crosshair instance;

    public float nativeHeight = 1080;

    void Start()
    {
        lineRenderer = GetComponentInChildren<UILineRenderer>();
        instance = this;
    }

    public void drawCrosshairFromWorldPoint(Vector3 worldPoint)
    {
        Vector2 cameraPoint = Camera.main.WorldToScreenPoint(worldPoint);
        float midH = Screen.height / 2;
        float r = cameraPoint.y - midH;       

        DrawCircle(100, r * nativeHeight / Screen.height);
    }

    private void DrawCircle(int steps, float radius)
    {
        radius += thickness;
        for(int i = 0; i<steps; i++)
        {
            float cP = (float)i / steps;

            float cRadian = cP * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(cRadian) * radius;
            float yScaled = Mathf.Sin(cRadian) * radius;

            lineRenderer.Points[i] = new Vector3(xScaled, yScaled, 0);
        }
        lineRenderer.Points[steps] = new Vector3(radius, 0, 0);

        lineRenderer.SetAllDirty();
    }
}
