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
        ;event "i", 3, 0, 3600
    endif

    if changed(kEnd)==1 then
        turnoff2 2, 0, 1
        ;turnoff2 3, 0, 1
    endif
endin

gaGlobalSend    init      0 

instr 2 
  kEnv         loopseg   1,0,0,1,0.002,1,0.001,0,0.9970,0,0
  aSig         pinkish   kEnv              ; Create Walk Sound
               outs      aSig, aSig        
  iSendAmount chnget "RVBSendAmount"       ; Send Amount/Diffusion can only be between 0 - 1
  
;Create Global Send Amount for use in Reverb
gaGlobalSend    =         gaGlobalSend + (aSig * iSendAmount)
endin

instr 3 ; reverb - always on
  kRsize          chnget "RVBRoomSize"                  ; room size can only be between 0 - 1
  kDampening      chnget "RVBDampening"           ; damping can only be between 0 - 1
  ; create reverb of walk sound
  aLeft,aRight  freeverb  gaGlobalSend, gaGlobalSend,kRsize,kDampening 
               outs      aLeft, aRight    ; send stereo
               clear     gaGlobalSend     ; clear global audio variable used in more sounds
endin


</CsInstruments>
<CsScore>
i"HANDLER" 0 [7200*12]
i 3 0 [7200*12]

</CsScore>
</CsoundSynthesizer>