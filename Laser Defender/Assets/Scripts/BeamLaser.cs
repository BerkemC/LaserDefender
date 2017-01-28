using UnityEngine;
using System.Collections;

public class BeamLaser : MonoBehaviour {
	public float damage;
	 void Start(){
		damage = Random.Range(50f,100f);
	 }
}
