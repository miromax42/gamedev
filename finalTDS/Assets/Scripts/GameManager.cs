using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public int ratHealth = 0;
    #region Player params and funcs
    [NonSerialized] public Transform PlayerPosition=null;
    public float _playerHealth = 100;
    public float PlayerHealth
    {
        get
        {
            return _playerHealth;
        }
        set
        {
            OnPlayerHealthChanged(value);
            _playerHealth = value;
        }

    }
    public float _playerMoveSpeed;
    public float PlayerMoveSpeed
    {
        get
        {
            return _playerMoveSpeed;
        }
        set
        {
            OnPlayerMoveSpeedChanged(value);
            _playerMoveSpeed = value;
        }
    }
    public float _playerRotationSpeed;
    public float PlayerRotationSpeed
    {
        get
        {
            return _playerRotationSpeed;
        }
        set
        {
            OnPlayerRotationSpeedChanged(value);
            _playerRotationSpeed = value;
        }
    }
    [NonSerialized] public bool _playerFireIsActive;
    public bool PlayerFireIsActive
    {
        get
        {
            return _playerFireIsActive;
        }
        set
        {
            OnPlayerFireStateChange(value);
            _playerFireIsActive = value;
        }
    }
    public void OnPlayerHealthChanged(object value=null)
    {
        //
    }
    public void OnPlayerRotationSpeedChanged(object value = null)
    {

    }
    public void OnPlayerMoveSpeedChanged(object value = null)
    {

    }
    public void OnPlayerFireStateChange(object value = null)
    {

    }

    #endregion
    #region Weapon
    public float _weaponFireRateSpeed;
    public float WeaponFireRate
    {
        get
        {
            return _weaponFireRateSpeed;
        }
        set
        {
            OnWeaponFireRateChanged(value);
            _weaponFireRateSpeed = value;
        }
    }

    public float _weaponShotDamage;
    public float WeaponShotDamage
    {
        get
        {
            return _weaponShotDamage;
        }
        set
        {
            OnWeaponDamageChanged(value);
            _weaponShotDamage = value;
        }
    }

    private void OnWeaponDamageChanged(object value=null)
    {
        throw new NotImplementedException();
    }

    private void OnWeaponFireRateChanged(object value=null)
    {
        throw new NotImplementedException();
    }
    public float _bulletForce;
    public  float BulletForce
    {
        get
        {
            return _bulletForce;
        }
        set
        {
            OnBulletForceChanged(value);
            _bulletForce = value;
        }
    }

    public void OnBulletForceChanged(object value)
    {
        throw new NotImplementedException();
    }
    public float _bulletDamage;
    #endregion
    #region Enemies
    public float _enemyMeleeHealth, _enemyMeleeDamage, _enemyMeleeMoveSpeed;
    #endregion

}

