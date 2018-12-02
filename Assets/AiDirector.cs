using System.Collections;
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

    private void Start()
    {
        sheepsAI = new List<SheepAI>(FindObjectsOfType<SheepAI>());
        playerInput = FindObjectOfType<PlayerInput>();
        sheepsAI = Extensions.ShuffleList(sheepsAI);
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
