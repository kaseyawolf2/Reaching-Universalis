using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NameList : IEquatable<NameList> {

	public string Name { get; set; }

	public override string ToString()
	{
		return Name;
	}

	public override bool Equals(object obj)
	{
		if (obj == null) return false;
		NameList objAsPart = obj as NameList;
		if (objAsPart == null) return false;
		else return Equals(objAsPart);
	}

	public bool Equals(NameList other)
	{
		if (other == null) return false;
		return (this.Name.Equals(other.Name));
	}

}
