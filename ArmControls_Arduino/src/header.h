#include <Arduino.h>

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

double positionXYZ[3]; //PostionArray to allow command parseing in same function
double GotoX = 0; //Goto X postion
double GotoY = 0; //Goto Y postion
double GotoZ = 0; //Goto Y postion

double GotoX_Old = 0; //Goto X postion OLD for detecting change
double GotoY_Old = 0; //Goto Y postion OLD for detecting change
double GotoZ_Old = 0; //Goto Y postion OLD for detecting change

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

//Serial Command varibles
String commandReceived = "";

//Setup Enums for mode and state, and there defualt states
enum State {Idel,Started,Stopped};
enum Mode {Manual,Auto};

State state = Idel;
Mode mode = Manual;

// Command Strings, Same KeyWords used on both sides (serial to Ardunio to C# Form)
String CMD_Home_All				= "$HOME_ALL#";
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

String CMD_Status_GetState		= "$STATUS_GETSTATE#";
String CMD_Status_GetMode		= "$STATUS_GETMODE#";


//Fuctions Declarations
void Action_GOTO_Positon();
void SetServoAnagle(Servo, float, float, float);
void JointCalculations();
String SerialInterface_Receiving();

void ReceiveCommands_RequestStatus();
void ReceiveCommands_RequestModeChange();
void ReceiveCommands_RequestModeChange();
void ReceiveCommands_RequestStateChange();
void ReceiveCommands_GotoPositon(double[]);
