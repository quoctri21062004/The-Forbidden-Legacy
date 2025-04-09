using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : TrisMonoBehaviour
{
    [Header("Weapon Rotation")]
    [SerializeField] protected Transform model;

    protected virtual void Update()
    {
        this.UpdateWeaponRot();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if(model!=null)return;
        model = transform.parent.GetComponentInChildren<Transform>();
    }
    protected virtual void UpdateWeaponRot()
    {
        Vector3 mousePos = InputManager.Instance.GetMousePos();
        Vector3 direction = mousePos - transform.parent.position;

        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        if (angle > 90 || angle < -90)
        {
            Vector3 scale = model.localScale;
            scale.y = -1;
            model.localScale = scale;
        }
        else
        {
            Vector3 scale = model.localScale;
            scale.y = 1;
            model.localScale = scale;
        }
            model.rotation =Quaternion.Euler(0f,0f,angle);
    }
}
