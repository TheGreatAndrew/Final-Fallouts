using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerMovement instance;

    private Rigidbody2D rb;
    public float moveH, moveV;
    [SerializeField] private float moveSpeed = 2.0f;

    public string levelPW;

    public string biomeTag;
    //Create a singleton pattern to have 
    //access to the movement from other scenes

    //For Random Encounter Generator
   private RandomEncounter rndEncScript;

    // FOR MENU
   	public Interactable focus;	// Our current focus: Item, Enemy etc.
    // PlayerMovement motor;

    [SerializeField] GameController gameCtrl;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        biomeTag = "Overworld";

    }
    void Start()
    {

        gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody2D>();
        rndEncScript = gameObject.GetComponent<RandomEncounter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("BattleScene") == 1 && PlayerPrefs.GetInt("BattleWon") == 1){

            PlayerPrefs.DeleteKey("BattleScene");
            PlayerPrefs.DeleteKey("BattleWon");

            // 0 -> 10 potions
            // 5 -> 15 good equipment
            // 15 -> 25 normal equipment
            int random = Random.Range(0,25);
            GameObject item;
            switch(random){
                case 0 : item = Instantiate(Resources.Load("Consumables/HealthPotion", typeof(GameObject))) as GameObject; break;
                case 1 : item = Instantiate(Resources.Load("Consumables/AttackPotion", typeof(GameObject))) as GameObject; break;
                case 2 : item = Instantiate(Resources.Load("Consumables/DefensePotion", typeof(GameObject))) as GameObject; break;
                
                case 5 : item = Instantiate(Resources.Load("Equipments/CursedArmor", typeof(GameObject))) as GameObject; break;
                case 6 : item = Instantiate(Resources.Load("Equipments/CursedGlove", typeof(GameObject))) as GameObject; break;
                case 7 : item = Instantiate(Resources.Load("Equipments/CursedHelmet", typeof(GameObject))) as GameObject; break;
                case 8 : item = Instantiate(Resources.Load("Equipments/CursedShoes", typeof(GameObject))) as GameObject; break;
                case 9 : item = Instantiate(Resources.Load("Equipments/CursedSword", typeof(GameObject))) as GameObject; break;
                case 10 : item = Instantiate(Resources.Load("Equipments/DiamonHelmet", typeof(GameObject))) as GameObject; break;

                case 15 : item = Instantiate(Resources.Load("Equipments/NormalClothes", typeof(GameObject))) as GameObject; break;
                case 16 : item = Instantiate(Resources.Load("Equipments/NormalShield", typeof(GameObject))) as GameObject; break;
                case 17 : item = Instantiate(Resources.Load("Equipments/NormalShoes", typeof(GameObject))) as GameObject; break;
                case 18 : item = Instantiate(Resources.Load("Equipments/NormalSword", typeof(GameObject))) as GameObject; break;

                default : item = null; break;
            }
            if(item != null){
                Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
                Instantiate(item, playerPos + new Vector3(1, 0, 0), Quaternion.identity );
            }
        }

        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);

        //if player has moved check if in an encounter
        if(moveH != 0 || moveV != 0)
        {
            rndEncScript.isEncounter();
        }
    }

    public void StopPlayer()
    {
        rb.velocity = Vector2.zero;
    }

    // when touch items
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        Interactable interactable = other.GetComponent<Collider2D>().GetComponent<Interactable>();
        if (interactable != null){
			SetFocus(interactable);
		}

        if (gameCtrl == null)
            gameCtrl = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (other.name == "Merchant")
        {
            rndEncScript.setSafeZoneCurve();
            biomeTag = "safe";
            gameCtrl.MerchantShopMenu.GetComponent<MerchantInteraction>().TriggerInteraction();
        }
        if(other.name == "SafeZone")
        {
            rndEncScript.setSafeZoneCurve();
            biomeTag = "safe";
        }//everything below the line is new logic --------------
        else
        {
            rndEncScript.setOverworldCurve();
            biomeTag = other.tag;
        }
        if(other.CompareTag("QuestGiver"))
        {
            rndEncScript.setSafeZoneCurve();
            gameCtrl.QuestGiverList.GetComponent<QuestInteraction>().triggerInteraction();
        }

        if (other.CompareTag("Untagged"))
        {
            if(biomeTag == "safe")
            {
                rndEncScript.setSafeZoneCurve();
            }//everything below the line is new logic --------------
            else
            {
                rndEncScript.setOverworldCurve();
            }
        }
        
        //everything above the line is new logic --------------
        /* old logic
        if (other.tag == "Overworld")
        {
            rndEncScript.setOverworldCurve();
        }
        if(other.tag == "QuestGiver")
        {
            gameCtrl.QuestGiverList.GetComponent<QuestInteraction>().triggerInteraction();
        }*/
    }

    // FOR MENU
    void SetFocus (Interactable newFocus)
	{
		if (newFocus != focus)
		{
			if (focus != null)
				focus.OnDefocused();

			focus = newFocus;
			// motor.FollowTarget(newFocus);	// Follow the new focus
		}
		
		newFocus.OnFocused(transform);
	}

    void RemoveFocus ()
	{
		if (focus != null)
			focus.OnDefocused();

		focus = null;
		// motor.StopFollowingTarget();
	}

}
