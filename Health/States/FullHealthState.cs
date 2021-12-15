using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealthState : HealthState
{
    public FullHealthState(IHealthStateSwitcher switcher, HealthContext health, Player player, HealthDataContext data, Action<string, string> status) : base(switcher, health, player,status)
    {

    }
    public override void Heal()
    {
        return;
    }
    public override void Hit()
    {
        _player.Hit(1);
        _switcher.SwitchState<HealingHealthState>();
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
        _status?.Invoke("5", "ALL");
        if (_player.Health < 5)
            _switcher.SwitchState<HealingHealthState>();
        return;
    }
}
