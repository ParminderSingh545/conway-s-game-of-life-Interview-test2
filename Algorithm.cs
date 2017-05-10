using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithm
{
	public Algorithm()
	{
		
	}

	~Algorithm()
	{
		
	}

	public int RunSimulation(Node[,] nodes,int sx,int sy)
	{
		int ans = -1;

		int marked = 1;
		int unmarked = 0;

		Node[] nd = GetNeighboursNodes (nodes,sx,sy);


		return ans;
	}

	public int Mini(int a,int b)
	{
		int ans = b;

		if (a < b)
			ans = a;
		else
			ans = b;

		return ans;
	}

	public Node[] GetNeighboursNodes(Node[,] nodes,int sx,int sy)
	{
		Node[] ans = null;

		Node[] nbsnodes = GetNeighbours (nodes,sx,sy);
		Node[] nbsnodesNew = new Node[nbsnodes.Length - 1];

		for(int i = 0,l = 0; i < nbsnodes.Length; i++)
		{
			if(nbsnodes[i] != null)
			{
				if (nbsnodes [i].x == sx && nbsnodes [i].y == sy) 
				{
					continue;
				} 
				else 
				{
					nbsnodesNew[l] = nbsnodes[i];
					l++;
				}
			}
		}

		int len = nbsnodesNew.Length;

		for(int i = 0; i < nbsnodesNew.Length; i++)
		{
			if (nbsnodesNew [i] == null) 
			{
				len = i;
				break;
			}
		}
		ans = new Node[len];
		for(int i = 0; i < ans.Length; i++)
		{
			ans[i] = nbsnodesNew[i];
		}

		return ans;
	}

	public Node[] GetNeighbours(Node[,] nodes,int cx,int cy)
	{
		Node[] ans = new Node[9];

		int temp = cy;
		cy = cx;
		cx = temp;

		for(int y = cy - 1, cntr = 0; y <= cy + 1; y++)
		{
			for(int x = cx - 1; x <= cx + 1; x++)
			{
				if((x >= 0 && y >= 0) && (x < Mathf.Sqrt(nodes.Length) && y < Mathf.Sqrt(nodes.Length)))
				{
					ans[cntr] = nodes[y , x];
					cntr = cntr + 1;
				}
			}
		}

		return ans;
	}

	public class Node
	{
		public Node()
		{
			
		}

		~Node()
		{
			
		}

		public int x = 0;
		public int y = 0;
		public int occupied = -1;
	}

}
