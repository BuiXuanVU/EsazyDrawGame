using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioCtrl : ComponentBehaviuor
{
    private static AudioCtrl instance;
    public static AudioCtrl Instance { get { return instance; } }
    [SerializeField] private List<AudioClip> audios;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource drawSource;
    public bool isMute = true;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAudioSource();
    }
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    protected override void Start()
    {
        base.Start();
        PlaySoundtrack();
        LoadDrawSource();
    }
    private void LoadAudioSource()
    {
        if (audioSource != null) return; 
        audioSource = GetComponent<AudioSource>();
    }
    private void LoadDrawSource()
    {
        if (drawSource != null) return;
        drawSource = GetComponent<AudioSource>();
    }
    public void PlaySoundtrack()
    {
        audioSource.clip = audios[0];
        audioSource.Play();
    }
    public void DrawSound()
    {
        audioSource.Stop();
        if(drawSource.isPlaying) { return; }
        drawSource.Play();
    }
    public void ClearSound()
    {
        drawSource.Stop();
    }    
    public void ClickButtonSound()
    {
        audioSource.clip = audios[2];
        audioSource.Play();
    }    
    public void ChangeFrameSound()
    {
        int audioCount = Random.Range(3, 4);
        audioSource.clip = audios[audioCount];
        audioSource.Play();
    }
    public void PraiseSound()
    {
        int audioCount = Random.Range(5, 7);
        audioSource.clip = audios[audioCount];
        audioSource.Play();
    }
    public void MuteAudio()
    {
        if (isMute)
        {
            audioSource.mute = true;
            drawSource.mute = true;
            isMute = false;
        }
        else
        {
            audioSource.mute = false;
            drawSource.mute = false;
            isMute = false;
        }
    }    
}
