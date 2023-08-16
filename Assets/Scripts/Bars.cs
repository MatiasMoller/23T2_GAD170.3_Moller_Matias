using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{
   public void DestroyBars()
    {
        Debug.Log("Bars gone");
        Destroy(gameObject, 2f);
    }
}
