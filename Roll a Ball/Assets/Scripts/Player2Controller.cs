using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour
{
	public Text point;
	public Text countText;
	public float speed;
	private Rigidbody rb;
	private int counter;
	private int points;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    	counter = 0;
    	points = 0;
    	SetText();
    }

    void FixedUpdate()
    {
    	float moverHorizontal = Input.GetAxis("HorizontalP2");
    	float moveVertical = Input.GetAxis("VerticalP2");
    	float jump;

    	if(Input.GetKeyDown(KeyCode.Z) && rb.transform.position.y <= 1f){
    		jump = 70.0f;
    	} else {
    		jump = 0.0f;
    	}
    	
    	Vector3 movement = new Vector3 (moverHorizontal, jump, moveVertical);
    	rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("Pick Up")){
    		other.gameObject.SetActive(false);
    		counter = counter + 1;
    		points = points + 10;
    		SetText();
    	} 
    } 

    void OnCollisionEnter (Collision col){
    	if(col.gameObject.name == "Walls (1)" || col.gameObject.name == "Walls (2)" || col.gameObject.name == "Walls (3)" || col.gameObject.name == "Walls (4)"){
    		points = points - 5;
    		//counter = counter;
    		SetText();
    	}
    }

    void SetText(){
    	countText.text = "Count (B): " + counter.ToString();
    	point.text = "Points (B): " + points.ToString();
    }
}
