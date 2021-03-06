﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDirector : Singleton<AiDirector>
{
    private List<SheepAI> sheepsAI;

    [SerializeField]
    private float _playerAttackers = .1f;

    [SerializeField]
    private float _anyAttackers = .2f;

    void Start()
    {
        GameEvents.Sheeps.OnSheepAttack += OnSheepAttack;
        GameEvents.Sheeps.SheepDied += OnSheepDied;
    }

    public void Initialize(float playerAttackers, float anyAttackers)
    {
        this._playerAttackers = playerAttackers;
        this._anyAttackers = anyAttackers;

        sheepsAI = new List<SheepAI>(FindObjectsOfType<SheepAI>());

        sheepsAI = Extensions.ShuffleList(sheepsAI);

        GameEvents.Sheeps.OnSheepAttack += OnSheepAttack;
        GameEvents.Sheeps.SheepDied += OnSheepDied;

        InitializeSheepsStrategy();
    }

    private void OnDestroy()
    {
        GameEvents.Sheeps.OnSheepAttack -= OnSheepAttack;
        GameEvents.Sheeps.SheepDied -= OnSheepDied;
    }

    public void OnSheepDied(SheepConfig config)
    {
        InitializeSheepsStrategy();
    }

    public void RemoveDeadSheeps()
    {
        var newList = new List<SheepAI>();
        foreach (var sheep in sheepsAI)
        {
            if (sheep.GetComponent<SheepState>().isDead)
            {
                continue;
            }
            newList.Add(sheep);
        }
        sheepsAI = newList;
    }

    public void OnSheepAttack(GameObject s1, GameObject s2)
    {
        var ai = s2.GetComponent<SheepAI>();

        if (ai != null)
        {
            ai.SetRevenge(s1);
        }
    }

    private List<E> ShuffleList<E>(List<E> inputList)
    {
        List<E> randomList = new List<E>();

        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = Random.Range(0, inputList.Count); //Choose a random object in the list
            randomList.Add(inputList[randomIndex]); //add it to the new, random list
            inputList.RemoveAt(randomIndex); //remove to avoid duplicates
        }

        return randomList; //return the new random list
    }

    public void ResetSheepsStrategy(){
        foreach( var sheep in sheepsAI)
        {
            sheep.CurrentStrategy = SheepAI.Strategy.Idle;
            sheep.SetIdle();

        }
    }
    public void InitializeSheepsStrategy()
    {
        int playerAttackers = Mathf.CeilToInt(_playerAttackers * sheepsAI.Count);
        int anyAttackers = Mathf.CeilToInt(_playerAttackers * sheepsAI.Count);

        int i = 0;

        for (; i < playerAttackers; i++)
        {
            if (i >= sheepsAI.Count)
            {
                return;
            }
            sheepsAI[i].SpecialTarget = PlayerInput.Instance.gameObject;
            sheepsAI[i].CurrentStrategy = SheepAI.Strategy.AttackPlayer;
        }

        for (; i < playerAttackers + anyAttackers; i++)
        {
            if (i >= sheepsAI.Count)
            {
                return;
            }
            sheepsAI[i].CurrentStrategy = SheepAI.Strategy.AttackAny;
        }
    }
}
