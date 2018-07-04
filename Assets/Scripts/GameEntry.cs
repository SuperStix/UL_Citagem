using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntry {

    public int Id;
    public string Name;
    public int Score;
    public string Date;
	
    public GameEntry(string n, int m){
        Name = n;
        Score = m;
    }
    public int getScore(){
        return Score; 
    }
	public string getName()
	{
		return Name;
	}

	public int setScore(int x)
	{
        Score = x;
        return Score;
	}
	public string setName(string n)
	{
        Name = n;
		return Name;
	}

    public string toString(){
        return "" + Name + "|" + Score+"\n";
    }
}
