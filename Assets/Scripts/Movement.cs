using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Movement: MonoBehaviour
{
    Rigidbody model;
    bool status_jump;
    KeyCode space = KeyCode.Space;
    bool status_TheGround;
    float left_right;
    float up_down;
    Vector3 move_direction;

    public float move_speed;
    public float ground;
    public float high_jump;
    public float decrease_jump;
    public float stabil_in_air;
    public float height;
    public LayerMask terrain;
    public Transform orient;


    private void Start()
    {
        model = GetComponent<Rigidbody>();
        model.freezeRotation = true;
        status_jump = true;
    }

    private void Update()
    {
        status_TheGround = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.3f, terrain);

        left_right = Input.GetAxisRaw("Horizontal");
        up_down = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(space) && status_jump && status_TheGround)
        {
            status_jump = false;
            Jump();
            Invoke(nameof(ResetJump), decrease_jump);
        }

        limitV();

        if (status_TheGround)
            model.drag = ground;
        else
            model.drag = 0;
    }

    private void FixedUpdate()
    {
        move_direction = orient.forward * up_down + orient.right * left_right;

        if (status_TheGround)
            model.AddForce(move_direction.normalized * move_speed * 10f, ForceMode.Force);

        else if (!status_TheGround)
            model.AddForce(move_direction.normalized * move_speed * 10f * stabil_in_air, ForceMode.Force);
    }

    private void limitV()
    {
        Vector3 horizontalV = new Vector3(model.velocity.x, 0f, model.velocity.z);

        if (horizontalV.magnitude > move_speed)
        {
            Vector3 limitedVel = horizontalV.normalized * move_speed;
            model.velocity = new Vector3(limitedVel.x, model.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        model.velocity = new Vector3(model.velocity.x, 0f, model.velocity.z);

        model.AddForce(transform.up * high_jump, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        status_jump = true;
    }
}