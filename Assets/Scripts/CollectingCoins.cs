using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectingCoins : MonoBehaviour
{
    public List<int> collectedCoins = new List<int>();
    public AudioClip coinCollectSound;
    private AudioSource audioSource;
    public TextMeshProUGUI coinCountText;

    private Health playerHealth; // Reference to the Health script

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerHealth = GetComponent<Health>(); // Get reference to Health script
        UpdateCoinCountUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            for (int i = 0; i < 1; i++)
            {
                collectedCoins.Add(1); 
            }
            PlayCoinCollectSound();
            UpdateCoinCountUI();
            Destroy(other.gameObject);
        }
    }

    private void PlayCoinCollectSound()
    {
        if (coinCollectSound && audioSource)
        {
            audioSource.PlayOneShot(coinCollectSound);
        }
    }

    private void UpdateCoinCountUI()
    {
        if (coinCountText)
        {
            int totalCoins = collectedCoins.Count; // Count of coins collected
            coinCountText.text = totalCoins.ToString();
        }
    }

    public void DecreaseCoinsOnDamage()
    {
        if (collectedCoins.Count > 0)
        {
            collectedCoins.RemoveAt(collectedCoins.Count - 1); // Remove one coin
            UpdateCoinCountUI();
        }
    }



}
