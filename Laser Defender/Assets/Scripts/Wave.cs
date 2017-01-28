using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Wave : MonoBehaviour {
	private Spawner wave;
	Text t;
	int waveNumber;
	// Use this for initialization
	void Start () {
		wave = GameObject.FindObjectOfType<Spawner>();
		t=GetComponent<Text>();



	}
	
	// Update is called once per frame
	void Update () {
		waveNumber= wave.counter +1;
		t.text ="Wave: "+ waveNumber;
	}
}
