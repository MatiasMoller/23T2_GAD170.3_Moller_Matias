using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void DestroyDoor()
    {
        Debug.Log("Door triggered for destruction");
        Destroy(gameObject, 3f); // Destroy the door object after 3 seconds
    }
}