using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cubeCnt : MonoBehaviour
{
    PlControl playerInput;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlControl();

        playerInput.Gameplay.Grow.performed += ctx => Grow();


    }

    void Grow()
    {
        transform.localScale *= 1.1f;
    }

    void OnEnable()
    {
        playerInput.Gameplay.Enable();
    }

    void OnDisable()
    {
        playerInput.Gameplay.Disable();
    }


    
}
