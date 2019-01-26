using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public float speed;
    private Rigidbody rb;
    //size of ball is tracked
    float size = 1;
    //the increment the size goes up as objects are collected
    float size_up = 0.01f;
    float size_down = -0.01f;

    //UI
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }

    // Grab everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Increases size of ball
            transform.localScale += new Vector3(size_up, size_up, size_up);
            size += size_up;
            other.enabled = false;

            //pick up object becomes child of ball
            other.transform.SetParent(this.transform);
            count += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Spike"))
        {
            other.gameObject.SetActive(false);
            //Decreases size of ball
            transform.localScale += new Vector3(size_down, size_down, size_down);
            size -= size_down;
            //Testing for Reaction by seeing if score decreases
            count -= 1;
            SetCountText();
        }         
    }

    void SetCountText()
    {
        //using TMPro because it's much nicer looking
        countText.SetText("Score: " + count.ToString());

        //Win Condition Text
        if (count >= 16)
        {
            winText.SetText("You Won!");
        }
    }

}
