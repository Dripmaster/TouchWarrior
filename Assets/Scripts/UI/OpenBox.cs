using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBox : MonoBehaviour
{
    public CollectionItem cool;
    public Animator openAnim;
    public ButtonSetArray buttonSet;
    public Text Gold;
    public Button OpenBtn1;
    public Button OpenBtn2;
    // Start is called before the first frame update
    void Start()
    {
        int g = SaveManager.getData("gold", 1000);
        Gold.text = "" + g;
        if (g < 100)
        {
            OpenBtn1.interactable = false;
            OpenBtn2.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openOk()
    {
        SoundManager.Instance.playOneShot(9,0.3f);
        
    }

    public void Btn_Open()
    {
        int g = SaveManager.getData("gold", 1000);
        g -= 100;
        SaveManager.saveData("gold",g);

        openAnim.SetTrigger("Open");
        SoundManager.Instance.playOneShot(8);
        SoundManager.Instance.playOneShot(7);
        int rand = Random.Range(1, 101);
        int rId = 0;
        if (rand > 95)
        {
            rId = 14;
        }
        else if (rand > 90)
        {

            rId = Random.Range(11,14);
        }
        else
        {

            rId = Random.Range(0, 11);
        }

        cool.setImageSet_v(buttonSet.buttonSets[rId],rId);
        PlayerPrefs.SetInt("IsButtonSets" + rId, 1);

        Gold.text = "" + g;
        if (g < 100)
        {
            OpenBtn1.interactable = false;
            OpenBtn2.interactable = false;
        }
    }

}
