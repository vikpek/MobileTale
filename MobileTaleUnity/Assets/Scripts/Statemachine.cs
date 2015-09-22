using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Statemachine
/// 
/// Explanation:
/// 	SxPy, <text> 			- ID for story state. Meaning Story x Part y.
/// 	C, <ID1_ID2, ..., IDn>	- Choice containing possible options for next step. Can be more than two.
/// 	D, <var>:<int>			- Decision containing a new defined variable and according value. 
/// 	W, <duration in sec>	- Wait for a longer period of time before continuing to next step: [ Tayloer is busy ]
/// 	G, <ID>					- Go to specific state. For instance load game or reset game. 
/// 
/// </summary>

public class Statemachine : MonoBehaviour {

	List<KeyValuePair<string, string>> states;

	public const string STATE_ID = "S";
	public const string STATE_CHOICE = "C";
	public const string STATE_DECISION = "D";
	public const string STATE_WAIT = "W";
	public const string STATE_GOTO = "G";

	int currentState = 0;

	void Start () {
		InitializeStates();
	}


	void InitializeStates ()
	{
		// TODO get intel from csv
		states = new List<KeyValuePair<string, string>>();
		states.Add(new KeyValuePair<string, string>("S1P1", "lorem"));
		states.Add(new KeyValuePair<string, string>("S1P2", "ipsum"));
		states.Add(new KeyValuePair<string, string>("S2P1", "dolor"));
		states.Add(new KeyValuePair<string, string>("S2P2", "sit"));
		states.Add(new KeyValuePair<string, string>("C", "S3P1, S2P2"));
		states.Add(new KeyValuePair<string, string>("W", "10"));
		states.Add(new KeyValuePair<string, string>("G", "S1P1"));
		states.Add(new KeyValuePair<string, string>("S3P2", "asdfgsdfg"));
		states.Add(new KeyValuePair<string, string>("S4P2", "ertyerty"));
		states.Add(new KeyValuePair<string, string>("S5P2", "zcxvzcxv"));
	}

	public string ProcessNextState(){
		return ProcessState();
	}

	string ProcessState(){

		if(IsStateID(states[currentState].Key)){
			print ("print story " + states[currentState].Value);
			currentState++;
			return states[currentState].Value;
		}

		if(IsStateChoice(states[currentState].Key)){
			print("print choice " + states[currentState].Value);
			int c = 0;
			currentState = FindStateForChoice(states[currentState].Value, c);
		}

		if(IsStateDecision(states[currentState].Key)){
			
		}

		if(IsStateWait(states[currentState].Key)){
			
		}

		if(IsStateGoto(states[currentState].Key)){
			
		}
		return "";
	}

	int FindStateForChoice(string choices, int choice){
//		choices.Replace(" ", "");
//		choices.Split(","); 
		return 0;
	}

	bool IsStateID(string value){
		return value.StartsWith (STATE_ID);
	}

	bool IsStateChoice(string value){
		return value.StartsWith(STATE_CHOICE);
	}

	bool IsStateDecision(string value){
		return value.StartsWith(STATE_DECISION);
	}

	bool IsStateWait(string value){
		return value.StartsWith(STATE_WAIT);
	}

	bool IsStateGoto(string value){
		return value.StartsWith(STATE_GOTO);
	}
}
