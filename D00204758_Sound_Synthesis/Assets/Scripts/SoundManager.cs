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
        //Create A singleton
        instance = this;
    }



    void Start()
    {
        //Set the Base Values WIll used to check wether to update.
        currentRSize = 0.85f;
        currentDampening = 0.5f;
        currentSendAmount = 0.8f;

        //Send Default Variables to CSound
        csoundUnity.setChannel("RVBSendAmount", currentSendAmount);
        csoundUnity.setChannel("RVBDampening", currentDampening);
        csoundUnity.setChannel("RVBRoomSize", currentRSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check for the Tag
        string zone = other.tag;
        if(zone == "Room")
        {
            print("InRoom");
            //Get RoomComponent
            RoomCollider roomCollider = other.gameObject.GetComponent<RoomCollider>();
            //Get Values of Room
            float size = roomCollider.roomSize;
            float dampening = roomCollider.dampeningAmount;
            //If Diffrent Change
            if(size != currentRSize || dampening != currentDampening)
            {
                print("Changing Rooms");
                setReverbDampening(dampening);
                setReverbRoomSize(size);

            }
        }
    }

    //Original detection No Longer Used
    //private void OnCollisionEnter(Collision collision)
    //{
    //    string collisionType = collision.gameObject.tag;
    //    if (collisionType == "floorCollider")
    //    {
    //        FloorElement floorElement = collision.gameObject.GetComponent<FloorElement>();
    //        float sendamount = floorElement.sendAmount;
    //        if (currentSendAmount != sendamount)
    //        {
    //            setReverbSendAmount(sendamount);
    //            resetWalk();
    //        }
    //    }
    //}

    //Called By Floor elements to change send amount
    public void updateSendAmount(float amount)
    {
        if (currentSendAmount != amount)
        {
            print("ChangingFloor");
            currentSendAmount = amount;
            csoundUnity.setChannel("RVBSendAmount", amount);
            //resetWalk();
        }
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

    //Used to reset Walk sound. No Longer Used
    private void resetWalk()
    {
        csoundUnity.setChannel("EndWalk", Random.Range(0, 100));
        csoundUnity.setChannel("StartWalk", Random.Range(0, 100));
    }


    //Check For Movement in 4 cardinal Directions
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

        if (Input.GetKeyDown(KeyCode.A) && startWalk == false)
        {
            startWalk = true;
            csoundUnity.setChannel("StartWalk", Random.Range(0, 100));
        }
        else if (Input.GetKeyUp(KeyCode.A) && startWalk == true)
        {
            startWalk = false;
            csoundUnity.setChannel("EndWalk", Random.Range(0, 100));
        }

        if (Input.GetKeyDown(KeyCode.D) && startWalk == false)
        {
            startWalk = true;
            csoundUnity.setChannel("StartWalk", Random.Range(0, 100));
        }
        else if (Input.GetKeyUp(KeyCode.D) && startWalk == true)
        {
            startWalk = false;
            csoundUnity.setChannel("EndWalk", Random.Range(0, 100));
        }
        if (Input.GetKeyDown(KeyCode.S) && startWalk == false)
        {
            startWalk = true;
            csoundUnity.setChannel("StartWalk", Random.Range(0, 100));
        }
        else if (Input.GetKeyUp(KeyCode.S) && startWalk == true)
        {
            startWalk = false;
            csoundUnity.setChannel("EndWalk", Random.Range(0, 100));
        }

    }
    
}