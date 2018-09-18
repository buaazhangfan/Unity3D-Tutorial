using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text CountText;
    public Text winText;


    private Rigidbody rb;
    private int Count;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Count = 0;
        SetCountText();
        winText.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            Count = Count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "VR Rock: " + Count.ToString();
        if (Count >= 12)
        {
            winText.text = "You Win!";
        }

    }
}
