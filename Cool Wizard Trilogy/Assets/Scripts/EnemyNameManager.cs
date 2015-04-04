using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyNameManager : MonoBehaviour {

	List<string> names = new List<string>();


	// Use this for initialization
	void Start () {
		FillNameList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (names.Count <= 0) {
			FillNameList ();
		}
	}

	public string GetName(){
		int choo = Random.Range (0, names.Count);
		if (choo == names.Count) {
			choo -= 1;
		}
		string ret = names [choo];
		names.Remove (ret);

		if (names.Count == 0) {
			FillNameList();
		}
		return ret;
	}


	void FillNameList(){
		names.Add ("Jeff");
		names.Add ("Dan");
		names.Add ("Drew");
		names.Add ("Danny O'Dwyer");
		names.Add ("Brad");
		names.Add ("Vinny");
		names.Add ("Alex");
		names.Add ("Helicopter");
		names.Add ("Revolver Ocelot");
		names.Add ("Gamebomb.ru");
		names.Add ("Mario Party");
		names.Add ("RUN GFB");
		names.Add ("Dave Lang");
		names.Add ("Mike Tyson");
		names.Add ("Yoshi");
		names.Add ("Mary Kish");
		names.Add ("Brad Muir");
		names.Add ("Rorie");
		names.Add ("Jason");
		names.Add ("John T. Drake");
		names.Add ("Eric Pope");
		names.Add ("Patrick Klepek");
	}


}
