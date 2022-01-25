using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    Text stageText;
    public int maxStage = 0;//0 = inf, other = 1~MaxStage

    public SkillScript[] skills;
    
    int currentStage;

    private void Awake()
    {
        stageText = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
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
            setText(currentStage);
            setStageBtn(currentStage);
            GameManager.Instance.clearIndex();
            TimerManager.Instance.reCountTime();
            checkSkill();
        }
        return isComplete;
    }
    public int getStage()
    {
        return currentStage;
    }

    public void setStageBtn(int s)
    {
        foreach (var item in GameManager.Instance.displayIcons)
        {
            item.setImage(Random.Range(0, 5));
        }
    }
    public void checkSkill()
    {
        foreach (var skill in skills)
        {
            if (currentStage%skill.popupStage == 0) {
                //doSkill
                GameManager.Instance.doSkill(skill.skillType);
            }
        }
    }
}
