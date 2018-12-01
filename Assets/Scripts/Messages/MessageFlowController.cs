using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MessageFlowController : Singleton<MessageFlowController>
{

    private Dictionary<messageType, float> currentMessageTypes = new Dictionary<messageType, float>();
    private float currentMessagesTypesSum
    {
        get
        {
            return currentMessageTypes.Values.Sum();
        }
    }

    private float messagesPerSecondDefault = 1f;
    private float messagesPerSecondError = 0.2f;
    private float messagesPerSecond
    {
        get
        {
            return messagesPerSecondDefault * (1 + UnityEngine.Random.Range(-messagesPerSecondError, messagesPerSecondError));
        }
    }

    private float nextMessageTime;

    private float timer;
    private bool isMessaging = false;

    public void ChangeCurrentMessageTypes(Dictionary<messageType, float> newCurrentMessageTypes)
    {
        currentMessageTypes = newCurrentMessageTypes;
    }

    public void ChangeCurrentRate(float newRate)
    {
        messagesPerSecondDefault = newRate;
    }

    public void StartMessaging()
    {
        ResetTimer();
        isMessaging = true;
    }

    public void StopMessaging()
    {
        isMessaging = false;
    }

    private void Update()
    {

        if (isMessaging)
        {
            if (timer >= nextMessageTime)
            {
                // make message
                messageType msgType = RaffleMessageType();
                if (msgType != messageType.none) GetMessageFromType(msgType);

                // reset timer
                ResetTimer();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    private void ResetTimer()
    {
        nextMessageTime = messagesPerSecond;
        timer = 0;
    }

    private messageType RaffleMessageType()
    {
        float raffle = UnityEngine.Random.Range(0, currentMessageTypes.Values.Sum());
        foreach (var item in currentMessageTypes)
        {
            if (raffle < item.Value)
            {
                return item.Key;
            }
            else
            {
                raffle -= item.Value;
            }
        }
        return messageType.none;
    }

    private void GetMessageFromType(messageType messageType)
    {
        List<SheepStateController> possibleSheeps = SheepsController.Instance.allSheeps.Where(
            s => !s.isDead && s.config.HasMessageType(messageType)).ToList();

        if (possibleSheeps.Count > 0)
        {
            MessageBlob blob = possibleSheeps[UnityEngine.Random.Range(0,possibleSheeps.Count)].config.GetMessage(messageType);
            MessagesHistory.Instance.AddMessage(blob);
        }
    }


}