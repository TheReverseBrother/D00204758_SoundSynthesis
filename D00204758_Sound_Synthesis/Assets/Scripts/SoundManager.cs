using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public CsoundUnity csoundUnity = null;

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
        if(Input.GetKeyDown(KeyCode.W))
        {
            print("Hello");
            csoundUnity.setChannel("StartWalk", 1);
        }
    }
}
