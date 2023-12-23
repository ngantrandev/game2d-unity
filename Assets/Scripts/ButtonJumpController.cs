using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJumpController : MonoBehaviour, IButtonController
{
    private PlayerMovement playerMovement;
    public void OnButtonDown()
    {
        playerMovement.Jump();
    }

    public void OnButtonUp()
    {
        playerMovement.NotJump();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
