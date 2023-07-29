using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Int32 CalculateHealth(Player player)
    {
        //Fórmula: (resistence * 10) + (level * 4) + 10
        Int32 result = (player.entity.resistence * 10) + (player.entity.level * 4) + 10;
        Debug.LogFormat("CalculateHealth: {0}", result);
        return result;
    }
    public Int32 CalculateMana(Player player)
    {
        //Fórmula: (Intelligence * 10) + (level * 4) + 5
        Int32 result = (player.entity.intellingence * 10) + (player.entity.level * 4) + 5;
        Debug.LogFormat("CalculateMana: {0}", result);
        return result;
    }

    public Int32 CalculateStamina(Player player)
    {
        //Fórmula: (Resistence * Willpower) + (level * 4) + 5
        Int32 result = (player.entity.resistence + player.entity.willpower) + (player.entity.level * 2) + 5;
        Debug.LogFormat("CalculateStamina: {0}", result);
        return result;
    }

    public Int32 CalculateDamage(Player player, int weaponDamage)
    {
        //Fórmula: (str * 2) + (weapon DMG * 2) + (level * 3) + randon(1 - 20)
        System.Random rnd = new System.Random();
        Int32 result = (player.entity.strength * 2) + (weaponDamage * 2) + (player.entity.level * 2) + rnd.Next(1, 20);
        Debug.LogFormat("CalculateDamage: {0}", result);
        return result;
    }

    public Int32 CalculateDefense(Player player, int armorDefense)
    {
        //Fórmula: (endurance * 2) + (level * 3) + armorDefense
        System.Random rnd = new System.Random();
        Int32 result = (player.entity.resistence * 2) + (player.entity.level * 3) + armorDefense;
        Debug.LogFormat("CalculateDefense: {0}", result);
        return result;
    }
}
