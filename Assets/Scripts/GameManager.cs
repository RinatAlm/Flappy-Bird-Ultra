using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum LevelType
    {
        EASY,
        MEDIUM,
        HARD
    };

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
    public MovingObject background;
    public static GameManager instance;
    public bool gameOver = false;
    public int score;
    public Text scoreText;


    private void Awake()
    {
        instance = this;//Taking instance of GameManager for comfortable access
        level = Level.instance;
        if (level != null)
        {
            Debug.Log(level.levelType.ToString());
            if (level.levelType == Level.LevelType.EASY)//Check EASY
            {
                difficulty = new Difficulty(3, 1.75f);
            }
            else if (level.levelType == Level.LevelType.MEDIUM)
            {
                difficulty = new Difficulty(4, 1.5f);
            }
            else
            {
                difficulty = new Difficulty(5, 1.25f);
            }
        }
        spawnDelay = difficulty.spawnDelay;
        background.moveSpeed = difficulty.moveSpeed;
    }

    private void Start()
    {       
        StartCoroutine(SpawnCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        SceneManager.LoadScene("GameScene");
    }
    public void GameOver()//Game over Event
    {
        gameOver = true;
        Debug.Log("GameOver");
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
            yield return new WaitForSeconds(Random.Range(spawnDelay,spawnDelay+1));
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, CalculateSpawnPos(), Quaternion.identity);
        //Level Check
        obstacle.GetComponent<MovingObject>().moveSpeed = difficulty.moveSpeed;
        
    }
}
