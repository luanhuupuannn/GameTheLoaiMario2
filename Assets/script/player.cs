using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public GameObject laze;
    public float move1;
    int speed = 6;
    Animator animator;
    private float jumpForce = 400f;
    public TextMeshProUGUI score;
    public int coin;
    public GameObject over;

  bool jump;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // đây là laze học thêm 
      //  RaycastHit2D hit = Physics2D.Raycast(laze.transform.position, Vector2.down);
       // Debug.DrawRay(laze.transform.position, Vector2.down * hit.distance, Color.red);
        /// hit.distance
        /// 


        //di chuyen trai phai
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move1 = -1;

            Vector3 flip = transform.localScale; //xuay ảnh
            flip.x = -4.030487f;
            transform.localScale = flip;
            animator.SetBool("run", true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move1 = 1;
            //xuay hoạt ảnh 
            Vector3 flip = transform.localScale;
            flip.x = 4.030487f;
            transform.localScale = flip;
            animator.SetBool("run", true);

        }
        else
        {
            // không nhấn thì là 0 thì không chạy run
            move1 = 0;
            animator.SetBool("run", false);

        }
        transform.Translate(Vector3.right * speed * move1 * Time.deltaTime);
        // Jump handling
        // if (hit.collider != null && hit.collider.tag == "san" && hit.distance == 0f && Input.GetKeyDown(KeyCode.Space))
        // {
        // Add an upward force to the player for jumping
        //     GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        //   animator.SetTrigger("jump");
        // }


        if (Input.GetKey(KeyCode.Space) && jump)
        {
            
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
            jump = false;
            
        }
      
         
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "san")
        {
            jump = true;
        }
        if (collision.gameObject.tag == "coin")
        {
            coin++;
            score.text = "X" + coin;
        }
        if (collision.gameObject.tag == "enemy")
        {
            over.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "san")
        {
            jump = false;
        }
    }
}
