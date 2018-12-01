using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName="Sheep",menuName="Sheep",order=0 )]
public class SheepConfig : ScriptableObject {

	[SerializeField] private int _id;
	[SerializeField] private string _name;
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

    public MessageBlob GetMessage(messageType messageType){
		Message[] filtered = messages.Where(m=>m.MessageType == messageType).ToArray();
		if(filtered.Length>0){
			return new MessageBlob(_id, filtered[Random.Range(0,filtered.Length)].MessageTextKey,messageStyle.normal);
		} else {
			return null;
		}
	}

	public bool HasMessageType(messageType messageType){
		return messages.Where(m=>m.MessageType == messageType).ToArray().Length > 0;
	}
}
