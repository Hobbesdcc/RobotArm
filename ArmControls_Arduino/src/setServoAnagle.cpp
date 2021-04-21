#include <Arduino.h>
#include <Servo.h> 

// == Function ================================
void SetServoAnagle(Servo servo, float ServoAnagle, float RangeLimitMin, float RangeLimitMax){
    //Functions to set servo if its in limits
    if(ServoAnagle > RangeLimitMin || ServoAnagle < RangeLimitMax){
      servo.write(ServoAnagle);
      Serial.println("< Function: Set servo angle > ");
      Serial.println("");
    }else
    {
      Serial.print("[Function Error] ServoAnagle value: ");
      Serial.print(ServoAnagle);
      Serial.println(" out of min/max range!");
      Serial.println("");
    }  
   
  }