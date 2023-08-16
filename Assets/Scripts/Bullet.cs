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

    private void Update()
    {
        Debug.Log("Bullet destroyed after 2 sec");
        Destroy(gameObject, 2f);
    }
}
