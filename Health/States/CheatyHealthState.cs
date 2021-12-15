using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[JsonObject(MemberSerialization.OptIn)]
public class CheatyHealthState : HealthState
{
    public CheatyHealthState(IHealthStateSwitcher switcher, HealthContext health,Player player, HealthDataContext data, Action<string, string> status) : base(switcher, health, player,status)
    {

    }

    public override void Heal()
    {
        _player.Heal(1);
    }
    public override void Hit()
    {
        return;
    }
    public override bool IsALive()
    {
        return true;
    }
    public override void Start()
    {
        return;
    }
    public override void Stop()
    {
        return;
    }
    public override void Update()
    {
        _status?.Invoke("∞", "Cheats");
        return;
    }
}
