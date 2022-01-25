using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionScene : MonoBehaviour
{
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = ""+SaveManager.getData("gold");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
