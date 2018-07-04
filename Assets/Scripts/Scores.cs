using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour{
    public static int maxEntries = 5;
    public int numEntries = 0;
    public GameEntry[] entries;

    public Scores(){
        entries = new GameEntry[maxEntries];
        numEntries = 0;
    }

    public string toString(){
        string s = "[";
        for (int i = 0; i < numEntries; i++)
        {
            if (i > 0)
                s += ", ";
        }
        return s + "]";
    }

    private void Start()
    {

  //      Scores sc = new Scores();

  //      GameEntry x = new GameEntry("Joseph", 15);
  //      Debug.Log(x.toString());
  //      sc.AddGameEntry(x);
		//GameEntry b = new GameEntry("Joseph11", 114);
		//sc.AddGameEntry(b);
		//GameEntry ba = new GameEntry("Joseph321", 12);
		//sc.AddGameEntry(ba);
		//GameEntry bc = new GameEntry("Joseph32", 44);
		//sc.AddGameEntry(bc);

        //Debug.Log("" + entries.ToString());
    }

    public void AddGameEntry(GameEntry e){
        int newScore = e.Score;
        Debug.Log(newScore);
        //is the new entry e really a highscore?
        if (numEntries == maxEntries)//array is full
        {
            if (newScore <= entries[numEntries - 1].getScore())
                return;//new entry is not a hs
        }
        else//array is not full
            numEntries++;
        //Locate the placethat the new hs entry e belongs
        int i = numEntries - 1;
        for (; (i >= 1) && (newScore > entries[i-1].getScore()); i--){
            entries[i] = entries[i - 1]; //move entry i one to the right
            entries[i] = e; //add the new score to entries;
        }

    }
}
