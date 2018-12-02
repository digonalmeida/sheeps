using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSingleton : SingletonDestroy<DataSingleton>
{

    public List<SheepState> allSheeps = new List<SheepState>();

}
