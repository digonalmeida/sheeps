using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName="Sheep",menuName="Sheep",order=0 )]
public class SheepConfig : ScriptableObject {

	[SerializeField] private int _id;
	[SerializeField] private string _name;
    [SerializeField] private string _kinshipKey;
	[SerializeField] private string _description;
	[SerializeField] private Sprite _icon;
	[SerializeField] private List<Message> messages;

    public int Id
    {
        get
        {
            return _id;
        }
    }

    public Sprite Icon
    {
        get
        {
            return _icon;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public string KinshipKey
    {
        get
        {
            return _kinshipKey;
        }
    }

    public MessageBlob GetMessage(messageType messageType){
		Message[] filtered = messages.Where(m=>m.MessageType == messageType && !m.WasUsed).ToArray();
		if(filtered.Length>0){
            Message m = filtered[Random.Range(0,filtered.Length)];
            m.WasUsed = true;
            messageStyle style = messageType == messageType.fear ? messageStyle.alert : messageStyle.normal;
			return new MessageBlob(_id, m.MessageTextKey,style);
		} else {
			return null;
		}
	}

	public bool HasMessageType(messageType messageType){
		return messages.Where(m=>m.MessageType == messageType && !m.WasUsed).ToArray().Length > 0;
	}

    public void ResetUsedMessages(){
        foreach (Message m in messages)
        {
            m.WasUsed = false;
        }
    }
}
