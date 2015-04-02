using UnityEngine;
using System.Collections;

public class Card_Pickupable : MonoBehaviour {

	public float rotationSpeed = 2f;
	public string spellName = "FireBall";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0 , Time.deltaTime * rotationSpeed));
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {

			//ADD CARD INSERT SCRIPT HERE
			SpellUIManager.instance.manager.FoundNewCard(spellName);
			Destroy(this.gameObject);
		}
	}


}
