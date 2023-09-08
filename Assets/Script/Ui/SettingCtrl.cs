using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingCtrl : ComponentBehaviuor
{
    [SerializeField] private List<Sprite> MusicIconSprite;
    [SerializeField] private Image MusicButton;
    [SerializeField] private Image SounDrawButton;
    [SerializeField] private TextMeshProUGUI MusicText;
    [SerializeField] private TextMeshProUGUI SounDrawText;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMusicIcon();
        loadButton();
        loadTextButton();
    }
    private void LoadMusicIcon()
    {
        if (MusicIconSprite.Count > 0) return;
        var sprite = Resources.LoadAll("SettingMusic/", typeof(Sprite)).Cast<Sprite>().ToArray();
        for (int i = 0; i < sprite.Length; i++)
        {
            MusicIconSprite.Add(sprite[i]);
        }
    }
    private void loadButton()
    {
        if(MusicButton == null)
            MusicButton = transform.GetChild(2).GetComponent<Image>();
        if (SounDrawButton == null)
            SounDrawButton = transform.GetChild(3).GetComponent<Image>();
        else
            return;
    }
    private void loadTextButton()
    {
        if (MusicText != null) return;
        MusicText = transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
        if (SounDrawText != null) return;
        SounDrawText = transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>();
    }
    public void CloseDialog()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync(3);
    }
    public void ButtonMuteClick()
    {
        if (AudioCtrl.Instance.isMute)
        {
            AudioCtrl.Instance.MuteAudio();
            MusicButton.sprite = MusicIconSprite[2];
            MusicText.text = "OFF";
        }
        else
        {
            AudioCtrl.Instance.MuteAudio();
            MusicButton.sprite = MusicIconSprite[3];
            MusicText.text = "ON";
        }
    }
    public void ButtonSoundClick()
    {
        if (AudioCtrl.Instance.isSoundMute)
        {
            AudioCtrl.Instance.MuteDrawAudio();
            SounDrawButton.sprite = MusicIconSprite[0];
            SounDrawText.text = "OFF";
        }
        else
        {
            AudioCtrl.Instance.MuteDrawAudio();
            SounDrawButton.sprite = MusicIconSprite[1];
            SounDrawText.text = "ON";
        }
    }
    public void LoadArtGalley()
    {
        SceneManager.LoadScene(1);
    }
}
