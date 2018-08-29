using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfosPlayer : MonoBehaviour {

    public Text txtPseudo, txtPoints, txtleaderboard;
    DB_Manager manager;

    // Use this for initialization
	void Start () {
        manager = GameObject.Find("MySqlManager").GetComponent<DB_Manager>();
        txtPseudo.text = "Pseudo " + manager.IPseudo;
        txtPoints.text = "Points " + manager.IPoints;
	}
	
	public void addPoints() {
        manager.IPoints += 10;
        txtPoints.text = "Points " + manager.IPoints;
    }

    public void SavePoints()
    {
        manager.savePoints();
    }

    public void Leaderboard()
    {
        string data = manager.LeaderBoard(10);
        txtleaderboard.text = data;
    }
}