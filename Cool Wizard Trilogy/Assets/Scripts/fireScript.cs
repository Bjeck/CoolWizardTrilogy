using UnityEngine;
using System.Collections;

public class fireScript : MonoBehaviour {

	float timer = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if(timer <= 0){
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
			timer = 0.3f;
		}
	
	}
}
