using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName="Sheep",menuName="Sheep",order=0 )]
public class SheepConfig : ScriptableObject {

	[SerializeField] private int _id;
	[SerializeField] private string _name;
	[SerializeField] private string _description;
	[SerializeField] private Texture2D _icon;
	[SerializeField] private List<Message> messages;

	public MessageBlob GetMessage(messageType messageType){
		Message[] filtered = messages.Where(m=>m.MessageType == messageType).ToArray();
		if(filtered.Length>0){
			return new MessageBlob(_id, filtered[Random.Range(0,filtered.Length)].MessageText,messageStyle.normal);
		} else {
			return null;
		}
	}

	public bool HasMessageType(messageType messageType){
		return messages.Where(m=>m.MessageType == messageType).ToArray().Length > 0;
	}
}
