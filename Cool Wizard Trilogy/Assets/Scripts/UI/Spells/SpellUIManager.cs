using UnityEngine;
using System.Collections;

public class SpellUIManager : MonoBehaviour {

    private static SpellUIManager _instance;

    public static SpellUIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SpellUIManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

	void Start () {
	    
	}
	
	void Update () {
	    
	}
}