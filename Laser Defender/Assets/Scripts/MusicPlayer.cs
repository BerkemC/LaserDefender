using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public static MusicPlayer instance=null;
	// Use this for initialization
	void Awake(){
		if(instance){
			Destroy(gameObject);
		}
		else{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
