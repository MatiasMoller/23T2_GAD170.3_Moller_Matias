using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Animator animator;
    //private bool isDead;
    private BoxCollider boxCollider;
    public FillStatusBar fillStatusBar;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        //isDead = false; 
        boxCollider = GetComponent<BoxCollider>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Spike Touched");
            LoseHealth();
        }
    }
    private void LoseHealth()
    {
        SceneManager.LoadScene("Game");
        
    }
  
    
}
