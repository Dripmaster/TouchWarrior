using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScene : MonoBehaviour
{
    public Text coinText;
    public GameObject selectFrame;

    public CollectionItem[] commonSkins;
    public CollectionItem[] EpicSkins;
    public CollectionItem[] LegendSkins;

    public ButtonSetArray buttonSetArray;
    public int current;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = ""+SaveManager.getData("gold",1000);
        int i = 0;
        current =
        PlayerPrefs.GetInt("ButtonSets", 11);
        PlayerPrefs.SetInt("IsButtonSets" + 11,1);
        foreach (var item in buttonSetArray.buttonSets)
        {
            int have = PlayerPrefs.GetInt("IsButtonSets"+i, 0);
            if (have == 0) { i++;  continue; }
            if (i < 11)
            {
                commonSkins[i].setImageSet(item,i);
                if (i == current)
                {
                    selectFrame.transform.parent = commonSkins[i].transform;
                    selectFrame.transform.localPosition = Vector3.zero;
                }
            }
            else if (i < 14)
            {
                EpicSkins[i - 11].setImageSet(item, i);
                if (i == current)
                {
                    selectFrame.transform.parent = EpicSkins[i - 11].transform;
                    selectFrame.transform.localPosition = Vector3.zero;
                }
            }
            else
            {
                LegendSkins[i - 14].setImageSet(item, i);
                if (i == current)
                {
                    selectFrame.transform.parent = LegendSkins[i - 14].transform;
                    selectFrame.transform.localPosition = Vector3.zero;
                }
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetButtonSet(int i)
    {
        if(SoundManager.Instance)
        SoundManager.Instance.playOneShot(8);
        PlayerPrefs.SetInt("ButtonSets", i);
    }
}
