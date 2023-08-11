using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RandomUI : ComponentBehaviuor
{
    [SerializeField] private Sprite[] textUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSprite();
    }
    private void LoadSprite()
    {
        if (textUI.Length > 0) return;
        var text = Resources.LoadAll("CongratUI/Text/", typeof(Sprite)).Cast<Sprite>().ToArray();
        textUI = text.ToArray();
    }
    public Sprite GetCongratText()
    {
        return textUI[GetRandom()];
    }
    private int GetRandom()
    {
        return Random.Range(0, textUI.Length-1);
    }
}
