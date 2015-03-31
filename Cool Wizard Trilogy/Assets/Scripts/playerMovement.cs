using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	Rigidbody rigbody;
	Vector3 movementVector;
	public float speed = 5f;
	public GameObject cameraObject;
	public GameObject wizardVisionObj;
	wizardVisionControlScript wvcScr;

	bool isTargeting = false;
	public GameObject targetCursor;
	Vector3 spellTarget;
	GameObject spellObject;
	public float spellSpeed;

	// Use this for initialization
	void Start () {
		rigbody = GetComponent<Rigidbody> ();
		wvcScr = wizardVisionObj.GetComponent<wizardVisionControlScript> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		movementVector.x = Input.GetAxis ("Horizontal")*speed;
		movementVector.z = Input.GetAxis ("Vertical")*speed;

		rigbody.velocity = movementVector;
	


		if (Input.GetKeyDown (KeyCode.E)) {
			isTargeting = true;
			//targetCursor.SetActive(true);
		}





		if (isTargeting) { //updates the target cursor to mouse position and color to see range.
			
			//Vector3 temp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//temp.z = -1f;
			//targetCursor.transform.position = temp;

			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f)) {
					CastSpell(hit.point);
					isTargeting = false;

				}
			}

		}



		if(Input.GetKeyDown(KeyCode.Z)){
			wvcScr.ChangeVisionState();
		}
	}

	//right now, just generic spell. include spell, probably, when we get there.
	void CastSpell(Vector3 target){
		spellObject = (GameObject)Instantiate(Resources.Load("SpellObject",typeof(GameObject)));
		spellObject.transform.position = transform.position;
		target.y = transform.position.y;
		spellObject.GetComponent<SpellObjectScript> ().dir = (target - spellObject.transform.position).normalized;
	}

}

/*
 * // Update is called once per frame
	public void Update () {
		base.Update ();
		aMan.isTargetingAbility = isTargeting;

		if (isTargeting) { //updates the target cursor to mouse position and color to see range.

			Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			temp.z = -1f;
			targetCursor.transform.position = temp;

			dist = Vector3.Distance(targetCursor.transform.position,caster.transform.position); 
			//Debug.Log(dist);
			if(dist > range){
				//Debug.Log("OUT OF RANGE");
				targetCursor.GetComponent<SpriteRenderer> ().sprite = targetCursorRed;
			}
			else {
				//Debug.Log("IN RANGE: "+targetCursorGreen);
				targetCursor.GetComponent<SpriteRenderer> ().sprite = targetCursorGreen;
			}

			if(Input.GetKeyDown(KeyCode.Escape)){
				StopTargeting();
			}
		}
*/

/*
 * Vector3 mPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f)) { //check if anything is hit.
						
						LayerMask layermaskB = (1 << 10);
						LayerMask layermaskU = (1 << 12);
						if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100f, layermaskB)) {	//check if it is a building that was clicked on

*/