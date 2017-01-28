using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	Text t;
	int H;
	// Use this for initialization
	void Start () {
		//Health = GameObject.FindObjectOfType<Control>();
		t = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		H= (int)GameObject.FindObjectOfType<Control>().health;
		t.text = "Health: " + H;
	}
}
