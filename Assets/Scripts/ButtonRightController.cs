using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRightController : MonoBehaviour, IButtonController
{

    private PlayerMovement playerMovement;
    public void OnButtonDown()
    {
        playerMovement.MoveRight();
    }

    public void OnButtonUp()
    {
        playerMovement.Stop();
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
