using UnityEngine;
using System.Collections;

public class MusicPlayerLose : MonoBehaviour {
	MusicPlayer player;
	void Awake(){
		player = GameObject.FindObjectOfType<MusicPlayer>();
		Destroy(player.gameObject);
		GetComponent<AudioSource>().Play();
	}
}
