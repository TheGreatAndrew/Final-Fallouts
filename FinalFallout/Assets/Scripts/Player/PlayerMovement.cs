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
    //Create a singleton pattern to have 
    //access to the movement from other scenes

    //For Random Encounter Generator
   private RandomEncounter rndEncScript;

    // FOR MENU
   	public Interactable focus;	// Our current focus: Item, Enemy etc.
    // PlayerMovement motor;

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

    }
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        rndEncScript = gameObject.GetComponent<RandomEncounter>();
    }

    // Update is called once per frame
    void Update()
    {
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
