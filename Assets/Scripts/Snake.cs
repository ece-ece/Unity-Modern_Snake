using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 1f;
    //public GameObject food;
    public Transform tailPrefab;
    Vector3 temp;

    private List<Transform> segments;
    bool isMoveDown=true;
    bool isMoveUp=true;
    bool isMoveRight=true;
    bool isMoveLeft=true;

    public bool isEat;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        segments = new List<Transform>();
        segments.Add(this.transform);
        //DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow)&&isMoveUp==true)
        {
            rb.velocity = new Vector2(0, speed);
            
            
            isMoveDown = false;
            isMoveRight = true;
            isMoveLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)&&isMoveDown==true)
        {
            rb.velocity = new Vector2(0, -speed);
            
            isMoveUp = false;
            isMoveRight = true;
            isMoveLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)&&isMoveRight==true)
        {
            rb.velocity = new Vector2(speed, 0);
            
            isMoveDown = true;
            isMoveUp = true;
            isMoveLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&isMoveLeft==true)
        {
            rb.velocity = new Vector2(-speed, 0);
            
            isMoveDown = true;
            isMoveUp = true;
            isMoveRight = false;
        }
    }
    private void FixedUpdate()
    {
        for (int i = segments.Count-1; i > 0; i--)
        {
            segments[i].position = Vector3.Lerp(segments[i].transform.position, segments[i - 1].position, Time.deltaTime *11);
           // segments[i].position = segments[i - 1].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            
            Debug.Log("Yedi");
            isEat = true;
            
            //DestroyObject(food);
            Grow();
        }
    }
   
    void Grow()
    {
        /*
        temp = transform.localScale;
        temp.y += 0.3f;
        transform.localScale = temp;
        */


        //temp = transform.position;

        //GameObject newSnake = Instantiate(snake, new Vector3(temp.x, (float)(temp.y - 0.4), temp.z), Quaternion.identity);
        Transform segment = Instantiate(this.tailPrefab);
        segment.position = segments[segments.Count - 1].position;
        
        segments.Add(segment);
    }

    
}
