using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;

public class xmlReader : MonoBehaviour {
	public TextAsset dictionary;

	public string languageName;
	public int currentLanguage;

	string button1;
	string button2;

	List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
	Dictionary<string, string> obj;

	private void Awake() 
	{
		Reader();
	}

	private void Update() 
	{
		languages[currentLanguage].TryGetValue("name", out languageName);
		languages[currentLanguage].TryGetValue("button1", out button1);
		languages[currentLanguage].TryGetValue("button2", out button2);
	}

	void Reader()
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(dictionary.text);
		XmlNodeList languageList = xmlDoc.GetElementsByTagName("language");

		foreach (XmlNode languageValue in languageList)
		{
			XmlNodeList	 languageContent = languageValue.ChildNodes;
			obj = new Dictionary<string, string>();

			foreach (XmlNode value in languageContent)
			{
				if (value.Name == "name")
					obj.Add(value.Name, value.InnerText);

				if (value.Name == "button1")
					obj.Add(value.Name, value.InnerText);
				
				if (value.Name == "button2")
					obj.Add(value.Name, value.InnerText);
			}
			languages.Add(obj);
		}
	}
}
