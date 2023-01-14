using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float coord_X;
    public float coord_Y;
    public Transform orient;

    float rotation_x;
    float rotation_y;


    // Before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * coord_X;
        float yInput = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * coord_Y;

        rotation_y += xInput;
        rotation_x -= yInput;
        rotation_x = Mathf.Clamp(rotation_x, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotation_x, rotation_y, 0);
        orient.rotation = Quaternion.Euler(0, rotation_y, 0);

    }
}
