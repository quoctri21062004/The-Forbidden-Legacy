using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCtrl : ShootableObjectCtrl
{
    protected override string GetObjectTypeString()
    {
       return ShootableObjsType.Drone.ToString();
    }
}
