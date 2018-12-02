using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobilePhone : Singleton<MobilePhone>
{
    public MobilePhoneMessage messagePrefab;
    public RectTransform phoneTrasform;
    public Transform contentParent;
    public int maxMessagesOnScreen = 8;

    private Animator phoneAnimator;
    private Animator contentAnimator;

    private Vector2 localMousePosition;
    private bool isHovered;

    void OnEnable()
    {
        GameEvents.Messages.NewMessage += AddMessage;
    }

    void OnDisable()
    {
        GameEvents.Messages.NewMessage -= AddMessage;
    }

    protected override void Awake()
    {
        base.Awake();

        // get references
        phoneAnimator = phoneTrasform.GetComponent<Animator>();
        contentAnimator = contentParent.GetComponent<Animator>();

        // instantiate cards
        for (int i = 0; i < maxMessagesOnScreen; i++)
        {
            MobilePhoneMessage msg = Instantiate(messagePrefab, contentParent);
            msg.SetVisibility(false);
        }
    }

    internal void FinishedScrolling()
    {
        Transform msgTransform = contentParent.GetChild(0).transform;
        //msgTransform.GetComponent<MobilePhoneMessage>().Setup(blob);
        msgTransform.GetComponent<MobilePhoneMessage>().SetVisibility(true);

        msgTransform = contentParent.GetChild(contentParent.childCount - 1).transform;
        msgTransform.SetAsFirstSibling();
    }

    private void StartScrolling()
    {
        Transform msgTransform = contentParent.GetChild(contentParent.childCount - 1).transform;
        msgTransform.GetComponent<MobilePhoneMessage>().SetVisibility(false);
        contentAnimator.SetTrigger("scroll");
    }

    void Update()
    {
        // get mousePos
        localMousePosition = phoneTrasform.InverseTransformPoint(Input.mousePosition);
        isHovered = phoneTrasform.rect.Contains(localMousePosition);

        //update animator
        phoneAnimator.SetBool("hover", isHovered);
    }

    private void AddMessage(MessageBlob blob)
    {
        Transform msgTransform = contentParent.GetChild(0).transform;
        msgTransform.GetComponent<MobilePhoneMessage>().Setup(blob);
        //msgTransform.GetComponent<MobilePhoneMessage>().SetVisibility(true);

        if (blob.style == messageStyle.alert)
            phoneAnimator.SetTrigger("vibrate");

        StartScrolling();
    }

    public void ClearAllMessages()
    {
        for (int i = 0; i < maxMessagesOnScreen; i++)
        {
            contentParent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void FeatureMobile()
    {
        phoneAnimator.SetBool("featured", true);
    }

    public void UnfeatureMobile()
    {
        phoneAnimator.SetBool("featured", false);
    }

}
