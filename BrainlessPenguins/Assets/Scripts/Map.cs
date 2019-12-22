using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public static readonly Tile InvalidTile = new Tile(TileType.invalid);

    public Tile(TileType type)
    {
        _type = type;
    }

    public enum TileType
    {
        invalid = 0,
        grass = 1,
        ice = 2
    }

    TileType _type;
}

public class Map
{
    public Tile getTile(int r, int c)
    {
        if (r <= getHeight() && c <= getWidth())
        { 
            return _tiles[r][c];
        }
        return Tile.InvalidTile;
    }

    public int getHeight()
    {
        return _tiles.Count;
    }

    public int getWidth()
    {
        return _tiles[0] is null ? 0 : _tiles[0].Count;
    }

    List<List<Tile>> _tiles;
}

public class MapManager : Singleton<MapManager>
{
    public Tile getTile(int r, int c)
    {
        return _map.getTile(r, c);
    }
    protected Map _map;
}