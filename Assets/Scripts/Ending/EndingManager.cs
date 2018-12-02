using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public List<SheepConfigHolder> sheeps = new List<SheepConfigHolder>();
    public Sprite dead;

    void Start ()
    {
        KillSheeps();
    }

    void KillSheeps()
    {
        var deadSheep = DataSingleton.Instance.allSheeps.Where(sheep => sheep.isDead).Select(sheepState => sheepState.config);

        for (int i=0; i<sheeps.Count; i++)
        {
            if (deadSheep.Contains(sheeps[i].config))
            {
                sheeps[i].ChangeSprite(dead);
            }
        }        
    }
}
