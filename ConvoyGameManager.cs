using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvoyGameManager : MonoBehaviour 
{
	public GameObject cellPrefab;
	public GameObject cellParent;
	public Algorithm alg;
	public Algorithm.Node[,] Nodes;
	public int n = 5;
	public Color passedCells;
	public Color failedCells;
	public cell[,] cells;

	// Use this for initialization
	void Start () 
	{
		alg = new Algorithm ();
		CreateGrid (n,cellPrefab,cellParent);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public GameObject Spawn(GameObject obj)
	{
		return Instantiate (obj,obj.transform.localPosition,Quaternion.identity) as GameObject;
	}

	public void CreateGrid(int n,GameObject btn,GameObject parent)
	{
		Algorithm.Node[,] nodes = new Algorithm.Node[n,n];
		cell[,] clls = new cell[n,n];

		for(int y = 0; y < n; y++)
		{
			for(int x = 0; x < n; x++)
			{
				nodes [y , x] = new Algorithm.Node ();
				nodes [y , x].y = y;
				nodes [y , x].x = x;

				GameObject go = Spawn (btn);
				go.GetComponent<cell> ().assiggnedNode = nodes [y, x];
				clls [y, x] = go.GetComponent<cell> ();
				go.transform.SetParent (parent.transform,false);
				go.GetComponent<RectTransform> ().localPosition = new Vector3 (go.GetComponent<RectTransform> ().localPosition.x + x*100,go.GetComponent<RectTransform> ().localPosition.y - y*100,go.GetComponent<RectTransform> ().localPosition.z);
				go.GetComponent<cell> ().Init ();
				go.GetComponent<cell> ().gm = this;
			}
		}

		Nodes = nodes;
		cells = clls;
	}

	public void OnRunSimulation()
	{
		Nodes = alg.RunSimulation (Nodes);
		for(int y = 0; y < n; y++)
		{
			for(int x = 0; x < n; x++)
			{
				if (Nodes [y, x].occupied == 1) 
				{
					cells [y,x].GetComponent<Image> ().color = passedCells;
				} 
				else 
				{
					cells [y,x].GetComponent<Image> ().color = failedCells;
				}
			}
		}
	}
}
