using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthDataContext {

    [JsonProperty] public DateTime Healing = DateTime.Now;
    [JsonProperty] public DateTime Cheaty = DateTime.Now;
    [JsonProperty] public DateTime Inf = DateTime.Now;
    [JsonProperty] public string State = "FullHealthState";
}
public class HealthContext : MonoBehaviour, IHealthStateSwitcher
{
    public Action<string, string> OnHealthChanged;
    [SerializeField] SaveSystem _save;
    public Player _player { get; private set; }
    private HealthDataContext _data;


    private HealthState _currentState;
    private List<HealthState> _states;
    private void Start()
    {
        var data = _save.Load<HealthDataContext>();
        var player = _save.Load<Player>();
        if (data.IsNull() || player.IsNull())
        {
            _player = new Player();
            _data = new HealthDataContext();
        }
        else
        {
            _data = data;
            _player = player;
        }

        _states = new List<HealthState>()
        {
            new FullHealthState           (this,this,_player,_data,OnHealthChanged),
            new InfinityHealthState       (this,this,_player,_data,OnHealthChanged),
            new CheatyHealthState         (this,this,_player,_data,OnHealthChanged),
            new HealingHealthState        (this,this,_player,_data,OnHealthChanged),
            new DoubleInfinityHealthState (this,this,_player,_data,OnHealthChanged),
        };
        _currentState = _states.Find(x=>x.GetType().Name==_data.State);
        if (_currentState is InfinityHealthState)
            _currentState = _states.Find(x => x is HealingHealthState);
        StartCoroutine(AutoSave());
    }
    private void Update()
    {
        _currentState.Update();
    }
    public void Hit()
    {
        _currentState.Hit();
    }
    public void Heal()
    {
        _currentState.Heal();
    }
    public bool IsAlive => _currentState.IsALive();
    public void SwitchState<T>() where T : HealthState
    {
        _currentState.Stop(); 
        var state = _states.First(x=> x is T);

        _currentState = state;
        _data.State = state.GetType().Name;
        _currentState.Start();
        Save();
    }
    private IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Save();
        }
    }
    private void Save()
    {
        _save.Save(_player);
        _save.Save(_data);
    }
}
