using UnityEngine;
using System.Collections;

public class SpellObjectScript : MonoBehaviour {

	public Shader shaderToApply;
	public Vector3 dir;
	public float speed;
	ParticleSystem spellSystem;
	public int spellType;

	// Use this for initialization
	void Start () {
		spellSystem = GetComponent<ParticleSystem> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		spellSystem.startColor = new Color (Random.Range (0, 2), Random.Range (0, 2), Random.Range (0, 2), 1);

		//dir = target - transform.position;
		
		GetComponent<Rigidbody> ().velocity = dir * speed;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag != "Player"){
			col.gameObject.GetComponent<Renderer>().material.shader = shaderToApply;
			col.gameObject.AddComponent<ShaderControlSpellScript>();
			SpellUIManager.instance.manager.DoSpell(spellType,col.gameObject);
			Destroy(gameObject);
		}
	}


}
