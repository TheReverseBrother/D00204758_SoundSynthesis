using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorElement : MonoBehaviour
{
    public float sendAmount = 0;

    public float getSendAmount()
    {
        return this.sendAmount;
    }
    private void OnTriggerEnter(Collider other)
    {
        string collisionType = other.gameObject.tag;
        if (collisionType == "Player")
        {
            SoundManager.instance.updateSendAmount(sendAmount);
        }
    }

    private void Update()
    {
        
    }
}
