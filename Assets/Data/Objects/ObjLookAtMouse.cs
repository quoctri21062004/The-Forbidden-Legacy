using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtMouse : TrisMonoBehaviour
{
    //[Header("Obj Look At Mouse")]
    
    protected virtual void FixedUpdate()
    {

        this.ObjRotToMouse();
    }

    protected virtual void ObjRotToMouse()
    {
        Vector3 mousePos = InputManager.Instance.GetMousePos();
        Vector3 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        transform.parent.rotation=Quaternion.Euler(0f, 0f, angle);
        if (angle > 90f || angle < -90f)
        {
            transform.parent.localScale = new Vector3(1,-1, 1);
        }
        else
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }
    }
}
