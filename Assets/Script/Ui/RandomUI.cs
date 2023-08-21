using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomUI : ComponentBehaviuor
{
    [SerializeField] private Sprite[] textUI;
    [SerializeField] private Sprite[] emojiUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextUISprite();
        LoadEmojiUISprite();
    }
    private void LoadTextUISprite()
    {
        if (textUI.Length > 0) return;
        var text = Resources.LoadAll("CongratUI/Text/", typeof(Sprite)).Cast<Sprite>().ToArray();
        textUI = text.ToArray();
    }
    private void LoadEmojiUISprite()
    {
        if (emojiUI.Length > 0) return;
        var icon = Resources.LoadAll("CongratUI/Emoji/", typeof(Sprite)).Cast<Sprite>().ToArray();
        emojiUI = icon.ToArray();
    }
    public Sprite GetCongratText()
    {
        return textUI[GetRandom(textUI.Length)];
    }
    public Sprite GetCongratEmojit()
    {
        return emojiUI[GetRandom(emojiUI.Length)];
    }
    private int GetRandom(int lenght)
    {
        return Random.Range(0, lenght);
    }
}
