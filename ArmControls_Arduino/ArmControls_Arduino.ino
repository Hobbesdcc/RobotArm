#include <Servo.h>

//Test servo:
Servo myservo;  //create servo object to control a servo

//Servo Motors:
Servo myServo1;  //create servo object 1 to control a servo (Base)
Servo myServo2;  //create servo object 2 to control a servo (Big arm)
Servo myServo3;  //create servo object 3 to control a servo (Small arm)
Servo myServo4;  //create servo object 4 to control a servo (Gripper)

//Power relay
const int RELAY_PIN = 2;

//Setup values:
double ServoDelayTime = 500; //Set time the Servo will delay after it is sent move command
double ArmA_Length = 12; //Arm A Length
double ArmB_Length = 12; //Arm B Length

//Calibration Offsets:
double JointA_CalibrationOffset = 0; //mounting plate for Servo might not be 90degrees, so this is the offset
double JointC_CalibrationOffset = 5; //mounting plate for Servo might not be 90degrees, so this is the offset
double BaseAxis_CalibrationOffset = -10; //mounting plate for Servo might not be 90degrees, so this is the offset

double positionXYZ[3]; //PostionArray to allow command parseing in same function
double GotoX; //Goto X postion
double GotoY; //Goto Y postion
double GotoZ; //Goto Y postion

double GotoX_Old; //Goto X postion OLD for detecting change
double GotoY_Old; //Goto Y postion OLD for detecting change
double GotoZ_Old; //Goto Y postion OLD for detecting change

//Servo Min/Max Range in degrees:
float Servo1_RangeLimitMin = 0;   //(Base)
float Servo1_RangeLimitMax = 180; //(Base)
float Servo2_RangeLimitMin = 0;   //(Big arm)
float Servo2_RangeLimitMax = 180; //(Big arm)
float Servo3_RangeLimitMin = 0;   //(Small arm)
float Servo3_RangeLimitMax = 180; //(Small arm)
float Servo4_RangeLimitMin = 4;   //(Gripper)
float Servo4_RangeLimitMax = 61;  //(Gripper)

//Triangle A,B,C,E setup init values:
double TriA_AnglA = 0; double TriA_AnglB = 0; double TriA_AnglC = 0;
double TriA_SideA = 0; double TriA_SideB = 0; double TriA_SideC = 0;

double TriB_AnglA = 0; double TriB_AnglB = 0; double TriB_AnglC = 0;
double TriB_SideA = 0; double TriB_SideB = 0; double TriB_SideC = 0;

double TriC_AnglA = 0; double TriC_AnglB = 0; double TriC_AnglC = 0;
double TriC_SideA = 0; double TriC_SideB = 0; double TriC_SideC = 0;

double TriD_AnglA = 0; double TriD_AnglB = 0; double TriD_AnglC = 0;
double TriD_SideA = 0; double TriD_SideB = 0; double TriD_SideC = 0;

double TriE_AnglA = 0; double TriE_AnglB = 0; double TriE_AnglC = 0;
double TriE_SideA = 0; double TriE_SideB = 0; double TriE_SideC = 0;

//Joint Angles A,B,C, & Base Axis
double JointA = 0;        double JointB = 0;        double JointC = 0;
double JointA_degree = 0; double JointB_degree = 0; double JointC_degree = 0;
double BaseAxis = 0;      double BaseAxis_degree = 0;

//Setup Enums for mode and state, and there defualt states
enum State {Idel,Started,Stopped};
enum Mode {Manual,Auto};
State state = Idel;
Mode mode = Manual;

// Command Strings, Same KeyWords used on both sides (serial to Ardunio to C# Form)
String CMD_Home_All			    = "$HOME_ALL#";
String CMD_Home_AxisA			= "$HOME_AXIS_A#";
String CMD_Home_AxisB			= "$HOME_AXIS_B#";
String CMD_Home_Base			= "$HOME_Base#";

String CMD_State_Idel			= "$STATE_IDEL#";
String CMD_State_Started		= "$STATE_STARTED#";
String CMD_State_Stopped		= "$STATE_STOPPED#";

String CMD_State_Start			= "$STATE_START#";
String CMD_State_Stop			= "$STATE_STOP#";
String CMD_State_Reset			= "$STATE_RESET#";

String CMD_Mode_Manual			= "$MODE_MANUAL#";
String CMD_Mode_Auto			= "$MODE_AUTO#";

String CMD_Servos_Attach		= "$SERVOS_ATTACH#";
String CMD_Servos_Detach		= "$SERVOS_DETACH#";
String CMD_Servos_GOTO			= "$SERVOS_GOTO_X,Y,Z#";
String CMD_Servos_OPENGRIP		= "$SERVOS_OPENGRIP#";
String CMD_Servos_CLOSEGRIP		= "$SERVOS_CLOSEGRIP#";

String CMD_Status_GetState		= "$STATUS_GETSTATE#";
String CMD_Status_GetMode		= "$STATUS_GETMODE#";


//Fuctions Declarations
void Action_Homing(bool, bool, bool, bool);
void Action_GOTO_Positon();
void Action_GripperOpenClose();
void Action_SetServoAnagle(Servo, float, float, float);

void JointCalculations();
String SerialInterface_Receiving();

void ReceiveCommands_RequestStatus();
void ReceiveCommands_RequestModeChange();
void ReceiveCommands_RequestModeChange();
void ReceiveCommands_RequestStateChange();
void ReceiveCommands_GotoPositon(double[]);
void ReceiveCommands_Homing();
void ReceiveCommands_ServosDisconnect();
void ReceiveCommands_Gripper();


//Serial Command varibles - HMI Commands from Serial Interface
String commandReceived = "";
boolean newData = false;
String bulidMessageString;
char endMarker = '#';
char receivedChar;
String feedback;

//When a command comes it, these values are set high and trigger the actual command 
bool CMD_ISSUED_HOME_ALL;
bool CMD_ISSUED_HOME_AxisA;
bool CMD_ISSUED_HOME_AxisB;
bool CMD_ISSUED_HOME_Base;
bool CMD_ISSUED_Servos_GOTO;
bool CMD_ISSUED_Servos_Attach;
bool CMD_ISSUED_Servos_Detach;
bool CMD_ISSUED_Servos_GripOpen;
bool CMD_ISSUED_Servos_GripClose;

//other
bool initStartedLoopDone = false;

//= SETUP ===========================
void setup() {
	Serial.begin(9600);
	Serial.println("---------------------------");
	Serial.println("--- Start SerialMonitor ---");
  Serial.println("---------------------------");
	Serial.println(); 

	//Servo Motors Pins
	myServo1.attach(8);   // attaches the servo on pin 08 to the servo object, BASE
	myServo2.attach(9);		// attaches the servo on pin 09 to the servo object, BIG ARM 
  myServo3.attach(10);	// attaches the servo on pin 10 to the servo object, SMALL ARM
  myServo4.attach(11);	// attaches the servo on pin 11 to the servo object, Gripper
  
  pinMode(RELAY_PIN, OUTPUT); // Power relay (turn on when started)

  Serial.println(Servo1_RangeLimitMin); 
  Serial.println(Servo1_RangeLimitMax);

  //Go home all servos (runs once on start)
  Action_Homing(1,1,1,1); //Base,AxisA,AxisB,Grippper
}



//================================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//= Main Loop ====================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//================================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
void loop() {
  
  //HMI Commands from Serial Interface:
  //Read each char coming in and add it to bulidMessageString until endMarker seen
  while (Serial.available() > 0 && newData == false) {
        receivedChar = Serial.read();

        if (receivedChar != endMarker) {
            bulidMessageString += receivedChar;
        }
        else {
            bulidMessageString += receivedChar;
            newData = true;
        }
  }

  //Once new command found, Run it thought all checks to understand and process it
  if (newData == true) {

    //Overview: Get message -> Parse it out -> go through ReceiveCommands_ functions to identify it -> 
    // -> once identifyed set CMD_ISSUED_ high so it can be exectued later

    commandReceived = bulidMessageString; //Load new command into "commandReceived"
    bulidMessageString = ""; //Clear bulid Message String for next message
    newData = false;
    //Serial.print(">ACK:["); Serial.print(commandReceived); Serial.println("]");

    //load into feedback, Remove special characters from string, and print to serial for user feedback
    feedback = commandReceived;
    int begin = feedback.indexOf('$');
    int end = feedback.indexOf('#');
    feedback = feedback.substring(begin+1, end);
    Serial.print(">> Arduino Received: ["); Serial.print(feedback); Serial.println("]");


    //Identify and process the new command that was just parsed (each fuction looks for a diffrent command)
    ReceiveCommands_RequestStatus();        //Check if messages are Request Status
    ReceiveCommands_RequestModeChange();    //Check if messages are Request Mode Change
    ReceiveCommands_RequestStateChange();   //Check if messages are Request State Change
    ReceiveCommands_Homing();
    ReceiveCommands_ServosDisconnect();
    ReceiveCommands_Gripper();

    ReceiveCommands_GotoPositon(positionXYZ);   //Check if goto postion message sent, if so parse the XYZ from it.
    GotoX = positionXYZ[1]; //Load parsed value into Goto X postion
    GotoY = positionXYZ[2]; //Load parsed value into Goto Y postion
    GotoZ = positionXYZ[3]; //Load parsed value into Goto Z postion

  }


  //Only Run if Started
  //Serial.print("state: "); Serial.println(state);
  if (state == Started){

    digitalWrite(RELAY_PIN, LOW); // Toggle relay ON, allowing power to servo motors

    switch(mode) {
      //###############################
      case Manual:
        
        //Action: GOTO Positon
        if (initStartedLoopDone && CMD_ISSUED_Servos_GOTO){
          Action_GOTO_Positon();
        }
        
        //Action: Gripper Open/Close
        if (CMD_ISSUED_Servos_GripOpen || CMD_ISSUED_Servos_GripClose){
          Action_GripperOpenClose();
        }

        //Action: Homing
        if (CMD_ISSUED_HOME_ALL){
          Action_Homing(1,1,1,1); //AxisA,AxisB,Base
          CMD_ISSUED_HOME_ALL = false; //reset 
        }
        if (CMD_ISSUED_HOME_AxisA){
          Action_Homing(0,1,0,0); //AxisA,AxisB,Base
          CMD_ISSUED_HOME_AxisA = false; //reset 
        }
        if (CMD_ISSUED_HOME_AxisB){
          Action_Homing(0,0,1,0); //AxisA,AxisB,Base
          CMD_ISSUED_HOME_AxisB = false; //reset 
        }
        if (CMD_ISSUED_HOME_Base){
          Action_Homing(1,0,0,0); //AxisA,AxisB,Base
          CMD_ISSUED_HOME_Base = false; //reset 
        }

        //Action: Servo Attach/Detach
        if (CMD_ISSUED_Servos_Detach){
          myServo1.detach();    // detaches the servo on pin 08 to the servo object, BASE
          myServo2.detach();	  // detaches the servo on pin 09 to the servo object, BIG ARM 
          myServo3.detach();	  // detaches the servo on pin 10 to the servo object, SMALL ARM
          myServo4.detach();	  // detaches the servo on pin 11 to the servo object, Gripper
          CMD_ISSUED_Servos_Detach = false; //reset 
        }
        if (CMD_ISSUED_Servos_Attach){
          myServo1.attach(8);   // attaches the servo on pin 08 to the servo object, BASE
          myServo2.attach(9);		// attaches the servo on pin 09 to the servo object, BIG ARM 
          myServo3.attach(10);	// attaches the servo on pin 10 to the servo object, SMALL ARM
          myServo4.attach(11);	// attaches the servo on pin 11 to the servo object, Gripper
          CMD_ISSUED_Servos_Attach = false; //reset 
        }
      

        //Old Value for edge detect
        GotoX_Old = GotoX;
        GotoY_Old = GotoY;
        GotoZ_Old = GotoZ;
        
        initStartedLoopDone = true; //Allow to loop once on start without running some commands/code
        break;

      //###############################
      case Auto:

        //Action: GOTO Positon
        if (CMD_ISSUED_Servos_GOTO){ 
          Action_GOTO_Positon();
        }
        
        //Action: Gripper Open/Close
        if (CMD_ISSUED_Servos_GripOpen || CMD_ISSUED_Servos_GripClose){
          Action_GripperOpenClose();
        }
        
        //Old Value for edge detect
        GotoX_Old = GotoX;
        GotoY_Old = GotoY;
        GotoZ_Old = GotoZ;
        break;

      //###############################
      default :
        Serial.println("[ERROR: No Mode detected]");
        break;
    }

  }else{
    digitalWrite(RELAY_PIN, HIGH); //Toggle relay OFF, dis-allowing power to servo motors.

    initStartedLoopDone = false; //reset init Started Loop Done bit
    //Serial.println("[Nothing can be run when machine in Stopped State]");

    //* //reset all internal issued commands
    CMD_ISSUED_HOME_ALL         = false;
    CMD_ISSUED_HOME_AxisA       = false;
    CMD_ISSUED_HOME_AxisB       = false;
    CMD_ISSUED_HOME_Base        = false;
    CMD_ISSUED_Servos_GOTO      = false;
    CMD_ISSUED_Servos_Attach    = false;
    CMD_ISSUED_Servos_Detach    = false;
    CMD_ISSUED_Servos_GripOpen  = false;
    CMD_ISSUED_Servos_GripClose = false;
    //*/
  }
  
}//<EndOfLoop>


// ================================== = = = = = = = = = = = = = = = = ===
//   FUNCTIONS ====================== = = = = = = = = = = = = = = = = ===
// ================================== = = = = = = = = = = = = = = = = ===

// == Function ================================
void Action_Homing(bool Base, bool AxisA, bool AxisB, bool Gripper){
  //parms SetServoAnagle(Servo servo, float ServoAnagle, float RangeLimitMin, float RangeLimitMax)
  if (Base){
   Action_SetServoAnagle(myServo1, 90-BaseAxis_CalibrationOffset, Servo1_RangeLimitMin, Servo1_RangeLimitMax); 
  }
  if (AxisA){
    Action_SetServoAnagle(myServo2, 90-JointA_CalibrationOffset, Servo2_RangeLimitMin, Servo2_RangeLimitMax);
  }
  if (AxisB){
    Action_SetServoAnagle(myServo3, 90-JointC_CalibrationOffset, Servo3_RangeLimitMin, Servo3_RangeLimitMax);
  }
  if (Gripper){
    Action_SetServoAnagle(myServo4, 5, Servo4_RangeLimitMin, Servo4_RangeLimitMax);
  }
}

// == Function ================================
void Action_GOTO_Positon(){
  //Run Joint math
  JointCalculations(); 

  //Prints JointA and JointC final values:
  Serial.print("JointA degree: ");  Serial.println(JointA_degree);
  //Serial.print("JointB degree: ");  Serial.println(JointB_degree);
  Serial.print("JointC degree: ");  Serial.println(JointC_degree);
  Serial.print("GOTO: X"); Serial.print(GotoX); Serial.print(", Y"); Serial.print(GotoY); Serial.print(", Z"); Serial.println(GotoZ); 
  Serial.println("");


  //Check if Joint Values found are Real Numbers & Within Servo min/max limits
  if (isnan(JointA_degree) || isnan(JointA_degree) || isnan(BaseAxis_degree)){
    Serial.println(F("< ERRROR: Input values Invalid >"));

  } else if(BaseAxis_degree < Servo1_RangeLimitMin ||  BaseAxis_degree > Servo1_RangeLimitMax)  {
    Serial.println(F("< ERROR: Base Axis Value out of min/max range >"));

  } else if(JointA_degree < Servo2_RangeLimitMin ||  JointA_degree > Servo2_RangeLimitMax)  {
    Serial.println(F("< ERROR: Joint A Value out of min/max range >"));

  } else if(JointC_degree < Servo3_RangeLimitMin ||  JointC_degree > Servo3_RangeLimitMax)  {
    Serial.println(F("< ERROR: Joint B Value out of min/max range >"));

  } else {
    //Writes the FINAL joint values into the servos
    Action_SetServoAnagle(myServo1, BaseAxis_degree-BaseAxis_CalibrationOffset, Servo1_RangeLimitMin, Servo1_RangeLimitMax);
    Action_SetServoAnagle(myServo2, JointA_degree-JointA_CalibrationOffset, Servo2_RangeLimitMin, Servo2_RangeLimitMax);
    Action_SetServoAnagle(myServo3, 180-JointC_degree-JointC_CalibrationOffset, Servo3_RangeLimitMin, Servo3_RangeLimitMax);

    Serial.println(F("< Arduino: Servos Axis Values Set >"));
    delay(ServoDelayTime);  //delay for servo to move
  }
  CMD_ISSUED_Servos_GOTO = false; //reset command
}

// == Function ================================
void Action_GripperOpenClose(){
  //Action: Servo Open/Close Gripper
  if (CMD_ISSUED_Servos_GripOpen){
    Action_SetServoAnagle(myServo4, 65, Servo4_RangeLimitMin, Servo4_RangeLimitMax);
    CMD_ISSUED_Servos_GripOpen = false; //reset 
  }
  if (CMD_ISSUED_Servos_GripClose){
    Action_SetServoAnagle(myServo4, 5, Servo4_RangeLimitMin, Servo4_RangeLimitMax);
    CMD_ISSUED_Servos_GripClose = false; //reset 
  }
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
        Serial.println(F("[ERROR: NO MODE DETECTED]")); 
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
        Serial.println(F("[ERROR: NO STATE DETECTED]")); 
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
    Serial.println(F("[ERROR: Already in Manual Mode]")); 
    }
    else{
      Serial.println(F("[ERROR: Must Be in Idel/Stopped AND in Auto mode to change to Manaul Mode]")); 
    }
  }
  //Check if message request a mode chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_Mode_Auto)){
    if((state == Stopped || state == Idel)  && mode == Manual){
      mode = Auto;
      Serial.println(CMD_Mode_Auto);
    }
    else if(mode == Auto){
      Serial.println(F("[ERROR: Already in Auto Mode]")); 
    }
    else{
      Serial.println(F("[ERROR: Must Be in Idel/Stopped AND in Auto mode to change to Auto Mode]")); 
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
      //Serial.println("[ERROR: Must Be stopped/Idel State AND in Auto/Manual mode to reset to Idel]"); 
    }
  }
  //Check if message request a State chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_State_Start)){
    if(state == Idel){
      state = Started;
      Serial.println(CMD_State_Started);
    }else if (state == Started){
      Serial.println(F("[ERROR: Already in Started State]"));
    }else{
      Serial.println(F("[ERROR: Must Be in Idel State to move to Started]")); 
    }
  }
  //Check if message request a State chanage, then check if thats possible
  if (-1 != commandReceived.indexOf(CMD_State_Stop)){
    if(state != Stopped){
      state = Stopped;
      Serial.println(CMD_State_Stopped);
    }else{
      Serial.println(F("[ERROR: you are already stopped]")); 
    }
  }

}

// == Function ================================
void ReceiveCommands_GotoPositon(double p_PositionXYZ[]){
  
  if (-1 != commandReceived.indexOf("SERVOS_GOTO")){
    if (state == Started){
      //This function goes through the cmd message, looks for X Y Z, pulls them out as substrings and loads them into an array.
      int posStart;
      int posEnd;

      //Parse X
      posStart = commandReceived.indexOf("X", 0);
      posEnd = commandReceived.indexOf(",", posStart);
      p_PositionXYZ[1] = commandReceived.substring(posStart+1, posEnd).toDouble(); //Assign X postion
      //Serial.print("substring:"); Serial.println(commandReceived.substring(posStart+1, posEnd)); //debug

      //Parse Y
      posStart = commandReceived.indexOf("Y", posEnd);
      posEnd = commandReceived.indexOf(",", posStart);
      p_PositionXYZ[2] = commandReceived.substring(posStart+1, posEnd).toDouble(); //Assign Y postion
      //Serial.print("substring:"); Serial.println(commandReceived.substring(posStart+1, posEnd)); //debug

      //Parse Z
      posStart = commandReceived.indexOf("Z", posEnd);
      posEnd = commandReceived.indexOf("#", posStart);
      p_PositionXYZ[3] = commandReceived.substring(posStart+1, posEnd).toDouble(); //Assign Z postion
      //Serial.print("substring:"); Serial.println(commandReceived.substring(posStart+1, posEnd)); //debug

      Serial.print("(X,Y,Z): ["); Serial.print(p_PositionXYZ[1]);
      Serial.print(","); Serial.print(p_PositionXYZ[2]);
      Serial.print(","); Serial.print(p_PositionXYZ[3]); Serial.println("]");

      CMD_ISSUED_Servos_GOTO = true; //internal cmd issued (this is what triggers the command to happen)
    }
  } 
}

// == Function ================================
void ReceiveCommands_Homing(){
  //Check if homing messeage detected, if so set issue cmd high (the thing that will trigger the command somewhere else)
  if (-1 != commandReceived.indexOf(CMD_Home_All)){
    CMD_ISSUED_HOME_ALL = true;
    Serial.println(CMD_Home_All);
  }
  
  if (-1 != commandReceived.indexOf(CMD_Home_AxisA)){
    CMD_ISSUED_HOME_AxisA = true;
    Serial.println(CMD_Home_AxisA);
  }

  if (-1 != commandReceived.indexOf(CMD_Home_AxisB)){
    CMD_ISSUED_HOME_AxisB = true;
    Serial.println(CMD_Home_AxisB);
  }

  if (-1 != commandReceived.indexOf(CMD_Home_Base)){
    CMD_ISSUED_HOME_Base = true;
    Serial.println(CMD_Home_Base);
  }
}

// == Function ================================
void ReceiveCommands_ServosDisconnect(){
  if (-1 != commandReceived.indexOf(CMD_Servos_Attach)){
    CMD_ISSUED_Servos_Attach = true;
    Serial.println(CMD_Servos_Attach);
  }
  if (-1 != commandReceived.indexOf(CMD_Servos_Detach)){
    CMD_ISSUED_Servos_Detach = true;
    Serial.println(CMD_Servos_Detach);
  }
}

// == Function ================================
void ReceiveCommands_Gripper(){
  if (-1 != commandReceived.indexOf(CMD_Servos_OPENGRIP)){
    CMD_ISSUED_Servos_GripOpen  = true;
    //CMD_ISSUED_Servos_GripClose = false;
    Serial.println(CMD_Servos_OPENGRIP);
  }
  if (-1 != commandReceived.indexOf(CMD_Servos_CLOSEGRIP)){
    //MD_ISSUED_Servos_GripOpen  = false;
    CMD_ISSUED_Servos_GripClose = true;
    Serial.println(CMD_Servos_CLOSEGRIP);
  }
}



// == Joint Function ===========================
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
  // << Base Axis Math: >>
  // **********************************************************************

  // *** Step X **** 
  //Finding Angle the base axis should be
  BaseAxis = atan2(GotoX,GotoZ);


  // **********************************************************************
  // << Send Joint A & Joint C calulated values to servos 
  // **********************************************************************
  
  // *** Step 10 ****
  //Convert joint Radians to degrees (deg = rad * 57296 / 1000)
  JointA_degree = ((JointA * 57296 )/ 1000);
  JointB_degree = ((JointB * 57296 )/ 1000);
  JointC_degree = ((JointC * 57296 )/ 1000);
  BaseAxis_degree = ((BaseAxis * 57296 )/ 1000);
  
}


// == Function ================================
void Action_SetServoAnagle(Servo servo, float ServoAnagle, float RangeLimitMin, float RangeLimitMax){
    //Functions to set servo if its in limits
    if(ServoAnagle > RangeLimitMin || ServoAnagle < RangeLimitMax){
      servo.write(ServoAnagle);
      //Serial.println("< Function: Set servo angle > ");
      //Serial.println("");
    }else
    {
      Serial.print("[Function Error] ServoAnagle value: ");
      Serial.print(ServoAnagle);
      Serial.println(" out of min/max range!");
      Serial.println("");
    }  
   
  }

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