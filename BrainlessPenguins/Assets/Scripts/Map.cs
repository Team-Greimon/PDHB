using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public static readonly Tile InvalidTile = new Tile(TileType.invalid);

    public Tile(int typeNum)
    {
        var type = (TileType)typeNum;
        _type = type;
    }
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
    public Map(List<List<Tile>> tiles)
    {
        _tiles = tiles;
    }

    public Tile GetTile(int r, int c)
    {
        if (r <= GetHeight() && c <= GetWidth())
        { 
            return _tiles[r][c];
        }
        return Tile.InvalidTile;
    }

    public int GetHeight()
    {
        return _tiles.Count;
    }

    public int GetWidth()
    {
        return _tiles[0] is null ? 0 : _tiles[0].Count;
    }

    List<List<Tile>> _tiles;
}