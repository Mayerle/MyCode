using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHealthState : HealthState
{
    private HealthDataContext _data;
    
    public HealingHealthState(IHealthStateSwitcher switcher, HealthContext health,Player player, HealthDataContext data, Action<string, string> status) : base(switcher, health, player,status)
    {
        _data = data;
    }
    public override void Heal()
    {
        _player.Heal(1);
    }
    public override void Hit()
    {
        _player.Hit(1);
    }
    public override bool IsALive()
    {
        return _player.Health > 0;
    }
    public override void Start()
    {
        _data.Healing = DateTime.Now;
        if (_player.Health == 5)
            _switcher.SwitchState<FullHealthState>();
    }
    public override void Stop()
    {
       
    }

    public override void Update()
    {
        var seconds = CountSecondsFrom(_data.Healing);

        if (seconds >= SECONDS_FOR_HEAL)
        {
            int n = (int)((float)seconds / (float)SECONDS_FOR_HEAL);
            _player.Heal(n);
            _data.Healing = DateTime.Now;
            if (_player.Health == 5)
                _switcher.SwitchState<FullHealthState>();
        }
        _status?.Invoke($"{_player.Health}", $"{ new TimeSpan(0, 0, SECONDS_FOR_HEAL-seconds).ToString(@"mm\:ss")}");
        
    }
    private int CountSecondsFrom(DateTime from,DateTime to)
    {
        return (int)((from-to).TotalSeconds);
    }
    private int CountSecondsFrom(DateTime to)
    {
        return CountSecondsFrom(DateTime.Now, to);
    }
}
