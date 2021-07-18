using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookControl : MonoBehaviour
{
    public float mouseSensitivity= 1000f;

    [SerializeField] Transform _playerBody;

    float xRotation = 0f;
    public bool pause;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            _playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
