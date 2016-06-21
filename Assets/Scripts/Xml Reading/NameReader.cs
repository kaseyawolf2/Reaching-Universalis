using UnityEngine;
using System.Collections;
using System.IO;


public class NameReader : MonoBehaviour {
	string path = @"C:\Users\kasey\Documents\Reaching Universalis\Assets\FirstNamesMale.txt";
	// Use this for initialization
	void Start () {
		if (File.Exists(path)) 
		{
			using (StreamReader sr = new StreamReader(path)) 
			{
				print(sr.ReadLine());
				Statics.FirstNamesMale.Add (new NameList{ Name = sr.ReadLine() });
			}
		}
	}
	void OnApplicationQuit() {
		if (File.Exists (path)) {
			using (StreamWriter sw = new StreamWriter (path)) {
				foreach (NameList C in Statics.FirstNamesMale) {
					//	sw.WriteLine(C.Name);
				}				
			}
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
