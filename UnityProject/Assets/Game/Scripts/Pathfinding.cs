using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AStar;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector2Int = AStar.Vector2Int;

public class Pathfinding : BB
{

    public class Grid : IGridProvider
    {
        private readonly Cell[,] _cells;

        public int Width { get; set; }
        public int Height { get; set; }

        public Cell this[int x, int y] => _cells[x, y];

        public Vector2Int Size => new Vector2Int(Width, Height);
        public Cell this[Vector2Int location] => _cells[location.X, location.Y];

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new Cell[width, height];
        
            Reset();
        }

        public void Reset() {

            for (var x = 0; x <= _cells.GetUpperBound(0); x++) {
                for (var y = 0; y <= _cells.GetUpperBound(1); y++) {

                    var cell = _cells[x, y];

                    if (cell == null) {
                        _cells[x, y] = new Cell(new Vector2Int(x, y));
                    } else {
                        cell.G = 0;
                        cell.H = 0;
                        cell.F = 0;
                        cell.Closed = false;
                        cell.Parent = null;
                    }
                }
            }
        }

        public int GetNodeId(Vector2Int location) => location.X * Width + location.Y;
    }

    private Grid mGrid;
    private AStarSearch mSearch;
    private Tilemap mTilemap;

    public void Initialize(Tilemap tilemap){
        mGrid = new Grid(100, 100);
        
        mSearch = new AStarSearch(mGrid);
        mTilemap = tilemap;
    }

    private Vector2Int WorldToTile(Vector3 worldPoint){
        var cell = mTilemap.WorldToCell(worldPoint);
        return new Vector2Int(cell.x,cell.y) ;
    }


    private Cell[] findPath(Vector3 sourceWorldPoint,Vector3 targetWorldPoint){
        var sourceTile = WorldToTile(sourceWorldPoint);
        var destTile = WorldToTile(targetWorldPoint);        
        var path =  mSearch.Find(sourceTile,destTile);
        return path;
    }

    private IEnumerable<Vector3> translatePath(Cell[] path){
        foreach(var cell in path){
            var worldPoint = mTilemap.CellToWorld(new Vector3Int(cell.Location.X, cell.Location.Y));
            yield return worldPoint;
        }
    }

    public Vector3[] findRoute(Vector3 sourceWorldPoint, Vector3 targetWorldPoint){
        return translatePath(findPath(sourceWorldPoint,targetWorldPoint)).ToArray();
    }
    
}
