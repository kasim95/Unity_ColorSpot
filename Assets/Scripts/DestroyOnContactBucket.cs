using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactBucket : MonoBehaviour
{
   private ScoreA myA;
   private ScoreB myB;
   private ScoreC myC;
   private AvatarChoice myAV;
    private void Start()
    {
        myAV = FindObjectOfType<AvatarChoice>();
        int value = myAV.avchoice;
        if (value == 1)
        { myA = FindObjectOfType<ScoreA>(); }
        else if (value == 2)
        { myB = FindObjectOfType<ScoreB>(); }
        else if(value == 3)
        { myC = FindObjectOfType<ScoreC>(); }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
       if(myAV.avchoice == 0 || myAV.avchoice == 1)
       { myA.ResetMultiplier(); }
        else if (myAV.avchoice == 2 )
       { myB.ResetMultiplier(); }
        else if (myAV.avchoice == 3 )
       { myC.ResetMultiplier(); }

    }
}
