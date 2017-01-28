using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float width = 16f;
	public float height = 12f;
    private double rightMost = 16.0-(12.7/2);
    private double leftMost = (12.7/2);
	private bool checkDirection=false;
	public float speed=5f;
	public GameObject enemy;
	private LevelManager levelManager;
	public int counter=0;

	// Use this for initialization
	void Start () {
		//To find min and max values of x coordinate to restrict by using camera
		//float distance=transform.position.z-Camera.main.transform.position.z;
		//float Vector3 leftmost= Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		//float Vector3 rightmost=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		//Then the leftmost is min and rightmost is the max number for restriction.
		levelManager= GameObject.FindObjectOfType<LevelManager>();
		SpawnUntilFull();

	}
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height,0f));
	}
	// Update is called once per frame
	void Update () {
		if(IsAllDead()){
			if(counter!=9)
			{SpawnUntilFull();
			counter++;}
			else{
				Application.LoadLevel("Win");
			}
		}

		if(!checkDirection){
			transform.position += Vector3.right*speed*Time.deltaTime;
			if(transform.position.x >= rightMost) checkDirection=true;
		}
		else if (checkDirection){
			transform.position += Vector3.left*speed*Time.deltaTime;
			if(transform.position.x <= leftMost) checkDirection=false;
		}
	}

	bool IsAllDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0) return false;
		}
		return true;
	}
	void SpawnEnemies(){
		
		foreach(Transform child in transform){
			
				//GameObject Enemy = Instantiate(enemy,child.position,Quaternion.identity) as GameObject;
				//Enemy.transform.parent = child;
				SpawnUntilFull();
			}
		}
	
	void SpawnUntilFull(){
		Transform freePos = NextFreePos();
		if(freePos){
			GameObject Enemy = Instantiate(enemy,freePos.position,Quaternion.identity) as GameObject;
			Enemy.transform.parent = freePos;
		}
		if(NextFreePos()) Invoke("SpawnUntilFull",0.5f);

	}
	Transform NextFreePos(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0) return childPositionGameObject;
		}
		return null;
	}

	public bool IsThereAnyDeath(){
		foreach(Transform childTransform in transform){
			if(childTransform.childCount == 0 ) return true;
		}
		return false;
	}
}
