using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileObject : MonoBehaviour
{
    public Tile.TileType _tileType;

    int _rowPos { get; set; }
    int _colPos { get; set; }

    SpriteRenderer _spriteRenderer;

    public void Initialize(Tile.TileType tileType, int rowPos, int colPos)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rowPos = rowPos;
        _colPos = colPos;

        transform.position = MapManager.GetInst().GetTileLocalPosition(rowPos, colPos);

        SetTile(tileType);
        gameObject.SetActive(true);
    }

    public void SetTile(Tile.TileType tileType)
    {
        _tileType = tileType;

        var sprite = MapManager.GetInst().GetSpriteForTileType(tileType);
        _spriteRenderer.sprite = sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
