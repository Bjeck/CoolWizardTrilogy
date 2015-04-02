using UnityEngine;
using System.Collections;

public partial class SpellManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoSpell(string name, GameObject objectToHit){

		switch (name) 
		{
		case "FireBall":
			FireBall(objectToHit);
			break;
		case "FreezeBlast":
			FreezeBlast(objectToHit);
			break;
			//SOMETHING ELSE
		case "GiantBomb":
			GiantBomb(objectToHit);
			break;
		case "TransformObject":
			TransformObject(objectToHit);
			break;
		case "RotateObject":
			RotateObject(objectToHit);
			break;
		case "ScaleObject":
			ScaleObject(objectToHit);
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
			objectToHit.GetComponent<SpriteRenderer> ().material.color = new Color (0f, 0f, 1f, 1f);
		} else {
			objectToHit.GetComponent<Renderer>().material.color = new Color (0f, 0f, 1f, 1f);
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
		int objectChooser = Random.Range (0, 4); 
		GameObject objectToSpawn = new GameObject();
		Vector3 pos = objectToHit.transform.position;
		switch (objectChooser) {
		case 0:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Cube_small",typeof(GameObject)));
			break;
		case 1:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Enemy",typeof(GameObject)));
			pos.y = 1;
			break;
		case 2:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Card_Pickupable",typeof(GameObject)));
			pos.y = 1;
			break;
		case 3:
			objectToSpawn = (GameObject)Instantiate(Resources.Load("Cube_large",typeof(GameObject)));
			break;
		}
		objectToSpawn.transform.position = pos;
		Destroy (objectToHit);
	}

	void RotateObject(GameObject objectToHit){
		if(objectToHit.tag != "Enemy"){
			objectToHit.transform.Rotate (Random.Range (0, 360f), Random.Range (0, 360f), Random.Range (0, 360f));
		}
	}

	void ScaleObject(GameObject objectToHit){
		objectToHit.transform.localScale = new Vector3 (Random.Range (0.4f, 1.9f), Random.Range (0.4f, 1.9f), Random.Range (0.4f, 1.9f));
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

