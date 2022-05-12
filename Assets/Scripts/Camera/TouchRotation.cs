using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotation : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position,
                                            Vector3.up,
                                            Input.GetAxis("Mouse X") * speed);

            //transform.RotateAround(transform.position,
            //                                Vector3.right,
            //                                -Input.GetAxis("Mouse Y") * speed);
        }

    }
}
