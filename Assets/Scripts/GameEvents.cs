using System;
using UnityEngine;

public static class GameEvents
{
    public static class Messages
    {
        public static Action<MessageBlob> NewMessage;
    }

    public static class Localization
    {
        public static Action LanguageChanged;
    }

    public static class Notifications
    {
        public static Action<NotificationBlob> NewNotification;
        public static Action StartWarning;
        public static Action StopWarning;
    }

    public static class AI
    {
        public static Action WolfAppeared;
        public static Action WolfDisappeared;
    }
    public static class Sheeps
    {
        public static Action<SheepConfig> SheepDied;
        public static Action<GameObject, GameObject> OnSheepAttack;
    }
}