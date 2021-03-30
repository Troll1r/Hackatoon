using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [SerializeField] private HookRenderer hookRenderer;
    private HingeJoint springJoint;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Moving moving;
    private Transform target = null;
    bool isDrawing = false;
    Vector3 anchor;
    public bool isHook = true;
    bool isMoving;
    bool isHinge = true;
    Rigidbody rb;
    private void Update()
    {
        //isHook = moving.GetComponent<Moving>().isHookAble;
        if (isDrawing)
        {
            hookRenderer.DrawHook(transform.position, anchor);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Anchor"))
        {
            if (isHook)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb = other.GetComponent<Rigidbody>();
                    target = other.transform;
                    CreateHook();
                }
            }
        }
        else
        {
            DisableHook();
            target = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PointHook"))
        {
            DisableHook();
            target = null;
        }
    }

    public void CreateHook()
    {
        
        if(target != null)
        {
            if (target.transform.CompareTag("Anchor"))
            {
                if (isHinge)
                {
                    
                    isHinge = false;

                    springJoint = gameObject.AddComponent<HingeJoint>();

                    anchor = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
                    
                    /*springJoint.autoConfigureConnectedAnchor = false;
                    springJoint.connectedAnchor = Vector3.zero;*/

                    springJoint.anchor = anchor;

                    springJoint.axis = new Vector3(0, 0, 1);

                    springJoint.useLimits = true;
                    JointLimits limits = springJoint.limits;
                    limits.max = 45;
                    limits.min = -45;
                    limits.bounciness = 1;
                    springJoint.limits = limits;

                    isDrawing = true;
                }
            }
        }
    }

    public void DisableHook()
    {
        Destroy(springJoint);
        hookRenderer.Disable();
        isDrawing = false;
        isHinge = true;
    }
}
