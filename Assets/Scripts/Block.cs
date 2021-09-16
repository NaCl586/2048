using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value;
    public Node Node;
    public Block MergingBlock;
    public bool Merging;
    public Vector2 Pos => transform.position; //getter
    
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private TextMeshPro _text;
    public void Init(BlockType type)
    {
        Value = type.Value;
        _renderer.color = type.color;
        _text.text = type.Value.ToString();
    }

    public void setBlock(Node node)
    {
        if (Node != null) Node.OccupiedBlock = null;
        Node = node;
        Node.OccupiedBlock = this;
    }

    public void mergeBlock(Block blockToMergeWith)
    {
        //set the block going to be merged with
        MergingBlock = blockToMergeWith;

        //set current node as unoccupied to allow blocks to use it
        Node.OccupiedBlock = null;

        //set the base block as merging, so it does not get used twice (cuma sekali merge aja)
        blockToMergeWith.Merging = true;
    }

    public bool canMerge(int value) {
        //kalau value sama, gak lagi merge, dan ga ada block yang lagi merging, then bisa merge
        return (value == Value && !Merging && MergingBlock == null);
    }
}
