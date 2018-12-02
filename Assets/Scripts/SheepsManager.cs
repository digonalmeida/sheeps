using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SheepsManager : Singleton<SheepsManager>
{

    public static List<SheepState> allSheepsStatic = new List<SheepState>();
    [HideInInspector] public List<SheepState> allSheeps = new List<SheepState>();

    public List<Transform> spawnPoints;
    public SheepConfig[] sheepConfigsToStart;
    public GameObject sheepPrefab;
    public string sheepDieNotificationMessageKey;

    protected override void Awake()
    {
        base.Awake();

        spawnPoints = Extensions.ShuffleList(spawnPoints);
        
        for (int i = 0; i < sheepConfigsToStart.Length; i++)
        {
            SheepConfig config = sheepConfigsToStart[i];
            GameObject go = Instantiate(sheepPrefab, spawnPoints[i].position, Quaternion.identity, transform);
            SheepState sheep = go.GetComponent<SheepState>();
            sheep.SetupSheep(config);
            allSheeps.Add(sheep);
        }

    }

    private void Initialize()
    {

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
        GameEvents.Sheeps.SheepDied.SafeInvoke(sheep.config);
        NotificationBlob notif = new NotificationBlob(sheep.config.Id, sheepDieNotificationMessageKey);
        NotificationsManager.Instance.AddNotification(notif);
    }

    public void ResetManager()
    {
        allSheeps.Clear();
    }

}