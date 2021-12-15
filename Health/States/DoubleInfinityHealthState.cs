using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleInfinityHealthState : HealthState
{
    private HealthDataContext _data;
    public DoubleInfinityHealthState(IHealthStateSwitcher switcher, HealthContext health, Player player, HealthDataContext data, Action<string, string> status) : base(switcher, health, player, status)
    {
        _data = data;
    }
    public override void Heal()
    {
        return;
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
        _data.Inf = DateTime.Now;
    }
    public override void Stop()
    {

    }

    public override void Update()
    {
        var seconds = CountSecondsFrom(_data.Inf);

        if (seconds >= 2 * SECONDS_FOR_INFITITY)
        {
            var seconds2 = CountSecondsFrom(_data.Healing) - 2*SECONDS_FOR_INFITITY;

            if (seconds2 >= SECONDS_FOR_HEAL)
            {
                int n = (int)((float)seconds2 / (float)SECONDS_FOR_HEAL);
                _player.Heal(n);
                _data.Healing = DateTime.Now;
            }
            _data.Inf = DateTime.Now;
            _switcher.SwitchState<HealingHealthState>();
        }
        var z = new TimeSpan(0, 0, 2 * SECONDS_FOR_INFITITY - seconds);
        if ((int)z.TotalMinutes > 100)
        {
            _status?.Invoke("∞", $"{z.ToString(@"hh\:mm")}");
        }
        else
        {
            _status?.Invoke("∞", $"{z.Hours * 60 + z.Minutes}:{z.Seconds}");
        }
        
    }
    private int CountSecondsFrom(DateTime from, DateTime to)
    {
        return (int)((from - to).TotalSeconds);
    }
    private int CountSecondsFrom(DateTime to)
    {
        return CountSecondsFrom(DateTime.Now, to);
    }
}
