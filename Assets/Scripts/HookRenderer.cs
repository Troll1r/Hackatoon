using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    public Vector3 endLine;
    public void DrawHook(Vector3 start, Vector3 end)
    {
        endLine = end;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, endLine);
    }
    public void Disable()
    {
        lineRenderer.enabled = false;
    }

}
