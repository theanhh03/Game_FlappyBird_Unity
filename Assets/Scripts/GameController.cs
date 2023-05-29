using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    public Text txtPoint;
    public GameObject pnlEndGame;
    public Text txtEndPoint;
    public Button btnRestart;
    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;
    
    
    bool isStartFirstTime = true;
    public bool check; // check is endgame or not
    int gamePoint = 0;

    public void RestartButtonIdle(){
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    public void RestartButtonHover(){
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }
    public void RestartButtonClick(){
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }
    void Start()
    {
        Time.timeScale = 0;
        check = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
    }

    void Update()
    {
        if(check){
            if(Input.GetMouseButtonDown(0) && isStartFirstTime ){
                StartGame();
        }
        }
        else{
            if(Input.GetMouseButton(0)){
            Time.timeScale = 1;
        }
        }   
    }
    public void GetPoint(){
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
        }
    void StartGame(){
        SceneManager.LoadScene(0);
    }
    public void Restart(){
        StartGame();
    }

    public void Endgame(){
        check = true;
        Time.timeScale = 0;
        isStartFirstTime =false;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Score\n" + gamePoint.ToString();
    }
}
