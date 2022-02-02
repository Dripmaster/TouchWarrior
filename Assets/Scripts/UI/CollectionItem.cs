using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionItem : MonoBehaviour
{
    Image[] childImage;
    Button btn;
    int myId;
    GameObject SelectFrame;
    // Start is called before the first frame update
    void Start()
    {
        SelectFrame = GameObject.Find("selectFrame");
        btn = GetComponent<Button>();
        childImage = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setImageSet(SC_ButtonSet buttonSet,int ij)
    {
        myId = ij;
        int i = 0;
        childImage = GetComponentsInChildren<Image>();
        foreach (var item in childImage)
        {
            if (i == 0) { i++;  continue; }
            if (item.name == "selectFrame") continue;
            item.sprite = buttonSet.imgSet[i-1];
            i++;
        }

        SelectFrame = GameObject.Find("selectFrame");
        btn = GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate {
            SoundManager.Instance.playOneShot(8);
            PlayerPrefs.SetInt("ButtonSets", myId);
            SelectFrame.transform.parent = transform;
            SelectFrame.transform.localPosition = Vector3.zero;
        });
    }

    public void setImageSet_v(SC_ButtonSet buttonSet, int ij)
    {
        myId = ij;
        int i = 0;
        childImage = GetComponentsInChildren<Image>();
        foreach (var item in childImage)
        {
            if (i == 0) { i++; continue; }
            if (item.name == "selectFrame") continue;
            item.sprite = buttonSet.imgSet[i - 1];
            i++;
        }
    }
}
