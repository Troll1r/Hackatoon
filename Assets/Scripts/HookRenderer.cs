using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    public void DrawHook(Vector3 start, Vector3 end)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        
    }
    public void Disable()
    {
        lineRenderer.enabled = false;
    }

}
