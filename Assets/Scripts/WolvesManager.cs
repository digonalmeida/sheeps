using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolvesManager : Singleton<WolvesManager>
{

    public WolfController wolfPrefab;
    public int wolvesToSpawn = 4;

    private WolfWaypoint[] waypoints;
    private WolfExitWaypoint[] exitWaypoints;
    private List<WolfController> wolvesSpawned = new List<WolfController>();

    protected override void Awake()
    {
        base.Awake();

        waypoints = FindObjectsOfType<WolfWaypoint>();
        exitWaypoints= FindObjectsOfType<WolfExitWaypoint>();
    }

    private void Start()
    {
        SpawnWolves(wolvesToSpawn);
    }

    private void SpawnWolves(int numberWolves)
    {
        for (int i = 0; i < numberWolves; i++)
        {
            wolvesSpawned.Add(Instantiate(wolfPrefab, waypoints[Random.Range(0, waypoints.Length)].transform.position, Quaternion.identity));
        }
    }

    public void NotifyWolves(SheepState sheep)
    {
        for (int i = 0; i < wolvesSpawned.Count; i++)
        {
            wolvesSpawned[i].FollowSheep(sheep);
        }
    }

    public void HideWolves(){
        for (int i = 0; i < wolvesSpawned.Count; i++)
        {
            wolvesSpawned[i].Exit(exitWaypoints[Random.Range(0,exitWaypoints.Length)]);
        }
    }

}
