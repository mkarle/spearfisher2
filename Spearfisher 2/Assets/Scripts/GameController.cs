using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VR;

public class GameController : MonoBehaviour {

    public GameObject Player;
    public GameObject Menu;
    public GameObject ResetMenu;
    public GameObject Enemy;
    public GameObject Orca;
    public GameObject Shark;
    public GameObject Lio;
    public float SpawnTime = 3f;
    public Transform[] SpawnPoints;
    public int Score;
    public GameObject ScoreText;
    private bool gameOver = false;
	// Use this for initialization
	void Start () {
        VRSettings.renderScale = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void OnPlay()
    {
        Menu.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = true;
        InvokeRepeating("Spawn", SpawnTime + 2, SpawnTime);
    }

    public void EasyDifficulty()
    {
        SpawnTime = 5f;
    }

    public void HardDifficulty()
    {
        SpawnTime = 3f;
    }

    public void AwfulDifficulty()
    {
        SpawnTime = 1f;
    }

    public void OrcaAnimal()
    {
        Enemy = Orca;
    }

    public void SharkAnimal()
    {
        Enemy = Shark;
    }

    public void LioAnimal()
    {
        Enemy = Lio;
    }

    void Spawn()
    {
        if (gameOver)
        {
            return;
        }

        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(Enemy, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }

    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            foreach (GameObject shark in GameObject.FindGameObjectsWithTag("Shark"))
            {
                Destroy(shark);
            };
            ResetMenu.SetActive(true);
        }
        
    }
    public void AddScore()
    {
        Score++;
        ScoreText.GetComponent<Text>().text = "Score: " + Score;
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
