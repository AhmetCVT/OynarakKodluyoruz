using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreBehaviour : MonoBehaviour, ICollectible
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("collider: " + other.name);

        if (other.CompareTag("Player"))
        {
            OnCollected();
            StartCoroutine(DelayDestryoObject());
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }

    public virtual void OnCollected()
    {
        Debug.Log("Congratulations, you have collected an ore!");
    }

    IEnumerator DelayDestryoObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
