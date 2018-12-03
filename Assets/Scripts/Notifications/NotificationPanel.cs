using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : Singleton<NotificationPanel>
{

    public RectTransform deathNotificationPanel;
    public RectTransform warningNotificationPanel;
    public RectTransform notificationPanel;

    public Animator animator;
    public float deathNotificationDuration;
    public float notificationDuration;
    public Image notificationSheepIcon;
    public Text notificationNameField;
    public LocalizedText notificationKinshipField;
    public LocalizedText notificationMessageField;
    public LocalizedText notificationTextField;

    private Coroutine currentCoroutine;
    private bool isWarning;
    private bool isNotificating;

    void OnEnable()
    {
        GameEvents.Notifications.NewDeathNotification += OpenDeathNotificationPanel;
        GameEvents.Notifications.StartWarning += StartWarningNotificationPanel;
        GameEvents.Notifications.StopWarning += StopWarningNotificationPanel;
        GameEvents.Notifications.NewNotification += OpenNotification;
    }

    void OnDisable()
    {
        GameEvents.Notifications.NewDeathNotification -= OpenDeathNotificationPanel;
        GameEvents.Notifications.StartWarning -= StartWarningNotificationPanel;
        GameEvents.Notifications.StopWarning -= StopWarningNotificationPanel;
        GameEvents.Notifications.NewNotification -= OpenNotification;
    }

    public void OpenDeathNotificationPanel(NotificationBlob blob)
    {
        if (!isWarning)
        {
            Debug.Log("Notif death");

            deathNotificationPanel.gameObject.SetActive(true);
            warningNotificationPanel.gameObject.SetActive(false);
            notificationPanel.gameObject.SetActive(false);
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
        Debug.Log("Notif warn");
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        deathNotificationPanel.gameObject.SetActive(false);
        warningNotificationPanel.gameObject.SetActive(true);
        notificationPanel.gameObject.SetActive(false);
        animator.SetBool("open", true);
        isWarning = true;
    }

    public void StopWarningNotificationPanel()
    {
        CloseNotificationPanel();
        isWarning = false;
    }

    public void OpenNotification(string textKey)
    {
        notificationTextField.SetupText(textKey);
        isNotificating = true;
        deathNotificationPanel.gameObject.SetActive(false);
        warningNotificationPanel.gameObject.SetActive(false);
        notificationPanel.gameObject.SetActive(true);
        animator.SetBool("open", true);

        if (currentCoroutine != null) StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(this.WaitAndAct(notificationDuration, () => CloseNotificationPanel()));

    }

}
