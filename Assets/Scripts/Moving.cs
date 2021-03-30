using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public float jumpForce;
    public float forwardForce;
    public bool IsGrounded;
    private Rigidbody rb;
    bool isAlive;
    bool isDouble;
    bool isAvailable;
    Transform end;
    private bool check = true;
    public Animator anim;
    [SerializeField] private GrappleHook grappleHook;
    // public Hook hook;
    //Transform player;

    void Start()
    {
     //   player.position = transform.position;
        isAlive = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                grappleHook.CreateHook();
            else if (Input.GetKeyUp(KeyCode.Space))
                grappleHook.DisableHook();
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            isAlive = false;
        }
        
    }
    public void Jump() 
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 2f))
        {
            if(rh.transform != null)
            {
                if (rh.transform.CompareTag("Floor"))
                {
                    IsGrounded = true;
                    isDouble = false;
                    if (IsGrounded)
                    {
                        rb.AddForce(Vector3.up * jumpForce);
                        rb.AddForce(Vector3.right * forwardForce);
                        isDouble = true;
                    }
                    check = true;
                }
                    
            }
        }
        
        else { IsGrounded = false; }
       
        if (Input.GetKeyDown(KeyCode.Space) && isDouble == true)
        {
            isDouble = false;
            isAvailable = false;
            //  Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
            //VEctro
            // hook.HookCreate(playerPos, end.position);
        }
    }
    void JumpBall()
    {
        rb.AddForce(Vector3.up * 950);
        rb.AddForce(Vector3.right * 160);
    }
}
