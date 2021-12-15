using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[JsonObject(MemberSerialization.OptIn)]
public interface IHealthStateSwitcher{
    void SwitchState<T>() where T : HealthState;
}

public abstract class HealthState
{
    protected IHealthStateSwitcher _switcher;
    protected HealthContext _health;
    protected Player _player;
    protected Action<string, string> _status;

    protected const int SECONDS_FOR_INFITITY = 60 * 60;
    protected const int SECONDS_FOR_HEAL = 30*60;
    public HealthState(IHealthStateSwitcher switcher, HealthContext health,Player player, Action<string, string> status)
    {
        _switcher = switcher;
        _health   = health;
        _player   = player;
        _status = status;
    }
    public abstract void Update();
    public abstract void Start(); 
    public abstract void Stop();
    public abstract bool IsALive();
    public abstract void Hit();
    public abstract void Heal();
}
