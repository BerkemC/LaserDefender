using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GetScore : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Text t = GetComponent<Text>();
		t.text = "Your Score: "+ Score.scoreNumber;
		Score.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
