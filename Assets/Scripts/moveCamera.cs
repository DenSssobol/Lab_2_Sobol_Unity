using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform cameraPos;
    // Before the first frame update
    void Start()
    {
        
    }

    // Update frame
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
