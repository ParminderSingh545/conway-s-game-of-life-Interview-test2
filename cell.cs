using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cell : MonoBehaviour 
{
	public ConvoyGameManager gm;
	public Algorithm.Node assiggnedNode;

	public Text cords_text;
	public bool filled = false;
	public Color filled_color;
	public Color empty_color;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	public void Init()
	{
		cords_text.text = assiggnedNode.x.ToString() + "," + assiggnedNode.y.ToString ();
	}

	public void Fill()
	{
		if (filled) 
		{
			filled = false;
			assiggnedNode.occupied = -1;
			gameObject.GetComponent<Image> ().color = empty_color;
			gm.selectedCell.Remove (this);
		} 
		else
		{
			filled = true;
			assiggnedNode.occupied = 1;
			gameObject.GetComponent<Image> ().color = filled_color;
			gm.selectedCell.Add (this);
		}
	}

	public int IsCellWithNode(Algorithm.Node nd)
	{
		int ans = -1;

		if (nd == assiggnedNode)
			ans = 1;
		else
			ans = -1;

		return ans;
	}
}
