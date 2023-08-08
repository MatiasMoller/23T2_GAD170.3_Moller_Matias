using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject FirePosition;


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
        Debug.Log("BulletSpawned");
    }
}
