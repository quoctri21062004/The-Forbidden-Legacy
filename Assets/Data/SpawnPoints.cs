using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPoints : TrisMonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.points.Add(point);
        }
    }

    public virtual Transform RandomPoint()
    {
        int rand = Random.Range(0,this.points.Count);
        return this.points[rand];
    }
}
