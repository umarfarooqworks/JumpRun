using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovementScript : MonoBehaviour
{
    IInput InputProvider;
    [SerializeField]
    float speed;

    private void Start()
    {
        InputProvider = GetComponent<IInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputProvider != null)
            MoveForward();
        else
            Debug.LogError("Provide Input Behaviour");
    }

    void MoveForward()
    {        
        if (InputProvider.IsTouchPressed())
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
