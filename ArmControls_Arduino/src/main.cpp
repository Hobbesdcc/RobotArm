#include <Arduino.h>
#include <Servo.h> 

/*
Started: 2017-01-23
Current: 2021-04-xx
Dave Chamot
*/

//Test servo:
Servo myservo;  //create servo object to control a servo

//Joints:
Servo myServo1;  //create servo object 1 to control a servo 
Servo myServo2;  //create servo object 2 to control a servo
Servo myServo3;  //create servo object 3 to control a servo

//Setup values:
double ServoDelayTime = 500; //Set time the Servo will delay after it is sent move command
double ArmA_Length = 12; //Arm A Length
double ArmB_Length = 12; //Arm B Length

//Calibration Offsets:
double JointA_CalibrationOffset = 0; //mounting plate for Servo might not be 90degrees, so this is the offset
double JointC_CalibrationOffset = 5; //mounting plate for Servo might not be 90degrees, so this is the offset

double GotoX = 0; //Goto X postion
double GotoY = 0; //Goto Y postion
double GotoZ = 0; //Goto Y postion

//Servo Min/Max Range in degrees:
float Servo1_RangeLimitMin = 0;
float Servo1_RangeLimitMax = 180;

float Servo2_RangeLimitMin = 0;
float Servo2_RangeLimitMax = 180;

float Servo3_RangeLimitMin = 0;
float Servo3_RangeLimitMax = 180;

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

//Joint Angles A,B,C
double JointA = 0;        double JointB = 0;        double JointC = 0;
double JointA_degree = 0; double JointB_degree = 0; double JointC_degree = 0;

//Fuctions Declarations
int funcGetGOTO(String);
void SetServoAnagle(Servo, float, float, float);
void JointCalculations();


//= SETUP ===========================
void setup() {
	Serial.begin(9600);
	Serial.println("---------------------------");
	Serial.println("--- Start SerialMonitor ---");
  Serial.println("---------------------------");
	Serial.println(); 

	//Servo Motors Pins
	myServo1.attach(10);	// attaches the servo on pin 10 to the servo object, Big Arm
	myServo2.attach(9);		// attaches the servo on pin 09 to the servo object, Small Arm
  myServo3.attach(8);		// attaches the servo on pin 08 to the servo object, Base

  Serial.println(Servo1_RangeLimitMin); 
  Serial.println(Servo1_RangeLimitMax); 

  //Go home all servos (runs once on start)
  SetServoAnagle(myServo1, 90, Servo1_RangeLimitMin, Servo1_RangeLimitMax); 
  SetServoAnagle(myServo2, 90, Servo2_RangeLimitMin, Servo2_RangeLimitMax);
  SetServoAnagle(myServo3, 90, Servo3_RangeLimitMin, Servo3_RangeLimitMax);
}





//================================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//= Main Loop ====================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
//================================== <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
void loop() {
  
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
    myServo1.write(JointA_degree-JointA_CalibrationOffset);
    myServo2.write(180-JointC_degree-JointC_CalibrationOffset); //must use 180-Value due to how the servo is mounted (inverted)

    Serial.println("< Servos set to Joint Values >");
    Serial.println("");
    delay(ServoDelayTime);  //delay for servo to move
  }

}






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
void SetServoAnagle(Servo servo, float ServoAnagle, float RangeLimitMin, float RangeLimitMax){
    //Functions to set servo if its in limits
    if(JointC_degree > Servo2_RangeLimitMin ||  JointC_degree < Servo2_RangeLimitMax){
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



// == Function ================================
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