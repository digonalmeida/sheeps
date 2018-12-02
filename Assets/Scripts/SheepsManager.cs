using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SheepsManager : Singleton<SheepsManager>
{
    [HideInInspector] public List<SheepState> allSheeps = new List<SheepState>();

    public SheepConfig[] configsToStart;
    public GameObject sheepPrefab;
    public string sheepDieNotificationMessageKey;

    protected override void Awake()
    {
        base.Awake();

        InstantiateSheeps(configsToStart);
    }

    public void InstantiateSheeps(SheepConfig[] sheepsToSpawn)
    {
        foreach (SheepConfig config in sheepsToSpawn)
        {
            GameObject go = Instantiate(sheepPrefab, Vector3.zero, Quaternion.identity);
            SheepState sheep = go.GetComponent<SheepState>();
            sheep.SetupSheep(config);
            allSheeps.Add(sheep);
        }
    }

    public SheepConfig GetSheepConfigById(int id)
    {
        SheepState[] sheeps = allSheeps.Where(s => s.config.Id == id).ToArray();
        if (sheeps.Length != 1)
        {
            Debug.LogError(sheeps.Length <= 0 ? "Sheep " + id + " not found." : "More than one sheep with id " + id);
            return null;
        }
        else
        {
            return sheeps[0].config;
        }
    }

    public void NotificateSheepDied(SheepState sheep)
    {
        NotificationBlob notif = new NotificationBlob(sheep.config.Id, sheepDieNotificationMessageKey);
        NotificationsManager.Instance.AddNotification(notif);
    }

    public void ResetManager()
    {
        allSheeps.Clear();
    }

}