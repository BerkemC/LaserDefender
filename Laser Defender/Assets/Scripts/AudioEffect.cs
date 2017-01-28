using UnityEngine;
using System.Collections;

public class AudioEffect : MonoBehaviour {
	static AudioEffect instance = null;
	void Awake(){
		if(instance) Destroy(gameObject);
		else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}

	}
	public void playIt(AudioSource audio){
		audio.Play();
	}
}
