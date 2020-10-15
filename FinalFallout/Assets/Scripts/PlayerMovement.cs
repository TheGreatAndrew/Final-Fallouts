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
    }
}
