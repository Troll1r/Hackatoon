using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField] private HookRenderer hookRenderer;
    [SerializeField] private SpringJoint springJoint;
    [SerializeField] private LineRenderer lineRenderer;
    private Transform target = null;

    private void Update()
    {
        if(target != null)
        {
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointHook") && Input.GetKeyDown(KeyCode.Space))
        {
            CreateHook();
        }
        else
        {
            DisableHook();
            target = null;
        }  
        /*while (other.CompareTag("PointHook") && Input.GetKeyDown(KeyCode.Space))
        {
            target = other.transform;

            hookRenderer.DrawHook(transform.position, target.position);

        }*/
    }
  /* private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PointHook"))
        {
            DisableHook();
            target = null;
        }
    }*/

    public void CreateHook()
    {
        if (target != null)
        {
            Debug.Log("Да");

            Vector3 anchor = new Vector3(target.position.x, target.position.y, target.position.z);

            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.anchor = anchor;

            /*float grappleDistance = Vector3.Distance(transform.position, anchor);

            springJoint.maxDistance = grappleDistance;
            springJoint.minDistance = grappleDistance;*/

            springJoint.damper = 10;
            springJoint.spring = 5;

        }
    }

    public void DisableHook()
    {
        Destroy(springJoint);
        hookRenderer.Disable();
    }
}
