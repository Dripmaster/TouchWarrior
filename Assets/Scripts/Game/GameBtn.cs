using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtn : MonoBehaviour
{
    IconBtn iconBtn;
    IconDisplay iconDisplay;

    // Start is called before the first frame update
    void Start()
    {
        iconBtn = GetComponentInChildren<IconBtn>();
        iconDisplay = GetComponentInChildren<IconDisplay>();
    }

    // Update is called once per frame
    void Update()
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
            iconDisplay.flipOk();
        }
    }
    public void DestroyOk()
    {

    }
}
