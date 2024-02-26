using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Unity.UI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;

    
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget(){
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           
        }
    }
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
         scoreText.text = "Score: " + score;

    }

    public void UpdateLives(int livesToReduce){
        if(isGameActive){        
            lives -= livesToReduce;
            livesText.text = "Lives: " + lives;
        }


    }
    public void GameOver(){

        gameOverText.gameObject.SetActive(true);
        isGameActive =false;
        restartButton.gameObject.SetActive(true);

    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty){
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(0);
        titleScreen.gameObject.SetActive(false);
    }
}
