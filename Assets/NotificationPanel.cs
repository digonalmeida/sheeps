using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : Singleton<NotificationPanel>
{

    public float notificationDuration;
    public Animator animator;
    public Image notificationSheepIcon;
    public Text notificationNameField;
    public LocalizedText notificationKinshipField;
    public LocalizedText notificationMessageField;

    private Coroutine currentCoroutine;

    void OnEnable()
    {
        GameEvents.Notifications.NewNotification += OpenNotificationPanel;
    }

    void OnDisable()
    {
        GameEvents.Notifications.NewNotification -= OpenNotificationPanel;
    }

    public void OpenNotificationPanel(NotificationBlob blob)
    {
        SheepConfig config = SheepsManager.Instance.GetSheepConfigById(blob.SheepID);
        notificationSheepIcon.sprite = config.Icon;
        notificationNameField.text = config.Name;
        notificationKinshipField.SetupText(config.KinshipKey);
        notificationMessageField.SetupText(blob.MessageKey);
        animator.SetBool("open", true);

        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(this.WaitAndAct(notificationDuration, () => CloseNotificationPanel()));
    }

    public void CloseNotificationPanel()
    {
        animator.SetBool("open", false);
    }

}
