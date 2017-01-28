using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {
	public  float health =300f;
	public GameObject laser;
	public float speed = 5f;
	public float frequency = 0.6f;
	public int ScoreValue=200;
	//private Score score;
	public AudioClip explosion;

	void Start(){
		//score = GameObject.Find("scoreNumber").GetComponent<Score>();
		//score = GameObject.FindObjectOfType<Score>();

	}
	void OnCollisionEnter2D(Collision2D col){
		float damageShip = col.gameObject.GetComponent<BeamLaser>().damage;
		if((health - damageShip )<= 0f){
			Destroy(gameObject);
			Score.scoreNumber+=ScoreValue;
			AudioSource.PlayClipAtPoint(explosion,transform.position);
		}
		health -= damageShip;
		Destroy(col.gameObject);
	}

	void Update(){
		float probability = Time.deltaTime * frequency ;
		if (Random.value < probability) Fire();

	}

	void Fire(){
		Vector3 startPosition = transform.position + new Vector3( 0f,-1f,0f);
		GameObject beam =Instantiate(laser,startPosition,Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,-speed);
		GetComponent<AudioSource>().Play();
	}
}
