﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDirector : MonoBehaviour
{
    private List<SheepAI> sheepsAI;
    private PlayerInput playerInput;

    [SerializeField]
    private float _playerAttackers = .1f;

    [SerializeField]
    private float _anyAttackers = .2f;

    private void Awake()
    {
        sheepsAI = new List<SheepAI>(FindObjectsOfType<SheepAI>());
        playerInput = FindObjectOfType<PlayerInput>();
        sheepsAI = ShuffleList(sheepsAI);
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

    private void Start()
    {
        InitializeSheepsStrategy();
    }

    public void InitializeSheepsStrategy()
    {
        int playerAttackers = Mathf.CeilToInt(Mathf.Max(_playerAttackers * sheepsAI.Count, 1));
        int anyAttackers = Mathf.CeilToInt(Mathf.Max(_playerAttackers * sheepsAI.Count, 2));

        Debug.Log(playerAttackers);
        int i = 0;

        for (; i < playerAttackers; i++)
        {
            if (i >= sheepsAI.Count)
            {
                return;
            }
            sheepsAI[i].SpecialTarget = playerInput.gameObject;
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
