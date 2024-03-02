using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    Vector2 moveDirection;
    public float dashSpeed;
    public float dashDuration;
    public float dashCd;
    bool isDash;
    bool canDash;

    void Start()
    {
        canDash = true;
    }

    void Update()
    {
        if (isDash)
        {
            return;
        }
        float mX = Input.GetAxisRaw("Horizontal");
        float mY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(mX, mY).normalized;
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (isDash)
        {
            return;
        }
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDash = true;
        rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration); 
        isDash = false;
        yield return new WaitForSeconds(dashCd);
        canDash = true;
    }
}