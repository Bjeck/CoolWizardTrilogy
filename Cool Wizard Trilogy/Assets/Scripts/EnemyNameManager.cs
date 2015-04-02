using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyNameManager : MonoBehaviour {

	List<string> names = new List<string>();
	int i = 0;


	// Use this for initialization
	void Start () {
		names.Add ("Jeff");
		names.Add ("Dan Ryckert");
		names.Add ("Drew Scanlon");
		names.Add ("Danny O'Dwyer");
		names.Add ("Brad Shoemaker");
		names.Add ("Vinny Caravella");
		names.Add ("Alex Navarro");
		names.Add ("Helicopter");
		names.Add ("Revolver Ocelot");
		names.Add ("Gamebomb.ru");
		names.Add ("Mario Party");
		names.Add ("RUN GFB");
		names.Add ("Dave Lang");
		names.Add ("Mike Tyson");


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetName(){
		string ret = names [i];
		i++;
		return ret;
	}


}
