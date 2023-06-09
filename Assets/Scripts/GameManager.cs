using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    public struct Difficulty
    {
        public Difficulty(float moveSpeed,float spawnDelay)
        {
            this.moveSpeed = moveSpeed;
            this.spawnDelay = spawnDelay;
        }
        public float moveSpeed;
        public float spawnDelay;
    }


    Difficulty difficulty = new Difficulty(4,1.5f);
    private Level level;
    [SerializeField]
    private Vector3 obstacleSpawnPos;
    [SerializeField]
    private float spawnOffset;

    public float spawnDelay = 1;
    public GameObject obstaclePrefab;
    public GameObject BG;
    public MovingObject background;
    public static GameManager instance;
    public bool gameOver = false;
    public int score;
    public Text scoreText;
    public GameObject gameMenu;
    public Text levelData_Text;

    

    private void Awake()
    {
        instance = this;//Taking instance of GameManager for comfortable access
        level = Level.instance;
        if (level != null)
        {           
            if (level.levelOffset == 0)//Check EASY
            {
                difficulty = new Difficulty(3, 3f);
            }
            else if (level.levelOffset == 1)
            {
                difficulty = new Difficulty(4, 2f);
            }
            else
            {
                difficulty = new Difficulty(5, 1.25f);
            }
        }
        spawnDelay = difficulty.spawnDelay;
        background.moveSpeed = difficulty.moveSpeed/2;
    }

    private void Start()
    {
        gameMenu.SetActive(false);
        level.LoadData();
        StartCoroutine(SpawnCoroutine());
    }
  
    public void GameOver()//Game over Event
    {
        gameOver = true;
        if(level.score<score)
        {
            Debug.Log("Saved" + level.score.ToString() + " is less" + score.ToString());
            level.score = score;
            level.SaveData();
        }
        level.LoadData();
        BG.GetComponent<MovingObject>().enabled = false;
        gameMenu.SetActive(true);
        levelData_Text.text = "Level type : " + "<color=" + level.colorName + ">" + level.levelName + "</color>" + "\n Record : " + level.score.ToString();
    }

    private Vector3 CalculateSpawnPos()
    {
        Vector3 calculatedSpawnPos = new Vector3(obstacleSpawnPos.x, Random.Range(-spawnOffset, spawnOffset), obstacleSpawnPos.z);
        return calculatedSpawnPos;
    }

    private IEnumerator SpawnCoroutine()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(Random.Range(spawnDelay,spawnDelay+0.5f));
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, CalculateSpawnPos(), Quaternion.identity);
        //Level Check
        obstacle.GetComponent<MovingObject>().moveSpeed = difficulty.moveSpeed;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        AudioManager.instance.Play("Button");
        if (!AudioManager.instance.isMainMusicRunning)
        {
            AudioManager.instance.Play("MainMusic");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("IntroScene");
        AudioManager.instance.Play("Button");
    }
}
