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

	public List<cell> selectedCell = new List<cell>();

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

		for(int x = 0; x < n; x++)
		{
			for(int y = 0; y < n; y++)
			{
				nodes [x , y] = new Algorithm.Node ();
				nodes [x , y].x = x;
				nodes [x , y].y = y;

				GameObject go = Spawn (btn);
				go.GetComponent<cell> ().assiggnedNode = nodes [x, y];
				go.transform.SetParent (parent.transform,false);
				go.GetComponent<RectTransform> ().localPosition = new Vector3 (go.GetComponent<RectTransform> ().localPosition.x + y*100,go.GetComponent<RectTransform> ().localPosition.y - x*100,go.GetComponent<RectTransform> ().localPosition.z);
				go.GetComponent<cell> ().Init ();
				go.GetComponent<cell> ().gm = this;
			}
		}

		Nodes = nodes;
	}

	public void OnRunSimulation()
	{
		for(int i = 0; i < selectedCell.Count; i++)
		{
			selectedCell [i].GetComponent<Image> ().color = failedCells;
		}
		
		int lim1 = 2;
		int lim2 = 3;
		int flag = -1;

		int min = 999999999;
		int limr = 0;
		int its = 0;

		for(int i = 0; i < selectedCell.Count; i++)
		{
			cell centerCell= selectedCell[i];
			Algorithm.Node[] nd = alg.GetNeighboursNodes (Nodes,centerCell.assiggnedNode.x,centerCell.assiggnedNode.y);
			limr = 0;
			for(int j = 0; j < nd.Length; j++)
			{
				if (centerCell.assiggnedNode.occupied == 1 && nd [j].occupied == 1)
				{
					limr = limr + 1;
				}
				its = its + 1;
			}
			min = alg.Mini (limr,min);
		}
		if (min >= lim1 && min <= lim2) 
		{
			flag = 1;
		} 
		else 
		{
			flag = -1;
		}
		if (flag == 1) 
		{
			for(int i = 0; i < selectedCell.Count; i++)
			{
				selectedCell [i].GetComponent<Image> ().color = passedCells;
			}
		}
	}
}
