using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void WeaponShoot();
}
public class SimpleWeapon : MonoBehaviour, IWeapon
{
    public void WeaponShoot()
    {
        print("shooting");
    }
}
