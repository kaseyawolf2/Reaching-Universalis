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
        if (Statics.Debug)
        {
            Debug.Log(pathFirstMale);
            Debug.Log(pathFirstFemale);
            Debug.Log(pathLast);
        }


        // so we dont start the game till after the names have be imported
    #region Name Importing
        Statics.ImportFinished = false;
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
        else
        {
            Debug.LogError("No File Path Found");
            return;
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
        else
        {
            Debug.LogError("No File Path Found");
            return;
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
        else
        {
            Debug.LogError("No File Path Found");
            return;
        }
        #endregion
        Statics.ImportFinished = true;
	}
    #endregion

    #region Name Saving
    void OnApplicationQuit()
	{
		
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
        else
        {
            Debug.LogError("No File Path Found");
            return;
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
        else
        {
            Debug.LogError("No File Path Found");
            return;
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
        else
        {
            Debug.LogError("No File Path Found");
            return;
        }
        #endregion
       
    }
    #endregion
}