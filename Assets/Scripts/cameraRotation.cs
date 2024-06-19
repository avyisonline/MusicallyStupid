using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public Transform player;

    private float xMouse;
    private float yMouse;
    private float xRotation = 0f;
    public float speed = 250f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor in place so that it doesn't escape the confines of the window
    }

    // Update is called once per frame
    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime; // When you move the move you move the mouse (X)
        yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime; // When you move the move you move the mouse (Y)
        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -100f, 100f); // Makes you unable to move the mouse beyond a certain X value, so you don't go WEEEEE SPINNY WEEE, because that's not how a neck functions
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * xMouse);
         
    }
}
