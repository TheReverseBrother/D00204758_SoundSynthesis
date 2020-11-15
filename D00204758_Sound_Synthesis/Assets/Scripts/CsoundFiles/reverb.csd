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

 
instr TEST
    kStart chnget "StartWalk"

    if changed(kStart)==1 then
        event "i", "WALK", 0, 300
    endif
endin

gaRvbSend    init      0 

instr WALK 
kEnv         loopseg   0.5,0,0,1,0.003,1,0.0001,0,0.9969,0,0; amp. env.
aSig         pinkish   kEnv              ; noise pulses
             outs      aSig, aSig        ; audio to outs
iRvbSendAmt  =         0.8               ; reverb send amount (0 - 1)
;add some of the audio from this instrument to the global reverb send variable
gaRvbSend    =         gaRvbSend + (aSig * iRvbSendAmt)
endin

  instr 5 ; reverb - always on
kroomsize    init      0.85          ; room size (range 0 to 1)
kHFDamp      init      0.5           ; high freq. damping (range 0 to 1)
; create reverberated version of input signal (note stereo input and output)
aRvbL,aRvbR  freeverb  gaRvbSend, gaRvbSend,kroomsize,kHFDamp
             outs      aRvbL, aRvbR ; send audio to outputs
             clear     gaRvbSend    ; clear global audio variable
  endin


</CsInstruments>
<CsScore>
i"TEST" 0 [3600*12]
</CsScore>
</CsoundSynthesizer>