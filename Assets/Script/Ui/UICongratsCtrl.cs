using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICongratsCtrl : CongratsTextImageCtrl
{
    [SerializeField] protected Image icon;
    [SerializeField] protected List<GameObject> partical;
    private int temp;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadListPartical();
        LoadIcon();
        LoadTextImage();
    }
    private void LoadListPartical()
    {
        for(int i = 0;i<3;i++)
        {
            partical.Add(transform.GetChild(i).gameObject);
        }
    }
    private void LoadIcon()
    {
        if (icon != null) return;
        icon = transform.GetChild(3).GetComponent<Image>();
    }
    private void LoadTextImage()
    {
        if (textSprite != null) return;
        textSprite = transform.GetChild(4).GetComponent<Image>();
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(DoShake());
    }
    IEnumerator DoShake()
    {
        icon.sprite = UIManager.Instance.RandomUI.GetCongratEmojit();
        GetParical(icon.sprite.name);
        if(temp == 2 )
        {
            partical[temp].SetActive(true);
            partical[temp].transform.Rotate(0, 0, 2);
        }
        else
        {
            partical[temp].SetActive(true);
        }
        SkadeImage(icon.transform);
        yield return new WaitForSeconds(1);
        partical[temp].SetActive(false);
        gameObject.SetActive(false);
    }
    private void GetParical(string nameIcon)
    {
        if (nameIcon == "drool 1")
            temp = 0;
        if (nameIcon == "heart_1 1")
            temp = 0;
        if (nameIcon == "shocked 1")
            temp = 2;
        if (nameIcon == "starstruck 1")
            temp = 1;
    }
}
