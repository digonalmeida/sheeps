using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobilePhone : Singleton<MobilePhone>
{
    public MobilePhoneMessage messagePrefab;
    public Transform contentParent;
    public int maxMessagesOnScreen = 7;

    private Animator animator;

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
        animator = GetComponent<Animator>();

        // instantiate cards
        for (int i = 0; i < maxMessagesOnScreen; i++)
        {
            MobilePhoneMessage msg = Instantiate(messagePrefab, contentParent);
            msg.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        animator.SetBool("hover", false);
    }

    private void OnMouseOver()
    {
        animator.SetBool("hover", true);
    }
    private void AddMessage(MessageBlob blob)
    {
        Transform msgTransform = contentParent.GetChild(0).transform;
        msgTransform.gameObject.SetActive(true);
        msgTransform.SetAsLastSibling();
        msgTransform.GetComponent<MobilePhoneMessage>().Setup(blob);
    }

    public void ClearAllMessages()
    {
        for (int i = 0; i < maxMessagesOnScreen; i++)
        {
            contentParent.GetChild(i).gameObject.SetActive(false);
        }
    }
}
