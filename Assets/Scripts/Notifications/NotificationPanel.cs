using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : Singleton<NotificationPanel>
{

    public RectTransform deathNotificationPanel;
    public RectTransform warningNotificationPanel;

    public Animator animator;
    public float deathNotificationDuration;
    public Image notificationSheepIcon;
    public Text notificationNameField;
    public LocalizedText notificationKinshipField;
    public LocalizedText notificationMessageField;

    private Coroutine currentCoroutine;
    private bool isWarning;

    void OnEnable()
    {
        GameEvents.Notifications.NewNotification += OpenDeathNotificationPanel;
        GameEvents.Notifications.StartWarning += StartWarningNotificationPanel;
        GameEvents.Notifications.StopWarning += StopWarningNotificationPanel;
    }

    void OnDisable()
    {
        GameEvents.Notifications.NewNotification -= OpenDeathNotificationPanel;
        GameEvents.Notifications.StartWarning -= StartWarningNotificationPanel;
        GameEvents.Notifications.StopWarning -= StopWarningNotificationPanel;
    }

    public void OpenDeathNotificationPanel(NotificationBlob blob)
    {
        if (!isWarning)
        {
            deathNotificationPanel.gameObject.SetActive(true);
            warningNotificationPanel.gameObject.SetActive(false);
            SheepConfig config = SheepsManager.Instance.GetSheepConfigById(blob.SheepID);
            notificationSheepIcon.sprite = config.Icon;
            notificationNameField.text = config.Name;
            notificationKinshipField.SetupText(config.KinshipKey);
            notificationMessageField.SetupText(blob.MessageKey);
            animator.SetBool("open", true);

            if (currentCoroutine != null) StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(this.WaitAndAct(deathNotificationDuration, () => CloseNotificationPanel()));
        }
    }

    public void CloseNotificationPanel()
    {
        animator.SetBool("open", false);
    }

    public void StartWarningNotificationPanel()
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        deathNotificationPanel.gameObject.SetActive(false);
        warningNotificationPanel.gameObject.SetActive(true);
        animator.SetBool("open", true);
        isWarning = true;
    }

    public void StopWarningNotificationPanel()
    {
        CloseNotificationPanel();
        isWarning = false;
    }

}
