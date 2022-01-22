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
            transform.position = GameManager.Instance.BtnPositions[i].position;
        else
        {
            StartCoroutine(moveAnim(GameManager.Instance.BtnPositions[i].position));
        }
    }
    public void FlipIcon(bool clear = false)
    {
       //StopAllCoroutines();
        StartCoroutine(flipAnim());
    }
    IEnumerator moveAnim(Vector3 targetPos)
    {
        Vector3 tmpPos = transform.position;
        float dt = 0;
        do
        {
            yield return null;
            dt += Time.deltaTime;
            transform.position = Vector3.Lerp(tmpPos, targetPos, dt);
            if (dt >= 1)
            {
                transform.position = targetPos;
                break;
            }
        } while (true);
    }

    IEnumerator flipAnim()
    {
        Vector3 tempScale = transform.localScale;
        int scaleDir = -1;
        do
        {
            yield return null;

            Vector3 targetScale = transform.localScale;
            targetScale.x +=scaleDir* 0.1f * Time.deltaTime*30f;
            transform.localScale = targetScale;
            if (transform.localScale.x <= 0f)
            {
                image.sprite = GameManager.Instance.GetBackSprite();
                scaleDir *= -1;
                break;
            }
        } while (true);

        do
        {
            yield return null;

            Vector3 targetScale = transform.localScale;
            targetScale.x += scaleDir * 0.1f * Time.deltaTime * 30f;
            transform.localScale = targetScale;
            if (transform.localScale.x >= 1f)
            {
                transform.localScale = tempScale;
                break;
            }
        } while (true);
    }
}
