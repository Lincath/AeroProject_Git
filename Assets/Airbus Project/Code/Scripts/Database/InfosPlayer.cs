using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfosPlayer : MonoBehaviour {

    public Text txtPseudo, txtPoints, txtleaderboard, txtPoints2, txtleaderboard2, txtPoints3, txtleaderboard3, txtPoints4, txtleaderboard4, txtPoints5, txtleaderboard5;
    DB_Manager manager;
    public Text containerPoints, containerLeaderboard;

    // Use this for initialization
	void Start () {
        manager = GameObject.Find("MySqlManager").GetComponent<DB_Manager>();
        txtPseudo.text = "Pseudo " + manager.IPseudo;
        //txtPoints.text = "Event 1 " + manager.IPoints;
       // txtPoints2.text = "Event 2 " + manager.IPoints2;
       // txtPoints3.text = "Event 3 " + manager.IPoints3;
       // txtPoints4.text = "Event 4 " + manager.IPoints4;
      //  txtPoints5.text = "Event 5 " + manager.IPoints5;
        containerPoints.text = "My Points " + txtPoints.text;
    }

    #region Add Points
    public void addPoints() {
        manager.IPoints += 10;
        txtPoints.text = "Points " + manager.IPoints;
    }

    public void addPoints2()
    {
        manager.IPoints2 += 5;
        txtPoints2.text = "Points2 " + manager.IPoints2;
    }

    public void addPoints3()
    {
        manager.IPoints3 += 15;
        txtPoints3.text = "Points3 " + manager.IPoints3;
    }

    public void addPoints4()
    {
        manager.IPoints4 += 20;
        txtPoints4.text = "Points4 " + manager.IPoints4;
    }

    public void addPoints5()
    {
        manager.IPoints5 += 25;
        txtPoints5.text = "Points5 " + manager.IPoints5;
    }
    #endregion

    #region Save Points
    public void SavePoints()
    {
        manager.savePoints();
    }

    public void SavePoints2()
    {
        manager.savePoints2();
    }

    public void SavePoints3()
    {
        manager.savePoints3();
    }

    public void SavePoints4()
    {
        manager.savePoints4();
    }

    public void SavePoints5()
    {
        manager.savePoints5();
    }
    #endregion

    #region Leaderboards
    public void Leaderboard()
    {
        string data = manager.LeaderBoard(10);
        txtleaderboard.text = data;
        containerLeaderboard.text = txtleaderboard.text;
    }

    public void Leaderboard2()
    {
        string data = manager.LeaderBoard2(10);
        txtleaderboard2.text = data;
        containerLeaderboard.text = txtleaderboard2.text;
    }

    public void Leaderboard3()
    {
        string data = manager.LeaderBoard3(10);
        txtleaderboard3.text = data;
        containerLeaderboard.text = txtleaderboard3.text;
    }

    public void Leaderboard4()
    {
        string data = manager.LeaderBoard4(10);
        txtleaderboard4.text = data;
        containerLeaderboard.text = txtleaderboard4.text;
    }

    public void Leaderboard5()
    {
        string data = manager.LeaderBoard5(10);
        txtleaderboard5.text = data;
        containerLeaderboard.text = txtleaderboard5.text;
    }
    #endregion
}