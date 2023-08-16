using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 1000000;
    public float currentHealth;
    public Animator animator;
    private BoxCollider boxCollider;

    public Slider healthBar;

    private bool isTakingDamage = false;
    public float damageInterval = 2.0f; // Time interval between health deductions
    private Coroutine healthCoroutine; // Store the reference to the coroutine
    private CollectingCoins collectingCoins;

    private bool canLoseCoins = true;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        if (healthBar == null)
        {
            Debug.LogError("HealthBar component is missing.");
        }
        collectingCoins = GetComponent<CollectingCoins>();
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spike") && canLoseCoins)
        {
            Debug.Log("Spike Touched");
            if (!isTakingDamage) // Start coroutine only if not already taking damage
            {
                isTakingDamage = true;
                healthCoroutine = StartCoroutine(LoseHealthOverTime());
            }
            canLoseCoins = false; // Prevent further coin loss temporarily
            collectingCoins.DecreaseCoinsOnDamage();
            StartCoroutine(ResetCoinLossDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Spike Left");
            if (isTakingDamage)
            {
                isTakingDamage = false;
                if (healthCoroutine != null)
                {
                    StopCoroutine(healthCoroutine);
                }
            }
        }
    }

    private IEnumerator ResetCoinLossDelay()
    {
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds
        canLoseCoins = true; // Allow coin loss again
    }

    private IEnumerator LoseHealthOverTime()
    {
        while (currentHealth > 0 && isTakingDamage)
        {
            currentHealth -= 2.5f; // Adjust this value as needed
            healthBar.value = currentHealth;
            yield return new WaitForSeconds(damageInterval);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            // Handle player death or reset the level

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene("GameOver");
        }
    }
}
