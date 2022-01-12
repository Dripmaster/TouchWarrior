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
        yourScore.text = "0";//from stageManager
        bestScore.text = "0";//from local
        myCoin.text = "0";//from local
        plusCoin.text = "0";//from stageManager or different Manager
        highScore.SetActive(true);//compare currentScore vs bestScore
    }
    public void continueBtn()
    {
        SceneManager.LoadScene(1);
    }
}
