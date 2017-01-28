using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public  class Score : MonoBehaviour {
	private Spawner spawn ;
	private Text score;
	public static int scoreNumber=0;

	public void UpdateScore(int points){
		 scoreNumber += points;
		
	}
	public static void Reset(){
		scoreNumber=0;
	}

	void Update(){
		score.text="Score: "+ scoreNumber;
	}
	void Start(){
		Reset();
		score = GetComponent<Text>();
	}
}
