using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBtn : MonoBehaviour
{
    public int imageId;
    Image image;
    Button button;
    // Start is called before the first frame update
    void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        setImage(imageId);

        button = GetComponent<Button>();
        button.onClick.AddListener(() => GameManager.Instance.onBtnClicked(imageId));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setImage(int i)
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        imageId = i;
        image.sprite = GameManager.Instance.GetSprite(i);
    }
}
