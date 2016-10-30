using UnityEngine;
using System.Collections;

public class SharkMovement : MonoBehaviour {
    public Transform Player;
    public float SharkSpeed = 1f;
    public float BitingDistance = 20f;
    private bool biting = false;
    public int health = 1;
    private CharacterController character;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(Player);
        Vector3 direction = (Player.position - transform.position).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + direction * SharkSpeed * Time.deltaTime);
       // GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * SharkSpeed, ForceMode.Force);
        if(!biting && Vector3.Distance(Player.position, transform.position) < BitingDistance)
        {
            GetComponent<Animator>().Play("Bite");
            GetComponent<Rigidbody>().isKinematic = false;
            biting = true;
        }
	}


    public void Hit()
    {
        health--;
        if(health < 1)
        {
            Die();
        }
    }
    public void Die()
    {
        GameObject.Find("GameController").GetComponent<GameController>().AddScore();
        Destroy(gameObject);
    }

}
