using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject bossIcon;
    Text stageText;
    Animator anim;
    public int maxStage = 0;//0 = inf, other = 1~MaxStage

    
    int currentStage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stageText = GetComponent<Text>();
        bossIcon.SetActive(false);
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        isBoss = false;
        currentStage = 0;
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

        currentStage++;
        if (maxStage!=0&&(currentStage > maxStage))
        {
            currentStage = maxStage;
            isComplete = true;
        }
        else
        {
            StartCoroutine(stageUpEffect());
        }
        return isComplete;
    }

    IEnumerator stageUpEffect()
    {
        anim.SetTrigger("StageClear");
        setText(currentStage);
        if (isBoss)
        {
            bossIcon.SetActive(true);
        }
        else
        {
            bossIcon.SetActive(false);
        }
        checkTimer();
        if (currentStage == 1)
            SoundManager.Instance.playOneShot(0);
        StartCoroutine(TimerManager.Instance.TimeReCount());
        yield return StartCoroutine(setStageBtn());
        GameManager.Instance.clearIndex();
        GameManager.Instance.startNextStageReal();
    }



    public void timerStop(bool v)
    {
        TimerManager.Instance.timeStop(v);
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
        else if (currentStage > 120)
        {
            t = 5.0f;
        }
        else if (currentStage > 100)
        {
            t = 5.5f;
        }
        else if (currentStage > 70)
        {
            t = 6.0f;
        }
        else if (currentStage > 50)
        {
            t = 6.5f;
        }
        else if (currentStage > 30)
        {
            t = 7;
        }
        else if (currentStage > 10)
        {
            t = 8.0f;
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
            GameManager.Instance.textEffect_Skill.setSprite(0);
            GameManager.Instance.textEffect_Skill.gameObject.SetActive(true);
        }
        if(currentStage!=1)
        TimerManager.Instance.changeLimit(t);
    }
    public int checkSkill()
    {
        int isSkillStage = -1;
        if (isBoss)
            endBoss();


        if ((currentStage + 1) > 199)
        {
            switch ((currentStage + 1) % 10)
            {
                case 2:
                case 4:
                case 6:
                case 8:
                case 0:
                    isSkillStage = Random.Range(0, 4);
                    GameManager.Instance.doSkill((SkillType)isSkillStage);
                    break;
            }
        }
        else if((currentStage + 1) > 151)
        {
            switch ((currentStage + 1) % 10)
            {
                case 2:
                case 5:
                case 8:
                case 0:
                    isSkillStage = Random.Range(0, 4);
                    GameManager.Instance.doSkill((SkillType)isSkillStage);
                    break;
            }

        }
        else if ((currentStage + 1) > 102)
        {
            switch ((currentStage + 1) % 10)
            {
                case 3:
                case 6:
                case 0:
                    isSkillStage = Random.Range(0, 4);
                    GameManager.Instance.doSkill((SkillType)isSkillStage);
                    break;
            }
        }
        else if ((currentStage + 1) > 34)
        {
            if(currentStage%5 == 0)
            {
                isSkillStage = Random.Range(0, 4);
                GameManager.Instance.doSkill((SkillType)isSkillStage);
            }
        }else if ((currentStage + 1) > 5)
        {
            switch ((currentStage + 1))
            {
                case 7:
                case 17:
                case 30:
                    {
                        isSkillStage = Random.Range(0, 2);
                        GameManager.Instance.doSkill((SkillType)isSkillStage);
                    }
                    break;
                case 13:
                case 25:
                    {
                        isSkillStage = Random.Range(0, 2)+2;
                        GameManager.Instance.doSkill((SkillType)isSkillStage);
                    }
                    break;
            }
        }

        if ((currentStage + 1) % 10 == 0)
        {
            isSkillStage = 4;
            GameManager.Instance.doSkill(SkillType.boss);
        }

        return isSkillStage+1;

    }
    IEnumerator LateReal()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.startNextReal();
    }
    public void nowBoss()
    {
        isBoss = true;
        if (currentStage < 30)
        {
            TimerManager.Instance.changeLimit(TimerManager.Instance.getLimitTime() * 1.75f);//effect Here?
            StartCoroutine(LateReal());
        }
        else
        {
            TimerManager.Instance.changeLimit(TimerManager.Instance.getLimitTime() * 2f);//effect Here?

        }
    }
    public void endBoss()
    {

        //boss stage effect end Here
        isBoss = false;
    }
    public bool isBoss;
}
