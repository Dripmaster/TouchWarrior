using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    public Text yourScore;
    public Text bestScore;
    public Text myCoin;
    public Text plusCoin;
    public GameObject highScore;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPopup()
    {

        int high = SaveManager.getData("classicScore");
        if (high < GameManager.Instance.stageManager.getStage())
        {//highScore
            SaveManager.saveData("classicScore", GameManager.Instance.stageManager.getStage());
            highScore.SetActive(true);//compare currentScore vs bestScore
        }
        else
        {
            highScore.SetActive(false);//compare currentScore vs bestScore
        }

        yourScore.text = ""+GameManager.Instance.stageManager.getStage();//from stageManager
        bestScore.text = ""+ SaveManager.getData("classicScore");//from local
        myCoin.text = ""+SaveManager.getData("gold");//from local
        plusCoin.text = ""+ GameManager.Instance.stageManager.getStage();//from stageManager or different Manager

        int gold = SaveManager.getData("gold");
        gold += GameManager.Instance.stageManager.getStage();
        SaveManager.saveData("gold", gold);
    }
    public void continueBtn()
    {
        SoundManager.Instance.playOneShot(8);
        SceneManager.LoadScene(1);
    }
}
