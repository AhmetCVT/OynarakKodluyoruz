using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectBehaviour : MonoBehaviour
{

    public int pointValue = 10;


    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("collider: "+ other.name);
        Debug.LogWarning("Collided: "+ other.CompareTag("Player"));

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(pointValue);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }


}
