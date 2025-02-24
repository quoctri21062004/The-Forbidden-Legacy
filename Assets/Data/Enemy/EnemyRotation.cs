using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : TrisMonoBehaviour
{
    [Header("Enemy Rotation")]
    [SerializeField] protected Transform player;
    [SerializeField] protected Transform model;

    protected virtual void Update()
    {
        this.UpdateEnemyRot();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadModel();
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        GameObject playerG = GameObject.Find("Player");
        this.player = playerG.transform;
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.parent.Find("Model");
    }

    protected virtual void UpdateEnemyRot()
    {
        Vector3 direction = player.position - transform.position;

        if (direction.x < 0) model.localScale = new Vector3(Mathf.Abs(model.localScale.x), model.localScale.y, model.localScale.z); 
        else model.localScale = new Vector3(-Mathf.Abs(model.localScale.x), model.localScale.y, model.localScale.z);
    }
}
