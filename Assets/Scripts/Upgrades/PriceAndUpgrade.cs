using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Upgrade {
    [SerializeField] private int price;
    [SerializeField] private float value;

    public int Price => price;
    public float Value => value;
}