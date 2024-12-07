using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public Transform model;
    public float moveSpeed = 1f;
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Camera.main.gameObject.transform.Translate(Vector3.left * Time.deltaTime * horizontal * moveSpeed);
        }

        float vertical = Input.GetAxis("Vertical");
        if(vertical != 0)
        {
            Camera.main.gameObject.transform.Translate(Vector3.down * Time.deltaTime * vertical * moveSpeed);
        }

        float rotHoriz = Input.GetAxis("Rotate Horizontal");
        if (rotHoriz != 0)
        {
            model.Rotate(Vector3.left * Time.deltaTime * rotHoriz * rotationSpeed);
        }

        float rotVert = Input.GetAxis("Rotate Vertical");
        if (rotVert != 0)
        {
            model.Rotate(Vector3.down * Time.deltaTime * rotVert * rotationSpeed);
        }
    }
}
