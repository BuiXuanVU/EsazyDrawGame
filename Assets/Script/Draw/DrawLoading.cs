using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLoading : ComponentBehaviuor
{
    [SerializeField] private List<Transform> loadingPoints;
    [SerializeField] private LineRenderer loading;
    [SerializeField] private Transform pen;
    float dinstance = 0 ;
    int i = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLoadingLine();
        LoadPoints();
    }
    private void LoadLoadingLine()
    {
        if (loading != null) return;
        loading = GetComponent<LineRenderer>();
    }
    private void LoadPoints()
    {
        if (loadingPoints.Count == transform.childCount) return;
        for (int i = 0; i < transform.childCount; i++)
            loadingPoints.Add(transform.GetChild(i));
    }

    private void Update()
    {
        if (i + 1 < loadingPoints.Count)
        {
            dinstance = Vector2.Distance(pen.position, loadingPoints[i + 1].position);
            MoveToPoint(loadingPoints[i + 1]);
            if (dinstance < 0.1f)
            {
                loading.positionCount = i + 2;
                loading.SetPosition(i, loadingPoints[i].position);
                loading.SetPosition(i + 1, loadingPoints[i + 1].position);
                i++;
            }
        }
        else
        {
            StartCoroutine(DelayToStart());
        }
    }
    private void MoveToPoint(Transform nextPos)
    {
        pen.position = Vector2.MoveTowards(pen.position, nextPos.position, 1*Time.deltaTime);
    }
    IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
