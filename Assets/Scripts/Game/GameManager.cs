using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    StageManager stageManager;
    public Sprite[] displaybtnSprites;
    public IconDisplay[] displayIcons;

    public PopupManager popup_GameOverClear;


    bool isStageClear;
    int currentIndex;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        stageManager = FindObjectOfType(typeof(StageManager)) as StageManager;
        isStageClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetSprite(int id)
    {
        return displaybtnSprites[id];
    }

    public void onBtnClicked(int imgId)
    {
        if (isStageClear) return;

        if(displayIcons[currentIndex].imageId == imgId)//correct
        {
            displayIcons[currentIndex].fire();
            currentIndex++;
            if (currentIndex >= displayIcons.Length)
            {
                isStageClear = stageManager.UpStage(); // max stage clear
            }
        }
        else//miss
        {
            timeOut();
        }
    }
    public void clearIndex()
    {
        currentIndex = 0;
    }
    public void timeOut()
    {
        popup_GameOverClear.gameObject.SetActive(true);
        popup_GameOverClear.setPopup();
    }
}
