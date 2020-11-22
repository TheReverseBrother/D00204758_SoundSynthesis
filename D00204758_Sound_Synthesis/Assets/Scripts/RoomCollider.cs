using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    public float roomSize = 0;
    public float dampeningAmount = 0;

    public float getRoomsize()
    {
        return this.roomSize;
    }

    public float getDampeningAmount()
    {
        return this.dampeningAmount;
    }
}
