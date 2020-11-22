using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public CsoundUnity csoundUnity = null;
    public bool startWalk = false;
    private void Awake()
    {
        csoundUnity = GetComponent<CsoundUnity>();
    }



    void Start()
    {
        //csoundUnity.setChannel("StartWalk",1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        string collisionType = collision.gameObject.tag;
        switch (collisionType)
        {
            case "hardFloor":
                //float hardness = collision.gameObject.GetComponent<>();
                //setFloorHardNess();
                break;
            case "softFloor":
                //setFloorHardness();
                break;
            case "roomCollider":
                //Room collider will be responsible for size of 
                //setRoomPopulation
                //setRoomSize()
                break;
            default:
                break;
        }
    }
    
    //set the send amount
    private void setReverbSendAmount(float sendAmount)
    {
        csoundUnity.setChannel("RVBSendAmount", sendAmount);
    }

    //set the dampening variable
    private void setReverbDampening(float dampening)
    {
        csoundUnity.setChannel("RVBDampening", dampening);
    }

    //Set room size reverb for CSound must be between 0-1
    private void setReverbRoomSize(float size)
    {
        csoundUnity.setChannel("RVBRoomSize", size);
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