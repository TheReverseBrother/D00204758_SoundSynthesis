<Cabbage>
form caption("Character Sounds"), size(300, 200)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -m0d
</CsOptions>
<CsInstruments>
sr 	= 	44100 
ksmps 	= 	32
nchnls 	= 	2
0dbfs	=	1 

 
instr HANDLER
    kStart chnget "StartWalk"
    kEnd chnget "EndWalk"


    if changed(kStart)==1 then
        event "i", 2, 0, 3600
        event "i", 3, 0, 3600
    endif

    if changed(kEnd)==1 then
        turnoff2 2, 0, 1
        turnoff2 3, 0, 1
    endif
endin

gaRvbSend    init      0 

instr 2 
  kEnv         loopseg   1,0,0,1,0.002,1,0.001,0,0.9970,0,0
  aSig         pinkish   kEnv              ; Create Pulses
               outs      aSig, aSig        
  iRvbSendAmt chnget "RVBSendAmount"                ; Send Amount/Diffusion (0 - 1)
  
;Create global reverb from this source
gaRvbSend    =         gaRvbSend + (aSig * iRvbSendAmt)
endin

instr 3 ; reverb - always on
  kroomsize    chnget "RVBRoomSize"           ; room size (range 0 to 1)
  kHFDamp      chnget "RVBDampening"           ; high freq. damping (range 0 to 1)
  ; create reverberated version of input signal (note stereo input and output)
  aRvbL,aRvbR  freeverb  gaRvbSend, gaRvbSend,kroomsize,kHFDamp 
               outs      aRvbL, aRvbR ; send audio to outputs
               clear     gaRvbSend    ; clear global audio variable
endin


</CsInstruments>
<CsScore>
i"HANDLER" 0 [3600*12]

</CsScore>
</CsoundSynthesizer>