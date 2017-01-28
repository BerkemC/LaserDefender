using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	private float speed=12.0f;
	public float projectileSpeed=5f;
	public GameObject projectile;
	public float fireRate=0.2f;
	private LevelManager levelManager;
	public float health=400f;
	//private Score score;
	public AudioClip explosion;


	// Use this for initialization
	void Start () {
		//To find min and max values of x coordinate to restrict by using camera
		//float distance=transform.position.z-Camera.main.transform.position.z;
		//float Vector3 leftmost= Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		//float Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		//Then the leftmost is min and rightmost is the max number for restriction.
		levelManager=GameObject.FindObjectOfType<LevelManager>();
		//score = GameObject.Find("scoreNumber").GetComponent<Score>(); 
		//score = GameObject.FindObjectOfType<Score>();
	}
	
	// Update is called once per frame
	void Update () {

		//Location update according to keys.
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left *speed*Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right*speed*Time.deltaTime;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire",0.000001f,fireRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}

		//Player restricts
		float newPos=Mathf.Clamp(transform.position.x,0.75f,15.25f);
		transform.position=new Vector3(newPos,transform.position.y,transform.position.z);
	}
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3 (0f,1f,0f);
		GameObject beam = Instantiate(projectile,startPosition,Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,projectileSpeed);
		GetComponent<AudioSource>().Play();
	}

	void OnCollisionEnter2D(Collision2D col){
		float damageTaken = col.gameObject.GetComponent<BeamLaser>().damage;
		if(health - damageTaken <= 0f){
			Destroy(gameObject);
			levelManager.LoadLevel("Lose");
			AudioSource.PlayClipAtPoint(explosion,transform.position);
		}
		Destroy(col.gameObject);
		health -= damageTaken;
	}
}
