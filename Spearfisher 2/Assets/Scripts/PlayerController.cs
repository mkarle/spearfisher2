using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject Gun;
    public GameObject Spear;
    public GameObject SpearSpawn;
    private float timer;
    private int fireRate = 500;
    private int power = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       // timer += Time.deltaTime;
        if (Input.GetMouseButtonUp(0))
        {
           // if (timer > fireRate)
           // {
            //    timer = 0;

                OnShoot(power);
                power = 0;
           // }
        }
        if (Input.GetMouseButton(0))
        {
            power++;
        }
        
	}
    public void OnShoot(int power)
    {
        GameObject spear = (GameObject) Instantiate(Spear, SpearSpawn.transform.position, SpearSpawn.transform.rotation);
        spear.GetComponent<Rigidbody>().AddForce(SpearSpawn.transform.up * 6000 * (power / 100));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shark"))
        {
            Die();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Shark"))
            Die();
    }

    public void Die()
    {

        GameObject.FindGameObjectWithTag("Game Controller").GetComponent<GameController>().EndGame();
    }
}
