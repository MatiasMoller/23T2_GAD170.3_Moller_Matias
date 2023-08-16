using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject fireBall;
    public Transform spawnPoint;
    public Transform boss; // Reference to the boss's mask transform
    private GameObject player;
    public float maxHealth = 100000.0f;
    public Slider bossHealthBar;
    private float currentHealth;
    public Bars bars;
    public float activationRange = 49.0f;
    private bool healthBarVisible = false;



    public float fireRate = 1.0f; // Adjust this value to control the fire rate in shots per second
    private float shootingTimer = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootingTimer = 1.0f / fireRate; // Initialize the timer based on the fire rate
        currentHealth = maxHealth;
        bossHealthBar.maxValue = maxHealth;
        bossHealthBar.value = currentHealth;

        bossHealthBar.gameObject.SetActive(false);

    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 49)
        {
            
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0; // Ignore vertical difference for 2D rotation
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            boss.rotation = Quaternion.Slerp(boss.rotation, targetRotation, Time.deltaTime * 5); // Adjust rotation speed

            // Decrement the timer
            shootingTimer -= Time.deltaTime;

            // Check if it's time to shoot
            if (shootingTimer <= 0)
            {
                // Reset the timer based on the fire rate
                shootingTimer = 1.0f / fireRate;

                // Shooting logic
                shoot();
            }

            if (distance < activationRange && !healthBarVisible)
            {
                // Show the boss health bar
                bossHealthBar.gameObject.SetActive(true);
                healthBarVisible = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            float randomDamage = Random.Range(2.0f, 6.0f); // Generate a random damage value between 3 and 8
            Debug.Log(randomDamage + "damage");
            TakeDamage(randomDamage); // Apply the random damage amount
            Destroy(collision.gameObject); // Destroy the bullet upon collision
        }
    }


    private void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0.0f, maxHealth);

        bossHealthBar.value = currentHealth; // Update the boss's health bar value

        if (currentHealth <= 0)
        {
            Die();
        }
    }



    private void shoot()
    {
        Instantiate(fireBall, spawnPoint.position, Quaternion.identity);
    }

    private void Die()
    {
        Destroy(gameObject);
        bars.DestroyBars();
        Destroy(bossHealthBar.gameObject);
    }
   
}
