using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectingStar : MonoBehaviour
{
    public string gameOverSceneName = "GameOver"; // You can set this in the Inspector if needed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject, 1);
            StartCoroutine(LoadGameOverScene());
        }
    }


    IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(1.0f); 
        SceneManager.LoadScene("GameOver");
    }
}
