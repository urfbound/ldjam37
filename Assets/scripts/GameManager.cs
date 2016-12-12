using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int lifeCount = 5;
    public float resetDelay = 2.5f;
    public Text livesText; public Text scoreText;
    public GameObject gameOver, youWon;
    public GameObject bricksPrefab; public GameObject redBrickPrefab, grnBrickPrefab, bluBrickPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GameManager instance = null;

    public CupTopCollider cup0, cup1, cup2, cup3;
    public CleanupAfterDeath cad;

    private int bricks = 0;
    private GameObject clonePaddle;
    private GameObject cloneBall;
    private int score; private int lastLifeUpScore = 0; private int lifeUpScoreInterval = 10000;
    private Vector3 brickLayouPos;
    private float brickXAnchor = -5.7f; private float brickYAnchor = 4.5f;
    private float brickXPosOffset = 2.25f;
    private float brickYPosOffset = 1f;

    //Unity methods
    private void Start()
    {
        brickLayouPos = new Vector3(-5f, 5f, 0f);

        if (instance == null) { instance = this; }
        else { Destroy(gameObject); } //enforce singleton GameManager
        setUp();
    }

    //User-created methods
    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score-lastLifeUpScore>=lifeUpScoreInterval)
        {
            lastLifeUpScore += lifeUpScoreInterval;
            lifeCount += 1;
        }
        updateTextItems();
    }

    public void setUp()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
        cloneBall = clonePaddle.transform.GetChild(0).gameObject;
        //Instantiate(bricksPrefab, transform.position, Quaternion.identity); //TODO setup the bricks
        addBricks();
        score = 0; updateTextItems();
    }

    public void checkGameOver()
    {
        if(bricks <= 0)
        {
            addBricks();
        }
        if(lifeCount <= 0)
        {
            gameOver.SetActive(true);
            SceneManager.LoadScene("top_menu");
            //SceneManager.UnloadScene("game1");
        }
    }

    public void loseLife()
    {
        lifeCount--;
        updateTextItems();
        Instantiate(deathParticles, cloneBall.transform.position, Quaternion.identity);
        Destroy(cloneBall);
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        cup0.doScores(); cup1.doScores(); cup2.doScores(); cup3.doScores();
        cad.startCleanUp();
        Invoke("setUpPaddle", resetDelay);
        checkGameOver();
    }

    public void destroyBrick()
    {
        bricks--;
        addScore(100);//score+=100;
        updateTextItems();
        checkGameOver();//TODO check that this condition should remain
    }

    private void addBricks()
    {
        System.Random myRnd = new System.Random();
        for(int i=0; i < 6; i++)//each row of bricks
        {
            for(int j=0; j<3; j++)//each column of bricks
            {
                int brickColourChoice = myRnd.Next(3);
                GameObject brickToInstantiate = null;
                Vector3 brickLoc = new Vector3(brickXAnchor+(i*brickXPosOffset), brickYAnchor-(j*brickYPosOffset), 0f);
                switch (brickColourChoice)
                {
                    case 0: //R
                        brickToInstantiate = redBrickPrefab;
                        break;
                    case 1: //G
                        brickToInstantiate = grnBrickPrefab;
                        break;
                    case 2: //B
                        brickToInstantiate = bluBrickPrefab;
                        break;
                }
                Instantiate(brickToInstantiate, brickLoc, Quaternion.identity);
                bricks++;
            }
        }
    }

    private void updateTextItems()
    {
        livesText.text = "Lives: " + lifeCount.ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    private void reset()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("game1");
        SceneManager.LoadScene("game1");//TODO this will probably break
        //SceneManager.MergeScenes();//TODO figure out how to use this
    }

    private void setUpPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        cloneBall = clonePaddle.transform.GetChild(0).gameObject;
    }
}
