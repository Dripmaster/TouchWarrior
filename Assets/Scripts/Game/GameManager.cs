using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public StageManager stageManager;
    public Sprite[] displaybtnSprites;
    public Sprite displaybtnBackSprite;
    public Sprite displaybtnQusetionSprite;
    public IconDisplay[] displayIcons;
    public IconDisplay[] displayIconsBoss;
    public IconBtn[] IconBtns;
    public Transform[] BtnPositions;
    bool[] BtnPositions_occupied;

    public PopupManager popup_GameOverClear;


    bool isStageClear;
    int currentIndex;

    public RectTransform[] SwapObject1;
    public RectTransform[] SwapObject2;

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
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //cheatClick();
                stageManager.UpStage();
            }
        }
    }
    public void setOccupied(int posid, bool value) {
       if( BtnPositions_occupied ==null)
        {
            BtnPositions_occupied = new bool[BtnPositions.Length];
        }
        BtnPositions_occupied[posid] = value;
    }
    public Sprite GetSprite(int id)
    {
        if (id < 0)
            return null;
        return displaybtnSprites[id];
    }
    public Sprite GetBackSprite()
    {
        return displaybtnBackSprite;
    }
    public Sprite GetQusetionSprite()
    {
        return displaybtnQusetionSprite;
    }

    public void onBtnClicked(int imgId)
    {
        if (isStageClear) return;

        if(displayIcons[currentIndex].imageId == imgId)//correct
        {//correct Effect Here
            displayIcons[currentIndex].fire();
            currentIndex++;
            if (currentIndex >= (stageManager.isBoss ? displayIcons.Length : displayIcons.Length - displayIconsBoss.Length))
            {
                isStageClear = stageManager.UpStage(); // max stage clear
            }
        }
        else//miss
        {
            timeOut();
        }
    }
    public void cheatClick()
    {
        displayIcons[currentIndex].fire();
        currentIndex++;
        if (currentIndex >= (stageManager.isBoss ? displayIcons.Length : displayIcons.Length - displayIconsBoss.Length))
        {
            isStageClear = stageManager.UpStage(); // max stage clear
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

    public void doSkill(SkillType skill)
    {
        switch (skill)
        {
            case SkillType.flip:
                {
                    StartCoroutine(flipCards());
                }
                break;
            case SkillType.move:
                {
                    int targetBtn = Random.Range(0,IconBtns.Length);
                    int targetIndex = Random.Range(0, BtnPositions.Length);
                    int idx = IconBtns[targetBtn].PosId;
                    for (int i = 0; i < targetIndex; i++)
                    { 
                        if (BtnPositions_occupied[idx] == true)
                        {
                            idx++;
                            i--;
                            if (idx >= BtnPositions.Length)
                            {
                                idx = 0;
                            }
                        }
                    }
                    BtnPositions_occupied[IconBtns[targetBtn].PosId] = false;
                    BtnPositions_occupied[idx] = true;
                    IconBtns[targetBtn].PosId = idx;
                    IconBtns[targetBtn].setPos(idx,true);
                }
                break;
            case SkillType.swap:
                {
                    foreach (var sobj in SwapObject1)
                    {
                        //sobj.localPosition = new Vector3(sobj.localPosition.x,-150+(-150-sobj.localPosition.y));
                        StartCoroutine(swapPos( sobj, new Vector3(sobj.localPosition.x, -20 + (-20 - sobj.localPosition.y))));
                    }
                    foreach (var sobj in SwapObject2)
                    {
                        //var soj = sobj.GetComponentInParent<RectTransform>();
                        //sobj.localPosition = new Vector3(sobj.localPosition.x, -80+ (-80 - sobj.localPosition.y));
                        StartCoroutine(swapPos(sobj, new Vector3(sobj.localPosition.x, -80 + (-80 - sobj.localPosition.y))));
                    }
                }
                break;
            case SkillType.bounce:
                {
                    if (bounceCoroutine != null)
                        StopCoroutine(bounceCoroutine);
                    bounceCoroutine = StartCoroutine(bounceCard());
                }
                break;
            case SkillType.boss:
                {
                    stageManager.nowBoss();
                }
                break;
        }
    }
    Coroutine bounceCoroutine;
    IEnumerator bounceCard()
    {
        int i = 0;

        int endStage = stageManager.getStage();
        if (endStage > 100)
            endStage += 3;
        else if (endStage > 50)
            endStage += 2;
        else
            endStage += 1;
        do
        {
            foreach (var icon in displayIcons)
            {
                i++;

                icon.flip(i % 2 == 0);
            }
            i++;
            yield return new WaitForSeconds(0.5f);
            if (stageManager.getStage() >= endStage)
                break;
        } while (true);
        foreach (var icon in displayIcons)
        {
            icon.flip(false);
        }
    }

    IEnumerator swapPos(RectTransform r, Vector3 targetpos)
    {

        Vector3 tmpPos = r.localPosition;
        float dt = 0;
        do
        {
            yield return null;
            dt += Time.deltaTime*2;
            r.localPosition = Vector3.Lerp(tmpPos, targetpos, dt);
            if (dt >= 1)
            {
                r.localPosition = targetpos;
                break;
            }
        } while (true);
    }

    IEnumerator flipCards()
    {
        int endStage = stageManager.getStage();

        if (endStage > 169)
            endStage += 2;
        else
            endStage += 1;


      foreach (var icon in IconBtns)
      {
            icon.FlipIcon();
            yield return new WaitForSeconds(0.1f);
      }

        do
        {
            yield return null;
            if (stageManager.getStage() >=endStage)
            {
                break;
            }
        } while (true);


        foreach (var icon in IconBtns)
        {
            icon.FlipIcon(true);
        }
    }
}
