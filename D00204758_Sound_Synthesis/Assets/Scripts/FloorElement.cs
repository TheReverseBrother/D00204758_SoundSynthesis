using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorElement : MonoBehaviour
{
    public float sendAmount = 0;

    //When Player Enters trigger update the send amount
    private void OnTriggerEnter(Collider other)
    {
        string collisionType = other.gameObject.tag;
        if (collisionType == "Player")
        {
            SoundManager.instance.updateSendAmount(sendAmount);
        }
    }
}
