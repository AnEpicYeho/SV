using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, Damageable {

	private float healt = 100;
	public float armor;
	private NavMeshAgent nav;
	public GameObject patrolPoints;
	private int patrolPointIndex;
	private GameObject player;

	private bool playerOnSight;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		patrolPointIndex = 0;
		player = GameObject.FindObjectOfType<CharacterController> ().gameObject;
	}

	private void setNextPatrolPoint(){
		if (Vector3.Distance (patrolPoints.transform.GetChild(patrolPointIndex).position, transform.position)<0.5) {
			if (patrolPointIndex < patrolPoints.transform.childCount) {
				patrolPointIndex++;
			} else {
				patrolPointIndex = 0;
			}

		}
			
	}


	private void patrol(){
		nav.SetDestination (patrolPoints.transform.GetChild(patrolPointIndex).position);
	}

	private void follow(){
		nav.SetDestination (player.transform.position);
	}

	public void receibeDamange (float damange){
		damange -= armor;
		healt -= damange;
		if(healt <= 0){
			Destroy (this.gameObject);
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		if(playerOnSight){
			follow ();
		}else{
			patrol ();
		}
	}
}
