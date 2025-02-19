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
    }
    protected virtual Vector3 GetDirectionByKeyboard()
    {
        direction.x = 0;
        direction.y = 0;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) direction.x = 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) direction.x = -1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) direction.y = 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) direction.y = -1;

        //if (this.direction.x !=0) Debug.Log("Left");
        //if (this.direction.y != 0) Debug.Log("Right");
        //if (this.direction.z != 0) Debug.Log("Top");
        //if (this.direction.w != 0) Debug.Log("Down");
        return direction;
    }

    public virtual bool GetSignalsByMouse()
    {
        mouseClick = Input.GetMouseButtonDown(0);
        return mouseClick;
    }
}
