using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutAdjust : MonoBehaviour
{
    GridLayoutGroup grid;

	void Start ()
    {
        grid = GetComponent<GridLayoutGroup>();
        if (Camera.main.aspect < 1f)
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        }
        else
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        }
	}

	void Update ()
    {
		
	}
}
