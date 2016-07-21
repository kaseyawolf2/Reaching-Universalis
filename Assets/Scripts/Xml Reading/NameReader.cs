using UnityEngine;
using System.Collections;
using System.IO;


public class NameReader : MonoBehaviour {

	string dir;

	// paths of the Names
	string pathFirstMale;
	string pathFirstFemale;
	string pathLast;
	// Use this for initialization
	void Start () {
		dir = System.IO.Path.GetFullPath("Assets");


		pathFirstMale = dir + @"\Names\FirstNamesMale.txt";
		pathFirstFemale =  dir + @"\Names\FirstNamesFemale.txt";
		pathLast =  dir + @"\Names\LastNames.txt";

		print (pathFirstMale);
		print (pathFirstFemale);
		print (pathLast);
		// so we dont start the game till after the names have be imported
		Statics.ImportFinished = false;
		#region Initial Loading
		#region Male FirstNames
		//prevents the folder path being spamed with files if there is no file there
		if (File.Exists(pathFirstMale)) 
		{
			using (StreamReader sr = new StreamReader(pathFirstMale)) 
			{
				while (sr.Peek () >= 0) {
					Statics.FirstNamesMale.Add (new NameList{ Name = sr.ReadLine () });
				}
			}
		}
		#endregion
		#region Female FirstNames
		if (File.Exists(pathFirstFemale))
		{
			using (StreamReader sr = new StreamReader(pathFirstFemale))
			{
				while (sr.Peek() >= 0)
				{
					Statics.FirstNamesFemale.Add(new NameList { Name = sr.ReadLine() });
				}
			}
		}
		#endregion
		#region LastNames
		if (File.Exists(pathLast))
		{
			using (StreamReader sr = new StreamReader(pathLast))
			{
				while (sr.Peek() >= 0)
				{
					Statics.LastNames.Add(new NameList { Name = sr.ReadLine() });
				}
			}
		}
		#endregion
		#endregion
		Statics.ImportFinished = true;
	}



	void OnApplicationQuit()
	{
		#region Name Saving
		#region Male FirstNames
		if (File.Exists(pathFirstMale))
		{
			using (StreamWriter sw = new StreamWriter(pathFirstMale))
			{
				foreach (NameList C in Statics.FirstNamesMale)
				{
					sw.WriteLine(C.Name);
				}
			}
		}
		#endregion
		#region Female FirstNames
		if (File.Exists(pathFirstFemale))
		{
			using (StreamWriter sw = new StreamWriter(pathFirstFemale))
			{
				foreach (NameList C in Statics.FirstNamesFemale)
				{
					sw.WriteLine(C.Name);
				}
			}
		}
		#endregion
		#region Female LastNames
		if (File.Exists(pathLast))
		{
			using (StreamWriter sw = new StreamWriter(pathLast))
			{
				foreach (NameList C in Statics.LastNames)
				{
					sw.WriteLine(C.Name);
				}
			}
		}
		#endregion
		#endregion
	}


	// Update is called once per frame
	void Update () {
	}
}
