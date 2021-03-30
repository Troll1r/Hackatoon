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
    public Animator anim2;
    public HealthBar timel;
    bool isJump;
    [SerializeField] private GrappleHook grappleHook;
    // public Hook hook;
    //Transform player;

    void Start()
    {
        isJump = true;
        anim2 = gameObject.GetComponent<Animator>();
     //   player.position = transform.position;
        isAlive = true;
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(0.65f);
        {
            rb.AddForce(Vector3.up * jumpForce);
            rb.AddForce(Vector3.right * forwardForce);
            isDouble = true;
            isJump = true;
        }
    }

    void Update()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            if (hit.transform.CompareTag("Ball") && check)
            {
                anim.Play("Jump");
                JumpBall();
                check = false;
            }
        }
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
        if (other.gameObject.tag == "DeadZone")
            Die();

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
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    anim2.Play("Frog"); 
                    IsGrounded = true;
                    isDouble = false;
                    if (IsGrounded && isJump)
                    {
                        isJump = false;
                        anim2.Play("Frog");
                        StartCoroutine(FrogJump());
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
        rb.AddForce(Vector3.up * 800);
        rb.AddForce(Vector3.right * 160);
    }
    public void Die()
    {
        timel.timeLeft = 0;

    }
}
