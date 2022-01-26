using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private static TimerManager _instance;
    public static TimerManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(TimerManager)) as TimerManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }


    public Image ForeBar;
    public Text TimeText;
    float limitTime;
    float timeValue;
    bool showTimeBar;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initTime(7,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initTime(float l, bool show = false)
    {
        limitTime = l;
        showTimeBar = show;
        StopAllCoroutines();
        StartCoroutine(countTimer());
    }
    IEnumerator countTimer()
    {
        timeValue = 0;
        do
        {
            yield return null;
            timeValue += Time.deltaTime;
            if (showTimeBar)
            {
                ForeBar.fillAmount = (limitTime - timeValue) / limitTime;
                TimeText.text = (limitTime - timeValue).ToString("F1");
            }
            if(limitTime!=0&& limitTime - timeValue <= 0)
            {//limit time reach
                timeValue = limitTime;
                GameManager.Instance.timeOut();
                break;
            }
        } while (true);
    }
    public float getLimitTime()
    {
        return limitTime;
    }
    public void changeLimit(float v)
    {//effect here?
        limitTime = v;
    }
    public void reCountTime()
    {
        timeValue = 0;
    }
    public void reduceTime(float v)
    {
        timeValue -= v;
        if (timeValue <= 0)
        {
            timeValue = 0;
        }
    }
    public float getRemainTime()
    {
        return (limitTime - timeValue);
    }
}
