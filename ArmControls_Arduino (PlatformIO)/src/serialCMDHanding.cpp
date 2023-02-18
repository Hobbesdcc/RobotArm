#include <Arduino.h>

// == Function ================================
String SerialInterface_Receiving(){
  String cmdReceived;

  //Loop waiting for input
  while(cmdReceived.length() < 1) 
  {
    if (Serial.available() > 0) 
    { 
    cmdReceived = Serial.readString();
    }
  }

  return cmdReceived; 
}