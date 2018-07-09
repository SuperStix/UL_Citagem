using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour {

    public GameObject go_MainGame;//MainGame
    public GameObject sv_AfterGame;//Scroll View
    public GameObject sv_AtEndGame;//getplayername dialog
    public GameObject go_hint;
    public GameObject img_box;
    public GameObject go_timer;
    public float box_animate_time;
    public InputField _inputField;//inputfield
    public int numberOfDetailers;
    public Text text_player_score;
    public bool pauseGlobalTime;
    public float GameTimer;
    public Text TimeText;
    private bool isScrollSnapActive = false;
    private bool isGameStarted;
    private string mScore;
    private ShapesManager shapesManager;
    int score_from_the_game;
    int last_score;
    private SoundManager soundManager;
    private ScrollSnap scrollSnap;


    private void Awake()
    {
        
        shapesManager = GameObject.Find("ShapesManager").GetComponent<ShapesManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        //scrollSnap = GameObject.Find("Scroll View").GetComponent<ScrollSnap>();
    }

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "playAgain")
            isGameStarted = true;
        else
            isGameStarted = false;
        
        DOTween.Init();//init dot tween library
        sv_AtEndGame.SetActive(false);
        go_hint.SetActive(true);
        mScore = "";

        if (SceneManager.GetActiveScene().name == "mainGame2")
            soundManager.PlaySoundSlide2();

        img_box.GetComponent<Animator>().enabled = false;  
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
            //global timer
        if (!pauseGlobalTime && isGameStarted)
            {
                if (GameTimer <= 0)
            {
                StartCoroutine(afterGameJobs());

            }
            else
            {
                    TimeText.text = GetTime();
                    GameTimer -= Time.deltaTime;
            }
        }

        if (isScrollSnapActive)
        {
            if (scrollSnap.isPage4)
            {
                // animate box
                StartCoroutine(animateBox(box_animate_time));
            }
        }
       
    }

    public void activateSnapReference(){
        isScrollSnapActive = true;
        scrollSnap = GameObject.Find("Scroll View").GetComponent<ScrollSnap>();
    }
    private IEnumerator animateBox(float animate_time)
    {
        //box_animate_time -= Time.deltaTime;
        img_box.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(animate_time);
        //StopCoroutine("animateBox");
    }



    private IEnumerator afterGameJobs(){
        shapesManager.DestroyAllCandy();
        go_hint.SetActive(false);
        int.TryParse(shapesManager.ScoreText.text, out score_from_the_game);
        //compare to last score in the leaderboard
        last_score = Leaderboard.GetEntry(4).score;
        //is this really a highscore?
        if (score_from_the_game > last_score)
        {
            sv_AtEndGame.SetActive(true);
            setTimerVisibility(false);
        }else{
            ProceedToShowScore();
        }

        yield return new WaitForSeconds(0.5f);
        StopCoroutine("afterGameJobs");
    }

    public void setTimerVisibility(bool _isVisible){
        go_timer.SetActive(false);
    }

    private void ProceedToShowScore()
    {
        mScore = shapesManager.ScoreText.text;
        PlayerPrefs.SetInt("Score", int.Parse(mScore));
        text_player_score.text = "You've got " + PlayerPrefs.GetInt("Score") + " points!";
        go_MainGame.SetActive(false);
        sv_AfterGame.SetActive(true);
        setTimerVisibility(false);
    }

    public void act_savePlayerName(){
        Leaderboard.Record(_inputField.text,score_from_the_game);
        ProceedToShowScore();
    }

    public int getTotalPages(){
        return numberOfDetailers;
    }

    public void setTotalPages(int _numPages)
    {
        numberOfDetailers = _numPages;
    }

    public void resetTimer(){
        isGameStarted = true;
        GameTimer = 30.5f;
        setTimerVisibility(true);
    }

    public void startGame(bool c){
        isGameStarted = c;
        GameTimer = 30.5f;
    }


    string GetMinute()
    {
        return System.Math.Floor(GameTimer / 60).ToString();
    }

    string GetSecond()
    {
        return System.Math.Floor(GameTimer % 60).ToString();
    }

    string GetTime()
    {
        string minute = GetMinute();
        string second = GetSecond();

        if (minute.Length < 2)
        {
            minute = "0" + minute;
        }
        if (second.Length < 2)
        {
            second = "0" + second;
        }

        return System.String.Format("{0}:{1}", minute, second);
    }


    public void PlayAgain()
    {
       SceneManager.LoadScene("playAgain");
    }
}
