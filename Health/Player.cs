using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[JsonObject(MemberSerialization.OptIn)]
public class Player 
{
    public Action<int> OnAlive;
    [JsonProperty] public int Health { get; private set; } = 5;
    public void Hit(int value)
    {
        Health -= value;
        if (Health < 0)
            Health = 0;
        if (Health >= 1)
        {
            OnAlive?.Invoke(Health);
        }
    }
    public void Heal(int value)
    {
        Health += value; 
        if (Health > 5)
            Health = 5; 
        if (Health >= 1)
        {
            OnAlive?.Invoke(Health);
        }
    }
}
