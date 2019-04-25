using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactBucket : MonoBehaviour
{
   private ScoreA myA;
   private ScoreB myB;
   private ScoreC myC;
    private ScoreD myD;
    private ScoreE myE;
    private ScoreF myF;
    private ScoreG myG;

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
        else if (value == 4)
        { myD = FindObjectOfType<ScoreD>(); }
        else if (value == 5)
        { myE = FindObjectOfType<ScoreE>(); }
        else if (value == 6)
        { myF = FindObjectOfType<ScoreF>(); }
        else if (value == 7)
        { myG = FindObjectOfType<ScoreG>(); }

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
        else if (myAV.avchoice == 4)
        { myD.ResetMultiplier(); }
        else if (myAV.avchoice == 5)
        { myE.ResetMultiplier(); }
        else if (myAV.avchoice == 6)
        { myF.ResetMultiplier(); }
        else if (myAV.avchoice == 7)
        { myG.ResetMultiplier(); }

    }
}
