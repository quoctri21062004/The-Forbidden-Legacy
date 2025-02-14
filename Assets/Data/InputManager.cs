using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : TrisMonoBehaviour
{
    [Header("InputManager")]

    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector4 direction;
    public Vector4 Direction => direction;

    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    protected virtual void Update()
    {
        this.GetDirectionByKeyboard();
    }
    protected virtual void GetDirectionByKeyboard()
    {
        this.direction.x = Input.GetKey(KeyCode.A) ? -1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;

        this.direction.y = Input.GetKey(KeyCode.D) ? 1 : 0;
        if (this.direction.y == 0) this.direction.y = Input.GetKey(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKey(KeyCode.W) ? 1 : 0;
        if (this.direction.z == 0) this.direction.z = Input.GetKey(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKey(KeyCode.S) ? -1 : 0;
        if (this.direction.w == 0) this.direction.w = Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

        //if (this.direction.x !=0) Debug.Log("Left");
        //if (this.direction.y != 0) Debug.Log("Right");
        //if (this.direction.z != 0) Debug.Log("Top");
        //if (this.direction.w != 0) Debug.Log("Down");
    }
}
