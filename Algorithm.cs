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

	public Node[,] RunSimulation(Node[,] nodes)
	{
		Node[,] ans;

		int marked = 1;
		int unmarked = 0;

		for(int iy = 0; iy < Mathf.Sqrt(nodes.Length); iy++)
		{
			for(int ix = 0; ix < Mathf.Sqrt(nodes.Length); ix++)
			{	
				Node[] nebsNodes = GetNeighboursNodes(nodes,iy,ix);
				int ocpcnt = 0;
				for(int j = 0; j < nebsNodes.Length; j++)
				{	
					if(nebsNodes[j].occupied == 1)
					{
						ocpcnt = ocpcnt + 1;
					}
				}
				if(ocpcnt < 2 && nodes[iy, ix].occupied == 1)
				{
					nodes [iy, ix].occupied = -1;
				}
				else
				if(ocpcnt >= 2 && ocpcnt <= 3 && nodes [iy, ix].occupied == 1)
				{
					nodes [iy, ix].occupied = 1;
				}
				else
				if(ocpcnt > 3 && nodes [iy, ix].occupied == 1)
				{
					nodes [iy, ix].occupied = -1;
				}
				else
				if(nodes[iy, ix].occupied == -1 && ocpcnt == 3)
				{
					nodes [iy, ix].occupied = 1;	
				}
			}
		}

		return nodes;
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

	public Node[] GetNeighboursNodes(Node[,] nodes,int sy,int sx)
	{
		Node[] ans = null;

		Node[] nbsnodes = GetNeighbours (nodes,sy,sx);
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

	public Node[] GetNeighbours(Node[,] nodes,int cy,int cx)
	{
		Node[] ans = new Node[9];

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
