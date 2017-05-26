using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
public static class PathFinder
{
    public static void jaVisitou()
    {
        Debug.Log("voce por aqui de novo?");
    }
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition)
	{
		var path = new List<Grid.Position>();
      
        List<Grid.Position> lista = new List<Grid.Position> { };
        Queue<Grid.Position> Q1 = new Queue<Grid.Position>();

        Q1.Enqueue(fromPosition);

        while (Q1.Count > 0)
        {
            Grid.Position p = Q1.Dequeue();

            if (p.x == toPosition.x && p.y == toPosition.y)
            {
                while(p != null)
                {
                    path.Add(p);
                    Debug.Log(p.x + " " + p.y);
                    p = p.previous;
                }

                Debug.Log("Achei o cara");
                break;
            }
            else
            {
                Grid.Position seeker1 = new Grid.Position { x = p.x, y = p.y + 1 };
                Grid.Position seeker2 = new Grid.Position { x = p.x, y = p.y - 1 };
                Grid.Position seeker3 = new Grid.Position { x = p.x + 1, y = p.y };
                Grid.Position seeker4 = new Grid.Position { x = p.x - 1, y = p.y };


                if (!lista.Any(e => e.x == seeker1.x && e.y == seeker1.y ))
                {
                    if(seeker1.x >= 0 && seeker1.x < 10 && seeker1.y >= 0 && seeker1.y < 10)
                    {
                        if( !tiles[seeker1.x, seeker1.y].isWall )
                        {
                            seeker1.previous = p;
                            Q1.Enqueue(seeker1);
                            lista.Add(seeker1);
                        }
                   }
                }

                if (!lista.Any(e => e.x == seeker2.x && e.y == seeker2.y))
                {
                    if (seeker2.x >= 0 && seeker2.x < 10 && seeker2.y >= 0 && seeker2.y < 10)
                    {
                        if (!tiles[seeker2.x, seeker2.y].isWall)
                        {
                            seeker2.previous = p;
                            Q1.Enqueue(seeker2);
                            lista.Add(seeker2);
                        }
                    }
                }

                if (!lista.Any(e => e.x == seeker3.x && e.y == seeker3.y))
                {
                    if (seeker3.x >= 0 && seeker3.x < 10 && seeker3.y >= 0 && seeker3.y < 10)
                    {
                        if (!tiles[seeker3.x, seeker3.y].isWall)
                        {
                            seeker3.previous = p;
                            Q1.Enqueue(seeker3);
                            lista.Add(seeker3);
                        }
                    }
                }

                if (!lista.Any(e => e.x == seeker4.x && e.y == seeker4.y))
                {
                    if (seeker4.x >= 0 && seeker4.x < 10 && seeker4.y >= 0 && seeker4.y < 10)
                    {
                        if (!tiles[seeker4.x, seeker4.y].isWall)
                        {
                            seeker4.previous = p;
                            Q1.Enqueue(seeker4);
                            lista.Add(seeker4);
                        }
                    }
                }

            }
                
        }

        //path.Add( fromPosition );
        //Grid.Position posi = fromPosition;

        /*while(posi.x != toPosition.x || posi.y != toPosition.y)
        {
            if(posi.x < toPosition.x)
            { posi.x++; }
            else if (posi.x>toPosition.x) { posi.x--; }

            if (posi.y < toPosition.y)
            { posi.y++; }
            else if (posi.y> toPosition.y) { posi.y--; }
           
            path.Add(posi);
        }*/
        
        //path.Add(toPosition);
        return path;
	}
}