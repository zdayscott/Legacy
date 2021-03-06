﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class ItemSO : ScriptableObject
{
    new public string name = "New Item";
    public string discription = "This is an item";
    public Sprite icon = null;
}
