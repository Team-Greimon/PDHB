using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    enum TileType
    {
        grass,
        ice
    }

    TileType _type;
}

public class Map
{
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
