using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject FirePosition;
    public AudioSource Blaster;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    public void Shooting()
    {
        Instantiate(Bullet, FirePosition.transform.position, FirePosition.transform.rotation);
        Blaster.Play(); // Play the sound effect
        Debug.Log("BulletSpawned");
    }

}
