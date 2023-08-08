using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb.AddForce(transform.forward * -2000);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); // Destroy the bullet
    }
}
