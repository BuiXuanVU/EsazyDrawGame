using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoadingUI : ComponentBehaviuor
{
    [SerializeField] private Animator loading;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
    }
    private void LoadAnimator()
    {
        if (loading != null) { return; }
        loading = GetComponentInChildren<Animator>();
    }    
    protected override void Start()
    {
        base.Start();
        if (loading.GetComponent<Animator>().isInitialized)
        {
            StartCoroutine(returnToMenu());
        }
    }
    IEnumerator returnToMenu()
    {
        yield return new WaitForSeconds(loading.GetCurrentAnimatorClipInfo(0)[0].clip.length);
        SceneManager.LoadScene(1);
    }
}
