using System;
using UnityEngine;

public class HealPointsManager : MonoBehaviour
{
    [SerializeField] private int _healPoints = 100;
    [SerializeField] private int _armorPoints = 100;

    public int GetHP()
    {
        return _healPoints;
    }
    public int GetArmorPoints()
    {
        return _armorPoints;
    }


    private void Update()
    {
        if(_healPoints <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        throw new NotImplementedException();
    }

    public void TakeArmorPoints(int armorPoints)
    {
        int tmpPoints = Mathf.Abs(armorPoints);
        _armorPoints += tmpPoints;
    }

    public void TakeHealPoints(int healPoints)
    {
        int tmpPoints = Mathf.Abs(healPoints);
        _healPoints += tmpPoints;
    }

    public void TakeDamage(int damage)
    {
        float tmpDamage = damage;
        _armorPoints -= (int)Math.Floor(damage * 0.6f);
        _healPoints -= (int)Math.Floor(damage * 0.3f);
        if(_armorPoints <= 0)
        {
            _healPoints += _armorPoints;
            _armorPoints = 0;
        }
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadDataHNA();

        _healPoints = data.healPoints;
        _armorPoints = data.armorPoints;
    }
}
