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
    Transform end;
    public Transform camera;
    Vector3 posEnd, posSmooth;
    public HealthBar timel;
    bool check;
    public Animator anim;


    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody>();


    }

    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            if (hit.transform.CompareTag("Ball") && check)
            {
                anim.Play("Jump");
                Debug.Log("Ìÿ÷");
                JumpBall();
                check = false;
            }
        }

    }

    void LateUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
            Die();

    }
    public void Die()
    {
        timel.timeLeft = 0;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zacep"))
        {
            other.transform.position = end.position;
        }
    }
    public void Jump()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 1.5f))
        {
            if (rh.transform != null)
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
                }

            }
        }
    }
    void JumpBall()
    {
        rb.AddForce(Vector3.up * 950);
        rb.AddForce(Vector3.right * 160);
    }
}
