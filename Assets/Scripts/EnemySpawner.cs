using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject basicEnemy;

	// Use this for initialization
	void Start (){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (basicEnemy, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
