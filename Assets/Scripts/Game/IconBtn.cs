using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBtn : MonoBehaviour
{
    public int imageId;
    public int PosId;
    Image image;
    Button button;
    bool isFlip;
    // Start is called before the first frame update
    void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        setImage(imageId);
        setPos(PosId);
        GameManager.Instance.setOccupied(PosId,true);
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
        if(image.sprite == null)
            image.enabled =  false;
    }
    public void setPos(int i,bool anim = false)
    {
        if(!anim)
            transform.parent.position = GameManager.Instance.BtnPositions[i].position;
        else
        {
            StartCoroutine(moveAnim(GameManager.Instance.BtnPositions[i].position));
        }
    }
    public void FlipIcon(bool clear = false)
    {
       //StopAllCoroutines();
        StartCoroutine(flipAnim(clear));
        isFlip = !clear;
    }
    public void FlipOk()
    {
        if (isFlip)
        {
            image.sprite = GameManager.Instance.GetBackSprite();
        }
        else
        {
            image.sprite = GameManager.Instance.GetSprite(imageId);
        }
    }
    IEnumerator moveAnim(Vector3 targetPos)
    {
        Vector3 tmpPos = transform.position;
        float dt = 0;
        do
        {
            yield return null;
            dt += Time.deltaTime*2;
            transform.parent.position = Vector3.Lerp(tmpPos, targetPos, dt);
            if (dt >= 0.5f)
            {
                transform.parent.position = targetPos;
                break;
            }
        } while (true);
    }

    IEnumerator flipAnim(bool clear)
    {
        GetComponentInParent<Animator>().SetTrigger("Flip");
        yield return null;
    }
}
