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
    bool bool1 = true;
    int i = 0;
    [SerializeField] private GrappleHook grappleHook;
    private AudioSource audioS;
    public AudioSource audioSource;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        isJump = true;
        anim2 = gameObject.GetComponent<Animator>();
        isAlive = true;
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator FrogJump()
    {
        if (bool1)
        {
            bool1 = false;

            yield return new WaitForSeconds(0.65f);
            rb.AddForce(Vector3.up * jumpForce);
            rb.AddForce(Vector3.right * forwardForce);
            bool1 = true;
        }
        else
            yield return new WaitForSeconds(0);

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
            {
                Jump();
            }
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
        if (other.gameObject.tag == "Floor")
            IsGrounded = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
            IsGrounded = false;
        
    }
    public void Jump() 
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 0.5f))
        {
            if (IsGrounded)
            {
                anim2.Play("Frog");
                audioS.Play();
                StartCoroutine(FrogJump());
            }
            if (rh.transform != null)
            {
                if (rh.transform.CompareTag("Floor"))
                {
                    
                    IsGrounded = true;
                    isDouble = false;
                    bool1 = true;
                    
                    check = true;
                }
            }
        }
        
        else { IsGrounded = false; }
    }
    void JumpBall()
    {
        audioSource.Play();
        rb.AddForce(Vector3.up * 400);
        rb.AddForce(Vector3.right * 160);
    }
    public void Die()
    {
        timel.timeLeft = 0;

    }
}
