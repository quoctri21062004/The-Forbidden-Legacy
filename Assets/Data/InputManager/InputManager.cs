using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : TrisMonoBehaviour
{
    [Header("InputManager")]

    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector3 direction;
    public Vector4 Direction => direction;

    [SerializeField] protected bool mouseClick = false;
    public bool MouseClick => mouseClick;

    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos => mousePos;
    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    protected virtual void Update()
    {
        this.GetDirectionByKeyboard();
        this.GetSignalsByMouse();
        this.GetReloadAmmo();
        this.GetChangeItem();
    }
    protected virtual Vector3 GetDirectionByKeyboard()
    {
        direction.x = 0;
        direction.y = 0;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) direction.x = 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) direction.x = -1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) direction.y = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) direction.y = -1;

        return direction;
    }

    public virtual bool GetSignalsByMouse()
    {
        mouseClick = Input.GetMouseButtonDown(0) || Input.GetMouseButton(0);
        return mouseClick;
    }

    public virtual Vector3 GetMousePos()
    {
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    public virtual bool GetReloadAmmo()
    {
        if (Input.GetKeyDown(KeyCode.R)) return true;
        return false;
    }

    public virtual void GetChangeItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Debug.Log("DA CHUYEN SANG DUNG KIEM");
        if (Input.GetKeyDown(KeyCode.Alpha2)) Debug.Log("DA CHUYEN SANG DUNG SUNG");
        if (Input.GetKeyDown(KeyCode.Alpha3)) Debug.Log("DA SU DUNG ITEM HOI MAU");
    }
}
