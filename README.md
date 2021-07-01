# RobotArm

Personal project to design bulid and control a simple Robotic Arm.

Find more info about this project here: 
https://www.prusaprinters.org/prints/70258-ara-another-robot-arm

## Controls overview:
* Download Arduino code to Arduino. (I used VScode set up with PlatformIO)
* Download and run "ArmHMI_WinForms.exe" winform application.
* Input COM port Number and Hit Connect.
* STOP and then RESET the system to retun it to "IDEL" state.
* When in Idel, you can hit START. This should engage the relay and servos.
* If you are in MNAUAL mode, you can use any of the Manaul controls.
* you must STOP and RESET the system to switch to AUTOMATIC mode.
* When in AUTOMATIC mode you can use the Automatic controls.

## Script Bulidier:
* To bulid a script, go to Manaul mode.
* Go to a postion you want, and click on "Teach Currect Point" is Script buliding section.
* You can also click on other commands in the Script buliding section to add them to the list.
* Once you are happy with the Script, Stop system, go to Automatic mode, start system.
* NOW you can "Start Script".
* (hit, the Scripts are just text, you can edit them, or copy them in/out)

## Example Script:
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
