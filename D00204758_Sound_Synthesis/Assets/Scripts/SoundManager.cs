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
