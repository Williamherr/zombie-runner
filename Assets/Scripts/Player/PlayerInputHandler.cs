using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    public Door door;


    private void Start()
    {
        door = FindObjectOfType<Door>();
    }
    // Update is called once per frame
    void Update()
    {
        DoorHandler();
    }

    public void DoorHandler()
    {
        if (Input.GetKeyDown(KeyCode.E) && door.IsPlayerAtDoor)
        {
            door.TriggerDoor();
            Debug.Log("Door Trigger");
        }
    }


}
