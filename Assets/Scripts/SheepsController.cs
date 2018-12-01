using System.Collections.Generic;
using UnityEngine;

public class SheepsController : Singleton<SheepsController>
{
    [HideInInspector] public List<SheepState> allSheeps = new List<SheepState>();

    public SheepConfig[] configsToStart;
    public GameObject sheepPrefab;

    protected override void Awake(){
        base.Awake();

        foreach (SheepConfig config in configsToStart)
        {
            GameObject go = Instantiate(sheepPrefab,Vector3.zero,Quaternion.identity);
            SheepState state = go.GetComponent<SheepState>();
            state.SetupSheep(config);
        }
    }

    private void Start(){
        Dictionary<messageType, float> messageTypesStart = new Dictionary<messageType, float>();
        messageTypesStart.Add(messageType.greeting,0.3f);
        messageTypesStart.Add(messageType.shitpost,0.4f);
        MessageFlowController.Instance.ChangeCurrentMessageTypes(messageTypesStart);
        MessageFlowController.Instance.StartMessaging();
    }

}