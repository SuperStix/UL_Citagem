using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour {
    
    public Text[] g_entries_score;
	public Text[] h_entries_name;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Leaderboard.EntryCount; ++i)
		{
			var entry = Leaderboard.GetEntry(i);
            g_entries_score[i].text = "" + entry.score;
            h_entries_name[i].text = entry.name;
		}

	}

}
