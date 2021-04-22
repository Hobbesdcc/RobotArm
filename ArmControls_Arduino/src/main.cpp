#include <Arduino.h>
#include <Servo.h> 
#include <header.h>

/*
Started: 2017-01-23
Current: 2021-04-xx
Dave Chamot
*/

//See header fill for set up values!

//= SETUP ===========================
void setup() {
	Serial.begin(9600);
	Serial.println("---------------------------");
	Serial.println("--- Start SerialMonitor ---");
  Serial.println("---------------------------");
	Serial.println(); 

	//Servo Motors Pins
	myServo1.attach(8);   // attaches the servo on pin 10 to the servo object, BASE
	myServo2.attach(9);		// attaches the servo on pin 09 to the servo object, BIG ARM 
  myServo3.attach(10);	// attaches the servo on pin 08 to the servo object, SMALL ARM

  Serial.println(Servo1_RangeLimitMin); 
  Serial.println(Servo1_RangeLimitMax); 

  //Go home all servos (runs once on start) //parms SetServoAnagle(Servo servo, float ServoAnagle, float RangeLimitMin, float RangeLimitMax)
  SetServoAnagle(myServo1, 90, Servo1_RangeLimitMin, Servo1_RangeLimitMax); 
  SetServoAnagle(myServo2, 90-JointA_CalibrationOffset, Servo2_RangeLimitMin, Servo2_RangeLimitMax);
  SetServoAnagle(myServo3, 90-JointC_CalibrationOffset, Servo3_RangeLimitMin, Servo3_RangeLimitMax);

}




//================================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//= Main Loop ====================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//================================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
void loop() {

  //HMI Serial Command Interface
  commandReceived = SerialInterface_Receiving();

  //Remove special characters from string, and print to serial for user feedback
  String feedback = commandReceived;
  int start = feedback.indexOf('$');
  int end = feedback.indexOf('#');
  feedback = feedback.substring(start+1, end);
  Serial.print(">> Arduino Received: [ "); Serial.print(feedback); Serial.println(" ]");


  //Detect what command was sent
  ReceiveCommands_RequestStatus();        //Check if messages are Request Status
  ReceiveCommands_RequestModeChange();    //Check if messages are Request Mode Change
  ReceiveCommands_RequestStateChange();   //Check if messages are Request State Change



  //Only Run if Started
  if (state == Started){
    
    switch(mode) {
      case Manual:
        //Serial.println("Im in Manual!");

        //Get Inputs X an Y goto locations
        GotoX = funcGetGOTO("GOTO X");
        GotoY = funcGetGOTO("GOTO Y");

        //Run Joint math
        JointCalculations(); 

        //Prints JointA and JointC final values:
        Serial.print("JointA degree: ");  Serial.println(JointA_degree);
        //Serial.print("JointB degree: ");  Serial.println(JointB_degree);
        Serial.print("JointC degree: ");  Serial.println(JointC_degree);
        Serial.println("");


        //Check if Joint Values found are Real Numbers & Within Servo min/max limits
        if (isnan(JointA_degree) || isnan(JointA_degree)){
          Serial.println("< ERRROR: Input values Invalid >");
          Serial.println("");

        } else if(JointA_degree < Servo1_RangeLimitMin ||  JointA_degree > Servo1_RangeLimitMax)  {
          Serial.println("< ERROR: Joint A Value out of min/max range >");
          Serial.println("");

        } else if(JointC_degree < Servo2_RangeLimitMin ||  JointC_degree > Servo2_RangeLimitMax)  {
          Serial.println("< ERROR: Joint B Value out of min/max range >");
          Serial.println("");

        } else {
          //Writes the FINAL joint values into the servos
          SetServoAnagle(myServo2, JointA_degree-JointA_CalibrationOffset, Servo2_RangeLimitMin, Servo2_RangeLimitMax);
          SetServoAnagle(myServo3, 180-JointC_degree-JointC_CalibrationOffset, Servo2_RangeLimitMin, Servo2_RangeLimitMax);

          Serial.println("< Servos set to Joint Values >");
          Serial.println("");
          delay(ServoDelayTime);  //delay for servo to move
        }

        break;

      case Auto:
          //Serial.println("IM IN AUTO MODE!"); 
          break;


      default : //Optional
          Serial.println("[ERROR: No Mode detected]");
          break;
    }

  }else{
    Serial.println("[Nothing can be run when machine in Stopped State]");
  }
  
}//<EndOfLoop>


// ================================== = = = = = = = = = = = = = = = = ===
//   FUNCTIONS ====================== = = = = = = = = = = = = = = = = ===
// ================================== = = = = = = = = = = = = = = = = ===

// == Function ================================
int funcGetGOTO(String description){

	//Functions that gets inputs and filters them to make sure they are in range
	int result = 0;
	String incomingByte;

	//Print prompts:
	Serial.print("Input " + description + ": ");
	Serial.println("");

	//Loop waiting for input
	while(incomingByte.length() < 1) 
	{
	  if (Serial.available() > 0) 
	  { 
		incomingByte = Serial.readString();
	  }
	}

	//Convert Input string to int, and place into "result"
	result = incomingByte.toInt(); 

	//Print result values
	Serial.print("Result: ");
	Serial.println(result);
  Serial.println("");
  
  return result; 
  }

// == Function ================================
void ReceiveCommands_RequestStatus(){
  //Publish Mode Status to Serial Port (for HMI to read) 
  if (-1 != commandReceived.indexOf(CMD_Status_GetMode)){ //indexOf returns the index of val within the String, or -1 if not found.
    switch(mode) {
      case Manual:
        Serial.println(CMD_Mode_Manual);
        break;

      case Auto:
        Serial.println(CMD_Mode_Auto);
        break;

      default:
        Serial.println("[ERROR: NO MODE DETECTED]"); 
        break;
    }
  }

  //Publish State Status to Serial Port (for HMI to read)
  if (-1 != commandReceived.indexOf(CMD_Status_GetState)){ //indexOf returns the index of val within the String, or -1 if not found.
    switch(state) {
      case Idel:
        Serial.println(CMD_State_Idel);
        break;

      case Started:
        Serial.println(CMD_State_Started);
        break;

      case Stopped:
        Serial.println(CMD_State_Stopped);
        break;

      default:
        Serial.println("[ERROR: NO STATE DETECTED]"); 
        break;
    }
  }
}

// == Function ================================
void ReceiveCommands_RequestModeChange(){
  //Check if message request a mode chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_Mode_Manual)){
    if((state == Stopped || state == Idel) && mode == Auto){
      mode = Manual;
      Serial.println(CMD_Mode_Manual);
    }
    else if(mode == Manual){
    Serial.println("[ERROR: Already in Manual Mode]"); 
    }
    else{
      Serial.println("[ERROR: Must Be in Idel/Stopped AND in Auto mode to change to Manaul Mode]"); 
    }
  }
  //Check if message request a mode chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_Mode_Auto)){
    if((state == Stopped || state == Idel)  && mode == Manual){
      mode = Auto;
      Serial.println(CMD_Mode_Auto);
    }
    else if(mode == Auto){
      Serial.println("[ERROR: Already in Auto Mode]"); 
    }
    else{
      Serial.println("[ERROR: Must Be in Idel/Stopped AND in Auto mode to change to Auto Mode]"); 
    }
  }
}

// == Function ================================
void ReceiveCommands_RequestStateChange(){
  //Check if message request a State chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_State_Reset)){
    if(state == Stopped || state == Idel){
      state = Idel;
       Serial.println(CMD_State_Idel);
    }else{
      Serial.println("[ERROR: Must Be stopped/Idel State AND in Auto/Manual mode to reset to Idel]"); 
    }
  }
  //Check if message request a State chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_State_Start)){
    if(state == Idel){
      state = Started;
      Serial.println(CMD_State_Started);
    }else{
      Serial.println("[ERROR: Must Be in Idel State to move to Started]"); 
    }
  }
  //Check if message request a State chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_State_Stop)){
    if(state != Stopped){
      state = Stopped;
      Serial.println(CMD_State_Stopped);
    }else{
      Serial.println("[ERROR: you are already stopped]"); 
    }
  }
}



// == Join Function ===========================
void JointCalculations(){

  // ======================================================================
  // **********           JOINT MATH (Run every cycle)           **********
  // ======================================================================


  // **********************************************************************
  // << Joint A Math: >> // (Triangle C angle B) + (Triangle D angle B)
  // **********************************************************************
    
  // *** Step 1 ****
  // Finding (Triangle C angle B)
  TriC_AnglB = atan2(GotoY,GotoX); // =DEGREES(ATAN(Opp/Adj)) //finding Tri C angle B


  // *** Step 2 ****
  // Finding (Triangle C Side A & B, USER INPUT)
  TriC_SideA = GotoX; // Setting Triangle D, side A to Arm A Length
  TriC_SideB = GotoY; // Setting Triangle D, side B to Arm B Length


  // *** Step 3 ****
  // Finding (Triangle D Side C)
  TriD_SideC = sqrt(pow(TriC_SideA,2)+pow(TriC_SideB,2)); // =SQRT(TriCsideA^2+TriCsideB^2)
  

  // *** Step 4 ****
  // Finding (Triangle C Side D) (already found, just set = to)
  TriC_SideC = TriD_SideC; // set TriDsideC = TriCsideC;
    

  // *** Step 5 ****
  // Finding (Triangle C Sides A & B, just arm lengths)
  TriD_SideA = ArmA_Length; // Setting Triangle D, side A to Arm A Length
  TriD_SideB = ArmB_Length; // Setting Triangle D, side B to Arm B Length


  // *** Step 6 **** 
  // Finding (Triangle C Angle B) using Law of cosines
  // =DEGREES(ACOS((c^2+a^2-b^2)/(2*c*a)))
  // =DEGREES(ACOS((TriDsideC^2+TriDsideA^2-TriDsideB^2)/(2*TriDsideC*TriDsideA)))
  TriD_AnglB = acos((pow(TriD_SideC,2)+pow(TriD_SideA,2)-pow(TriD_SideB,2))/(2*TriD_SideC*TriD_SideA));


  // *** Step 7 ****
  // Finding Joint A = (Triangle C angle B) + (Triangle D angle B) (1st servo position)
  JointA = TriC_AnglB + TriD_AnglB; //Joint A (angle), (Triangle C angle B) + (Triangle D angle B)

  
  // **********************************************************************
  // << Joint B Math: >>
  // **********************************************************************

  // *** Step 7 ****
  // Finding (Triangle D Angle C) using Law of cosines
  // =DEGREES(ACOS((a^2+b^2-c^2)/(2*a*b)))
  // =DEGREES(ACOS((TriDsideA^2+TriDsideB^2-TriDsideC^2)/(2*TriDsideA*TriDsideB)))
  TriD_AnglC = acos((pow(TriD_SideA,2)+pow(TriD_SideB,2)-pow(TriD_SideC,2))/(2*TriD_SideA*TriD_SideB));


  // *** Step 8 ****
  // Finding Joint B (no servo here, not used)
  JointB = TriD_AnglC; //Set JointA as Triangle D angle C


  // **********************************************************************
  // << Joint C Math: >>
  // **********************************************************************

  // *** Step 9 ****
  //Finding Joint C (2nd servo position) 
  //1.5708 radians ~= 90 degrees
  JointC = JointB - (1.5708 - (JointA)); //use this OR "JointC = TriDanglC - (1.5708 - (TriCanglB + TriDanglB));"

  
  // **********************************************************************
  // << Send Joint A & Joint C calulated values to servos 
  // **********************************************************************
  
  // *** Step 10 ****
  //Convert joint Radians to degrees (deg = rad * 57296 / 1000)
  JointA_degree = ((JointA * 57296 )/ 1000);
  JointB_degree = ((JointB * 57296 )/ 1000);
  JointC_degree = ((JointC * 57296 )/ 1000);
  
}