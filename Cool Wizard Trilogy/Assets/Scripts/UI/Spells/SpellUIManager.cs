using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpellUIManager : MonoBehaviour {

    private static SpellUIManager _instance;
    public RectTransform spellPanel;
    public GameObject cardPrefab;
    public float cardWidthPct = 5;
    public Vector2 cardStartPct = new Vector2(5f, 5f);
    public float cardTtWidthPct = 10;
    public float raiseSelCardPct = 1;
	public float cardWdtHgtRat = 1.5f;
	public bool justClicked = false;
	
	public SpellManager manager;

    private Dictionary<string, GameObject> cards = new Dictionary<string, GameObject>();
	public Dictionary<KeyCode, Card> hotkeys = new Dictionary<KeyCode, Card>();


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

		manager.MakeAllCards();
        manager.SetYourFirstCards();

    }


    void Update()
    {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if(cards.Count > 0){
				manager.ToggleSpell((cards.Keys.ToList())[0]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if(cards.Count > 1){
				manager.ToggleSpell((cards.Keys.ToList())[1]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if(cards.Count > 2){
				manager.ToggleSpell((cards.Keys.ToList())[2]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if(cards.Count > 3){
				manager.ToggleSpell((cards.Keys.ToList())[3]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			if(cards.Count > 4){
				manager.ToggleSpell((cards.Keys.ToList())[4]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			if(cards.Count > 5){
				manager.ToggleSpell((cards.Keys.ToList())[5]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			if(cards.Count > 6){
				manager.ToggleSpell((cards.Keys.ToList())[6]);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			if(cards.Count > 7){
				manager.ToggleSpell((cards.Keys.ToList())[7]);
			}
		}

        UpdateCardsUI();
		justClicked = false;
    }


    public void UpdateCardsUI()
    {
        for(int i = cards.Count -1; i >= 0; i--)
        {
            string cardName = (cards.Keys.ToArray())[i];

            if(!manager.yourCards.Keys.Contains(cardName))
            {
                Destroy(cards[cardName]);
                cards.Remove(cardName);
                i--;
            }
        }
		List<string> cardNames = new List<string> ();
		foreach (Card c in manager.yourCards.Values.ToList ()) {
			cardNames.Add(c.name);
		}


		foreach (string cardName in cardNames)
        {
            if(!cards.ContainsKey(cardName))
            {
                GameObject card = Instantiate(cardPrefab);

                RectTransform cardTran = card.GetComponent<RectTransform>();
                cardTran.SetParent(spellPanel);

                card.GetComponent<Image>().sprite = manager.yourCards[cardName].image;

                Button cardBut = card.GetComponent<Button>();

                switch(cardName){
					case "FireBall":
						cardBut.onClick.AddListener(()=> { manager.ToggleSpell("FireBall"); });
                        break;
					case "FreezeBlast":
						cardBut.onClick.AddListener(()=> { manager.ToggleSpell("FreezeBlast"); });
                        break;
					case "GiantBomb":
						cardBut.onClick.AddListener(()=> { manager.ToggleSpell("GiantBomb"); });
                        break;
					case "TransformObject":
						cardBut.onClick.AddListener(()=> { manager.ToggleSpell("TransformObject"); });
                        break;
					case "RotateObject":
						cardBut.onClick.AddListener(()=> { manager.ToggleSpell("RotateObject"); });
						break;
					case "ScaleObject":
						cardBut.onClick.AddListener(()=> { manager.ToggleSpell("ScaleObject"); });
						break;
                }

                cards.Add(cardName, card);
            }
        }
                                               
        float cardWidth = ( Screen.width / 100 ) * cardWidthPct;
        float cardPosIt = ((Screen.width / 100) * cardTtWidthPct) / cards.Count;
        float selCardRaise = (Screen.height / 100) * raiseSelCardPct;
        Vector2 cardMargin = new Vector2((Screen.width / 100) * cardStartPct.x, (Screen.height / 100) * cardStartPct.y);

        int q = 0;
        foreach(string cardName in cards.Keys)
        {
            RectTransform cardTran = cards[cardName].GetComponent<RectTransform>();

            float cardY = cardMargin.y;

            if(manager.chosenSpell != null && cardName == manager.chosenSpell.name)
            {
                cardY += selCardRaise;
            }

            cardTran.position = new Vector3((cardPosIt * q) + cardMargin.x, cardY, 0);
            cardTran.sizeDelta = new Vector2(cardWidth, cardWidth * cardWdtHgtRat);

            q++;
        }
    }


    public Card cardClicked()
    {
		justClicked = true;
        if(manager.chosenSpell != null)
        {
            return manager.chosenSpell;
        }

        return null;
    }
}