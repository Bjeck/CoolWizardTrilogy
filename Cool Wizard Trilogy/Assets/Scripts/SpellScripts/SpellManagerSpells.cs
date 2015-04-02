﻿using UnityEngine;
using System.Collections;

public partial class SpellManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoSpell(int nr, GameObject objectToHit){
		Debug.Log ("DOING SPELL");

		switch (nr) 
		{
		case 0:
			FireBall(objectToHit);
			break;
		case 1:
			FreezeBlast(objectToHit);
			break;
			//SOMETHING ELSE
		case 2:
			GiantBomb(objectToHit);
			break;
		case 3:
			TransformObject(objectToHit);
			break;
		
		default:
			Debug.Log("no spell with that number");
			break;
			//do nothing
		}
	}


	void FireBall(GameObject objectToHit){
		//DO FIREBALL
		GameObject objectToSpawn = (GameObject)Instantiate(Resources.Load("Fire",typeof(GameObject)));
		Vector3 pos = objectToHit.transform.position;
		pos.y += objectToHit.transform.localScale.y;
		objectToSpawn.transform.position = pos;
	}

	void FreezeBlast(GameObject objectToHit){

		if (objectToHit.GetComponent<Rigidbody> () != null) {
			objectToHit.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}
		if (objectToHit.GetComponent<SpriteRenderer> () != null) {
			objectToHit.GetComponent<SpriteRenderer> ().material.color = new Color(0f,0f,1f,1f);
		}
		//freeze
	}

	void GiantBomb(GameObject objectToHit){
		//Destroy object
		//DROP A BOMB ON IT
		Destroy (objectToHit); 
	}


	void TransformObject(GameObject objectToHit){
		//transform into somehting else
		int objectChooser = Random.Range (0, 5);
		GameObject objectToSpawn = new GameObject();
		Vector3 pos = objectToHit.transform.position;
		switch (objectChooser) {
		case 0:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("SpellObject",typeof(GameObject)));
			pos.y = -1;
			break;
		case 1:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Cube_small",typeof(GameObject)));
			break;
		case 2:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Enemy",typeof(GameObject)));
			pos.y = -1;
			break;
		case 3:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Card_Pickupable",typeof(GameObject)));
			pos.y = -1;
			break;
		}
		objectToSpawn.transform.position = pos;
		Destroy (objectToHit);
	}

	void BlackHole(GameObject objectToHit){


	}

	/*
	 * 
	void DrewsSpecial(GameObject objectToHit){
		//grenade
	}

	void ChinaDontCare(GameObject objectToHit){
		//flips something upside down
	}*/

}

