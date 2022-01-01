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

    int currentIndex;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        stageManager = FindObjectOfType(typeof(StageManager)) as StageManager;
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
        if(displayIcons[currentIndex].imageId == imgId)//correct
        {
            displayIcons[currentIndex].fire();
            currentIndex++;
            if (currentIndex >= displayIcons.Length)
            {
                stageManager.UpStage();
            }
        }
        else//miss
        {
            print("die~~~");
        }
    }
    public void clearIndex()
    {
        currentIndex = 0;
    }

}
