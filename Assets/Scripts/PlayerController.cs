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
    float size_up = 0.1f;
    float size_down = -0.1f;

    //UI
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    private float bonus;
    public GameObject exitMenu;

    //Jump
    private float cooldownTime = 2;
    private float nextJumpTime = 0;
    public float jumpPower;

    //Sounds
    public AudioClip fruitSound;
    public AudioClip spikeSound;

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
        if (Time.time > nextJumpTime)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
                nextJumpTime = Time.time + cooldownTime;
                cooldownTime = 1.0f;
            }
        }
    }

    // Grab everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Sound Effect
            this.GetComponent<AudioSource>().PlayOneShot(fruitSound);

            //Increases size of ball
            //transform.localScale += new Vector3(size_up, size_up, size_up)*2f;
            transform.localScale = transform.localScale * (1f + size_up);
            size += size_up;
            other.gameObject.GetComponent<Rotator>().enabled = false;
            other.enabled = false;

            //Debug.Log(transform.localScale.ToString());

            //pick up object becomes child of ball
            other.transform.SetParent(this.transform);
            count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Spike") && size!= 0)
        {
            //Sound Effect
            this.GetComponent<AudioSource>().PlayOneShot(spikeSound);

            other.gameObject.SetActive(false);
            //Decreases size of ball
            //transform.localScale += new Vector3(size_down, size_down, size_down);
            transform.localScale = transform.localScale * (1f+size_down);
            size -= size_down;
            //Testing for Reaction by seeing if score decreases
            Debug.Log("going down a size");

        }  
        else if (other.gameObject.CompareTag("WinTrigger"))
        {
            WinGame();
        }
    }

    void SetCountText()
    {
        //using TMPro because it's much nicer looking
        countText.SetText("Fruit Collected: " + count.ToString());
    }

    void WinGame()
    {
        winText.SetText(" Congratulations! You've Escaped the Basket!");
        exitMenu.SetActive(true);
    }
}
