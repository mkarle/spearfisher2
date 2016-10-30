using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {
    private bool hit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (!hit)
        {
            hit = true;
            transform.parent = other.transform;
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<Collider>());
        }

    }
}
