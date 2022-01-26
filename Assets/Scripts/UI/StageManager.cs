using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    Text stageText;
    public int maxStage = 0;//0 = inf, other = 1~MaxStage

    
    int currentStage;

    private void Awake()
    {
        stageText = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        isBoss = false;
        currentStage = 0;
        foreach (var btn in GameManager.Instance.displayIconsBoss)
        {
            btn.hide();
        }
        UpStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setText(int s)
    {
        stageText.text = s.ToString("D3");
    }
    public bool UpStage()
    {
        bool isComplete = false;

        if (isBoss)
            endBoss();
        currentStage++;
        if (maxStage!=0&&(currentStage > maxStage))
        {
            currentStage = maxStage;
            isComplete = true;
        }
        else
        {
            checkSkill();
            checkTimer();
            setText(currentStage);
            StartCoroutine(setStageBtn());
            GameManager.Instance.clearIndex();
            TimerManager.Instance.reCountTime();
        }
        return isComplete;
    }
    public int getStage()
    {
        return currentStage;
    }
    IEnumerator setStageBtn()
    {
        int i = 0;
        foreach (var item in GameManager.Instance.displayIcons)
        {
            i++;
            if (!isBoss&& i > 6)
                break;
            item.show();
            item.setImage(Random.Range(0, 6));
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void checkTimer()
    {
        /*
         최초 시간제한 7초
        11스테이지부터 6.5초, 31스테이지부터 6초, 61스테이지부터 5.5초, 101스테이지부터 5초, 131스테이지부터 4.5초, 151스테이지부터 4초, 201스테이지부터 3.5초
        적용 이펙트 : Hurry up! 텍스트, 시간바 UI가 흔들리면서 줄어든 시간만큼 토막남 (가운데정렬 유지)
         */
        if (isBoss)
            return;
        float t = TimerManager.Instance.getLimitTime();
        bool change = false;
        if (currentStage > 200)
        {
            t = 3.5f;
        }
        else if(currentStage>150) {
            t = 4;
        }
        else if (currentStage > 130)
        {
            t = 4.5f;
        }
        else if (currentStage > 100)
        {
            t = 5.0f;
        }
        else if (currentStage > 60)
        {
            t = 5.5f;
        }
        else if (currentStage > 30)
        {
            t = 6;
        }
        else if (currentStage > 10)
        {
            t = 6.5f;
        }
        switch (currentStage)
        {
            case 11:
                change = true; 
                break;
            case 31:
                change = true;
                break;
            case 61:
                change = true;
                break;
            case 101:
                change = true;
                break;
            case 131:
                change = true;
                break;
            case 151:
                change = true;
                break;
            case 201:
                change = true;
                break;
        }
        if (change)
        {
            //effect here
        }
        TimerManager.Instance.changeLimit(t);
    }
    public void checkSkill()
    {
        if(currentStage%10 == 0)
        {
            GameManager.Instance.doSkill(SkillType.boss);
        }

        if (currentStage > 199)
        {
            switch (currentStage % 10)
            {
                case 2:
                case 4:
                case 6:
                case 8:
                case 0:
                    GameManager.Instance.doSkill((SkillType)Random.Range(0, 4));
                    break;
            }
        }
        else if(currentStage > 151)
        {
            switch (currentStage % 10)
            {
                case 2:
                case 5:
                case 8:
                case 0:
                    GameManager.Instance.doSkill((SkillType)Random.Range(0, 4));
                    break;
            }

        }
        else if (currentStage > 102)
        {
            switch (currentStage%10)
            {
                case 3:
                case 6:
                case 0:
                    GameManager.Instance.doSkill((SkillType)Random.Range(0, 4));
                    break;
            }
        }
        else if (currentStage > 54)
        {
            if(currentStage%5 == 0)
            {
                GameManager.Instance.doSkill((SkillType)Random.Range(0, 4));
            }
        }else if (currentStage>14)
        {
            switch (currentStage)
            {
                case 15:
                case 32:
                case 45:
                    {
                        GameManager.Instance.doSkill((SkillType)Random.Range(0,2));
                    }
                    break;
                case 25:
                case 42:
                case 50:
                    {
                        GameManager.Instance.doSkill((SkillType)Random.Range(0, 2)+2);
                    }
                    break;
            }
        }


    }
    public void nowBoss()
    {
        //boss stage effect Here
        isBoss = true;
        if (currentStage < 29)
        {
            TimerManager.Instance.changeLimit(TimerManager.Instance.getLimitTime() * 1.75f);//effect Here?
        }
        else
        {
            TimerManager.Instance.changeLimit(TimerManager.Instance.getLimitTime() * 2f);//effect Here?

        }
    }
    public void endBoss()
    {
        //boss stage effect end Here
        foreach (var btn in GameManager.Instance.displayIconsBoss)
        {
            btn.hide();
        }
        isBoss = false;
    }
    public bool isBoss;
}
