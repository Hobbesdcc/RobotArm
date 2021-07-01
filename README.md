# ARA - Another Robot Arm!

<p align="center">
  <img width="600" src="Media\cover.jpg">
</p>



## Overview:
Project to design bulid and control a simple Robotic Arm.

I gave myself a challenge to create a small robot arm and control it in one month! April 2021.
I used a lot other projects in the 3d printing space for inspiration and understanding. (EEZYbotARM, MeArm, an many others, Thanks!)

This Arm was created in OnShape, controlled with and Arduino, and has an HMI (human machine interface) Created in WinForms.
With the controls you can do manual movements, but you can also teach each position, and play it back as a looping script!

Find more info & models for this project here: 
https://www.prusaprinters.org/prints/70258-ara-another-robot-arm


&nbsp;

## Controls overview:

<p align="center">
  <img width="600" src="Media\hmi.png">
</p>

* Download Arduino code to Arduino. (I used VScode set up with PlatformIO)
* Download and run "ArmHMI_WinForms.exe" winform application.
* Input COM port Number and Hit Connect.
* STOP and then RESET the system to return it to "IDEL" state.
* When in Idle, you can hit START. This should engage the relay and servos.
* If you are in MNAUAL mode, you can use any of the Manual controls.
* you must STOP and RESET the system to switch to AUTOMATIC mode.
* When in AUTOMATIC mode you can use the Automatic controls.

&nbsp;

## Script Builder:
* To build a script, go to Manual mode.
* Go to a position you want, and click on "Teach Current Point" is Script building section.
* You can also click on other commands in the Script building section to add them to the list.
* Once you are happy with the Script, Stop system, go to Automatic mode, start system.
* NOW you can "Start Script".
* (hit, the Scripts are just text, you can edit them, or copy them in/out)

## Example Script:
```
GOTO_X12,Y12,Z0;
GOTO_X4,Y4,Z0;
GOTO_X8,Y0,Z0;
OpenGrip;
GOTO_X12,Y-3,Z0;
CloseGrip;
GOTO_X12,Y4,Z0;
GOTO_X12,Y4,Z5;
GOTO_X12,Y-3,Z5;
OpenGrip;
GOTO_X12,Y0,Z5;
CloseGrip;
Loop;
```
