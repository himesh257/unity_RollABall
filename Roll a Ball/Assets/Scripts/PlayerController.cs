using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Text WinText;
	public Text point;
	public Text countText;
	public float speed;
	private Rigidbody rb;
	private int counter;
	private int points;
	private string one;
	private string two;
	private string timer;
	private string[] lenOne;
	private string[] lenTwo;

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
    	one = GameObject.Find("Count Text").GetComponent<Text>().text;
    	timer = GameObject.Find("Timer").GetComponent<Text>().text;
    	lenOne = one.Split(char.Parse(":"));
    	Debug.Log(lenOne[1]);
    	two = GameObject.Find("Count Text (1)").GetComponent<Text>().text;
    	lenTwo = two.Split(char.Parse(":"));
    	float moverHorizontal = Input.GetAxis("HorizontalP1");
    	float moveVertical = Input.GetAxis("VerticalP1");
    	float jump;

    	if(Input.GetKeyDown(KeyCode.Space) && rb.transform.position.y <= 1f){
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
    		SetText();
    	}
    }

    void SetText(){
    	countText.text = "Count (A): " + counter.ToString();
    	point.text = "Points (A): " + points.ToString();
    	if(counter >= 12 && (int.Parse(lenOne[1])) > (int.Parse(lenTwo[1])) && (int.Parse(timer)) != 0){
    		WinText.text = "Player A wins!!";
    	} else if (counter >= 12 && (int.Parse(lenOne[1])) < (int.Parse(lenTwo[1])) && (int.Parse(timer)) != 0){
    		WinText.text = "Player B wins!!";
    	} else if ((int.Parse(lenOne[1])) < (int.Parse(lenTwo[1])) && (int.Parse(timer)) == 0){
    		WinText.text = "Player B wins!!";
    	} else if ((int.Parse(lenOne[1])) > (int.Parse(lenTwo[1])) && (int.Parse(timer)) == 0){
    		rb.AddForce (0.0f,0.0f,0.0f);
    		WinText.text = "Player A wins!!";
    	} 
    }
}
