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
    Animator anim;
    float limitTime;
    float timeValue;
    bool showTimeBar;
    RectTransform rect;


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
        anim = GetComponent<Animator>();
        initTime(9,true);
        rect = GetComponent<RectTransform>();
        defualtWidth = rect.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void overTime()
    {
        anim.SetTrigger("TimeOver");
    }
    void initTime(float l, bool show = false)
    {
        limitTime = l;
        showTimeBar = show;
        Stopped = false;
        StopAllCoroutines();
        StartCoroutine(countTimer());
    }
    IEnumerator countTimer()
    {
        timeValue = 0;
        do
        {
            yield return null;
            if (Stopped)
                continue;
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
    public void timeStop(bool v)
    {
        Stopped = v;
    }
    bool Stopped;
    public float getLimitTime()
    {
        return limitTime;
    }
    public void changeLimit(float v)
    {//effect here?
        float ratio = v/limitTime;
        limitTime = v;
        timeValue *= ratio;
        float ChangeRatio = limitTime / defualtLimitTime;
        rect.sizeDelta = new Vector2(defualtWidth*0.5f + defualtWidth * ChangeRatio*0.5f , rect.sizeDelta.y);

    }
    float defualtLimitTime = 9;
    float defualtWidth;
    public IEnumerator TimeReCount()
    {
        do
        {
            yield return null;

            timeValue -= Time.deltaTime*limitTime;
            ForeBar.fillAmount = (limitTime - timeValue) / limitTime;
            TimeText.text = (limitTime - timeValue).ToString("F1");
            if (timeValue <= 0)
            {
                timeValue = 0;
                break;
            }
        } while (true);
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
