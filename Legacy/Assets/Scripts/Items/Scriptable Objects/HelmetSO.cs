using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Helmet", menuName = "Items/Equipment/Helmet")]
public class HelmetSO : EquiptmentSO {

    private void Awake()
    {
        type = EquimentType.Helmet;
    }

}
