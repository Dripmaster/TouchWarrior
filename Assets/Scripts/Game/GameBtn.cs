using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtn : MonoBehaviour
{
    IconBtn iconBtn;
    IconDisplay iconDisplay;
    public bool isFlipcorrect;
    // Start is called before the first frame update
    void Start()
    {
        iconBtn = GetComponentInChildren<IconBtn>();
        iconDisplay = GetComponentInChildren<IconDisplay>();
        isFlipcorrect = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlipEnd()
    {

    }
    public void Flipok()
    {
        if(iconBtn != null)
        {
            iconBtn.FlipOk();
        }
        else
        {
            iconDisplay.flipOk(isFlipcorrect);
            isFlipcorrect = false;
        }
    }
    public void DestroyOk()
    {
        gameObject.SetActive(false);
    }
}
