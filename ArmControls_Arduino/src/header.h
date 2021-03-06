#include <Arduino.h>

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