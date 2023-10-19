using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldOreBehaviour : OreBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollected()
    {
        base.OnCollected();
        GameManager.Instance.AddScore(200);
    }
}