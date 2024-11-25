using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDataStore
{
    private static PlayerHealthDataStore _playerHealthDataStore;
    private int _currentHealth;
    private bool _isPlayerDead;
    private int _minHealth = 1;
    private int _maxHealth = 10;
    private int _defaultHealthDamageWorth = 2;
    private int _defaultHealthRestoreWorth = 2;

    public static PlayerHealthDataStore getInstance()
    {
        if (_playerHealthDataStore == null)
        {
            _playerHealthDataStore = new PlayerHealthDataStore();
            _playerHealthDataStore.init();
            
        }

        return _playerHealthDataStore;
    }

    private void init()
    {
        this._currentHealth = this._maxHealth;
        this._isPlayerDead = false;
    }

    public PlayerHealthDataStore increaseHealth()
    {
        int newHealth = this._currentHealth + this._defaultHealthRestoreWorth;

        if (newHealth > _maxHealth)
        {
            this._currentHealth = _maxHealth;
            return this;
        }

        this._currentHealth = newHealth;
        return this;
    }

    public PlayerHealthDataStore reduceHealth()
    {
        int newHealth = this._currentHealth - _defaultHealthDamageWorth;

        if (newHealth < _minHealth)
        {
            this._currentHealth = 0;
            this._isPlayerDead = true;
            return this;
        }

        this._currentHealth = newHealth;
        return this;
    }

    public int getCurrentHealth()
    {
        return this._currentHealth;
    }

    public int getMaxHealth()
    {
        return this._maxHealth;
    }

    public bool isPlayerDead()
    {
        return _isPlayerDead;
    }

    public PlayerHealthDataStore reset()
    {
        this.init();
        return this;
    }
}