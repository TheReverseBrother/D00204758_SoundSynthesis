using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public CsoundUnity csoundUnity = null;
    public bool startWalk = false;
    private float currentDampening;
    private float currentRSize;
    private float currentSendAmount;
    
    private void Awake()
    {
        csoundUnity = GetComponent<CsoundUnity>();
        instance = this;
    }



    void Start()
    {
        currentRSize = 0.85f;
        currentDampening = 0.5f;
        currentSendAmount = 0.8f;
        csoundUnity.setChannel("RVBSendAmount", currentSendAmount);
        csoundUnity.setChannel("RVBDampening", currentDampening);
        csoundUnity.setChannel("RVBRoomSize", currentRSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        string zone = other.tag;
        if(zone == "Room")
        {
            print("InRoom");
            RoomCollider roomCollider = other.gameObject.GetComponent<RoomCollider>();
            float size = roomCollider.roomSize;
            float dampening = roomCollider.dampeningAmount;

            if(size != currentRSize || dampening != currentDampening)
            {
                print("Changing Rooms");
                setReverbDampening(dampening);
                setReverbRoomSize(size);
                //resetWalk();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        string collisionType = collision.gameObject.tag;
        if(collisionType == "floorCollider")
        {
            print("SEND");
            FloorElement floorElement = collision.gameObject.GetComponent<FloorElement>();
            float sendamount = floorElement.sendAmount;
            if(currentSendAmount != sendamount)
            {
                setReverbSendAmount(sendamount);
                //resetWalk();
            }
        }
    }
    public void updateSendAmount(float amount)
    {
        if (currentSendAmount != amount)
        {
            print("ChangingFloor");
            setReverbSendAmount(amount);
            //resetWalk();
        }
    }
    //set the send amount
    private void setReverbSendAmount(float sendAmount)
    {
        currentSendAmount = sendAmount;
        csoundUnity.setChannel("RVBSendAmount", sendAmount);
    }

    //set the dampening variable
    private void setReverbDampening(float dampening)
    {
        if(dampening != currentDampening)
        {
            currentDampening = dampening;
            csoundUnity.setChannel("RVBDampening", dampening);
        }
    }

    //Set room size reverb for CSound must be between 0-1
    private void setReverbRoomSize(float size)
    {
        if(size != currentRSize)
        {
            currentRSize = size;
            csoundUnity.setChannel("RVBRoomSize", size);
        }
    }

    private void resetWalk()
    {
        csoundUnity.setChannel("EndWalk", Random.Range(0, 100));
        csoundUnity.setChannel("StartWalk", Random.Range(0, 100));
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && startWalk == false)
        {
            startWalk = true;
            csoundUnity.setChannel("StartWalk", Random.Range(0,100));
        }
        else if(Input.GetKeyUp(KeyCode.W) && startWalk == true)
        {
            startWalk = false;
            csoundUnity.setChannel("EndWalk", Random.Range(0, 100));
        }
    }
    
}