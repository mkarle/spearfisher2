using UnityEngine;
using System.Collections;

public class SharkHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().Die();
        }
        if (other.gameObject.CompareTag("Spear"))
        {
            GetComponent<Rigidbody>().SendMessage("Hit");
        }

    }
}
