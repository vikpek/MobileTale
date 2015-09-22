using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour {

	float heightTextBox = 30;
	float yTop = 280;
	float yLastPosition = 0;

	GameObject instanceTextBox;
	GameObject textCanvas;


	void Start () {
	
		textCanvas = GameObject.FindGameObjectWithTag("TextCanvas");
		yTop = textCanvas.transform.position.y;
		yLastPosition = yTop;

		InvokeRepeating("Tick", 0f, 1f);
	}

	void Tick(){
		InstantiateTextBox(GetComponent<Statemachine>().ProcessNextState());
	}

	void InstantiateTextBox(string value){
		if(value.Length>0){
			instanceTextBox = Instantiate((GameObject) Resources.Load("TextBox"));		

			instanceTextBox.GetComponent<Text>().text = value;
		
		
			instanceTextBox.transform.SetParent(textCanvas.transform);

			instanceTextBox.transform.localPosition = new Vector3(0,yLastPosition,0);
			yLastPosition -=heightTextBox;
		}
	}
}
