using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWeaponPos : TrisMonoBehaviour
{
    [Header("Update Weapon Pos")]
    [SerializeField] protected Transform player;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if(player!=null)return;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.transform.GetComponent<Transform>();
    }
    protected virtual void UpdateWeaponPosition()
    {
        //Vector3 weaponPos = transform.position;
        //Vector3 directionPlayer = player.position;
        //Vector3 direction = directionPlayer - weaponPos;

        //Vector3 newPos = transform.localPosition;
        //newPos.x = Mathf.Abs(newPos.x) * (direction.x < 0 ? -1 : 1);

        //transform.position = newPos;
        if (player == null) return;

        Vector3 direction = player.position - transform.position;

        Vector3 newLocalPos = transform.localPosition;
        newLocalPos.x = Mathf.Abs(newLocalPos.x) * (direction.x < 0 ? -1 : 1);

        transform.localPosition = newLocalPos;
    }
}
