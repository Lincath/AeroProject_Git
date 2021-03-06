﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class DB_Manager : MonoBehaviour
{
    public static DB_Manager instance;
    [Header("DATABASE")]
    public string host;
    public string database, username, password;
    [Header("REGISTER")]
    public Canvas CanvasRegister;
    public InputField RPseudo;
    public InputField REmail, RPassword, RFirstName, RLastName, RPhoneNumber, RAddress, RYearOfBirth;
    List<string> genders = new List<string>() { "Select Gender", "Man", "Woman" };
    public Dropdown gender;
    public Text selectedGender;
    public bool IsValidGender;
    List<string> profiles = new List<string>() { "Select Profile", "I am a Pilot", "I am an Aero Fan", "I am a Gamer" };
    public Dropdown profile;
    public Text selectedProfile;
    public bool IsValidProfile;
    public Text RtxtInfos;
    MySqlConnection con;
    [Header("LOGIN")]
    public Canvas CanvasLogin;
    public InputField LPseudo;
    public InputField LPassword;
    public Text LtxtInfos;
    [Header("INFO USER")]
    public string IPseudo;
    public string IFirstName, ILastName, IEmail, IGender, IPhoneNumber, IAddress, IYearOfBirth, IProfile;
    public int IPoints, IPoints2, IPoints3, IPoints4, IPoints5;

    private void Start()
    {
        connect_BDD();

        PopulateList();
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void connect_BDD()
    {
        string cmd = "SERVER=" + host + ";" + "database=" + database + ";User ID=" + username + ";Password=" + password + ";Pooling=true;Charset=utf8";

        try
        {
            con = new MySqlConnection(cmd);
            con.Open();
        }

        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    void Update()
    {
      // Debug.Log(con.State);
    }

    #region Caracteres Requis
    bool IsValidLenght(string InputString, int LenghtString)
    {
        if (InputString.Length > LenghtString)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    bool IsValidLenghtMax(string InputString, int LenghtString)
    {
        if (InputString.Length < LenghtString)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    #endregion

    #region Validation Email Format
    bool IsValidEmail(string InputEmail)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(InputEmail);
        if (match.Success)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
    #endregion

    #region Validation Dropdown
    void PopulateList()
    {
        gender.AddOptions(genders);
        profile.AddOptions(profiles);
    }

    public void Dropdown_IndexChangedGender(int index)
    {
        selectedGender.text = genders[index];
        if (index == 0)
        {
            selectedGender.color = Color.red;
            IsValidGender = false;
        }
        else
        {
            selectedGender.color = Color.white;
            IsValidGender = true;
        }
    }

    public void Dropdown_IndexChangedProfile(int index)
    {
        selectedProfile.text = profiles[index];
        if (index == 0)
        {
            selectedProfile.color = Color.red;
            IsValidProfile = false;
        }
        else
        {
            selectedProfile.color = Color.white;
            IsValidProfile = true;
        }
    }
    #endregion

    bool IsValid()
    {
        #region Pseudo
        //Pseudo
        ColorBlock cbPseudo = RPseudo.colors;

        if (!IsValidLenght(RPseudo.text, 2))
        {
            cbPseudo.normalColor = Color.red;
            RtxtInfos.text = "Invalid Pseudo";
            Handheld.Vibrate();
            RPseudo.colors = cbPseudo;
            return false;
        }

        else
        {
            cbPseudo.normalColor = Color.white;
            RtxtInfos.text = "";
            RPseudo.colors = cbPseudo;
        }

        //Verification existance pseudo
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` WHERE `pseudo`='" + RPseudo.text + "'", con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();
            string data = null;

            while (MyReader.Read())
            {
                data = MyReader["password"].ToString();

                if (data != null)
                {
                    cbPseudo.normalColor = Color.red;
                    RtxtInfos.text = "Pseudo Already Used";
                    Handheld.Vibrate();
                    RPseudo.colors = cbPseudo;
                    MyReader.Close();
                    return false;
                }

               else
                {
                    cbPseudo.normalColor = Color.white;
                    RtxtInfos.text = "";
                    RPseudo.colors = cbPseudo;
                }
            }
            MyReader.Close();
        }
        catch (Exception Ex) { Debug.Log(Ex.ToString()); }
        #endregion

        #region Email
        //Verification de l'Email
        ColorBlock cbEmail = REmail.colors;

        if (!IsValidEmail(REmail.text))
        {
            cbEmail.normalColor = Color.red;
            RtxtInfos.text = "Invalid Email";
            Handheld.Vibrate();
            REmail.colors = cbEmail;
            return false;
        }
 
        else
        {
            RtxtInfos.text = "";
            cbEmail.normalColor = Color.white;
            REmail.colors = cbEmail;
        }

        //Verification existance email
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` WHERE `email`='" + REmail.text + "'", con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();
            string data = null;

            while (MyReader.Read())
            {
                data = MyReader["password"].ToString();

                if (data != null)
                {
                    cbEmail.normalColor = Color.red;
                    RtxtInfos.text = "Email Already Used";
                    Handheld.Vibrate();
                    REmail.colors = cbEmail;
                    MyReader.Close();
                    return false;
                }

                else
                {
                    RtxtInfos.text = "";
                    cbEmail.normalColor = Color.white;
                    REmail.colors = cbEmail;
                }
            }
            MyReader.Close();
        }
        catch (Exception Ex) { Debug.Log(Ex.ToString()); }
        #endregion

        #region Password      
        //Password
        ColorBlock cbPassword = RPassword.colors;

        if (!IsValidLenght(RPassword.text, 5))
        {
            cbPassword.normalColor = Color.red;
            RtxtInfos.text = "Invalid Password";
            Handheld.Vibrate();
            RPassword.colors = cbPassword;
            return false;
        }

        else
        {
            cbPassword.normalColor = Color.white;
            RtxtInfos.text = "";
            RPassword.colors = cbPassword;
        }
        #endregion

        #region First Name
        //First Name
        ColorBlock cbFirstName = RFirstName.colors;

        if (!IsValidLenght(RFirstName.text, 1))
        {
            cbFirstName.normalColor = Color.red;
            RtxtInfos.text = "Please Enter Your First Name";
            Handheld.Vibrate();
            RFirstName.colors = cbFirstName;
            return false;
        }

        else
        {
            cbFirstName.normalColor = Color.white;
            RtxtInfos.text = "";
            RFirstName.colors = cbFirstName;
        }
        #endregion

        #region Last Name
        //Last Name
        ColorBlock cbLastName = RLastName.colors;

        if (!IsValidLenght(RLastName.text, 1))
        {
            cbLastName.normalColor = Color.red;
            RtxtInfos.text = "Please Enter Your Last Name";
            Handheld.Vibrate();
            RLastName.colors = cbLastName;
            return false;
        }

        else
        {
            cbLastName.normalColor = Color.white;
            RtxtInfos.text = "";
            RLastName.colors = cbLastName;
        }
        #endregion

        #region Gender
        ColorBlock cbGender = gender.colors;

        if (IsValidGender == false)
        {
            cbGender.normalColor = Color.red;
            RtxtInfos.text = "Select Your Gender";
            Handheld.Vibrate();
            gender.colors = cbGender;
            return false;
        }

        else
        {
            cbGender.normalColor = Color.white;
            RtxtInfos.text = "";
            gender.colors = cbGender;
        }
        #endregion

        #region Phone Number
        //Phone Number
        ColorBlock cbPhoneNumber = RPhoneNumber.colors;

        if (!IsValidLenght(RPhoneNumber.text, 7))
        {
            cbPhoneNumber.normalColor = Color.red;
            RtxtInfos.text = "Please Enter Your Phone Number";
            Handheld.Vibrate();
            RPhoneNumber.colors = cbPhoneNumber;
            return false;
        }

        else
        {
            cbPhoneNumber.normalColor = Color.white;
            RtxtInfos.text = "";
            RPhoneNumber.colors = cbPhoneNumber;
        }
        #endregion

        #region Address
        //Address
        ColorBlock cbAddress = RAddress.colors;

        if (!IsValidLenght(RAddress.text, 15))
        {
            cbAddress.normalColor = Color.red;
            RtxtInfos.text = "Please Enter Your Full Address";
            Handheld.Vibrate();
            RAddress.colors = cbAddress;
            return false;
        }

        else
        {
            cbAddress.normalColor = Color.white;
            RtxtInfos.text = "";
            RAddress.colors = cbAddress;
        }
        #endregion

        #region Year Of Birth
        //YearOfBirth
        ColorBlock cbYearOfBirth = RYearOfBirth.colors;

        if (!IsValidLenght(RYearOfBirth.text, 3))
        {
            cbYearOfBirth.normalColor = Color.red;
            RtxtInfos.text = "Invalid Year";
            Handheld.Vibrate();
            RYearOfBirth.colors = cbYearOfBirth;
            return false;
        }

        if (!IsValidLenghtMax(RYearOfBirth.text, 5))
        {
            cbYearOfBirth.normalColor = Color.red;
            RtxtInfos.text = "Invalid Year";
            Handheld.Vibrate();
            RYearOfBirth.colors = cbYearOfBirth;
            return false;
        }

        else
        {
            cbYearOfBirth.normalColor = Color.white;
            RtxtInfos.text = "";
            RYearOfBirth.colors = cbYearOfBirth;
        }
        #endregion

        #region Profile
        ColorBlock cbProfile = profile.colors;

        if (IsValidProfile == false)
        {
            cbProfile.normalColor = Color.red;
            RtxtInfos.text = "Select Your Profile";
            Handheld.Vibrate();
            profile.colors = cbProfile;
            return false;
        }

        else
        {
            cbProfile.normalColor = Color.white;
            RtxtInfos.text = "";
            profile.colors = cbProfile;
        }
        #endregion

        RtxtInfos.text = null;
        return true;
    }

    public void Register()
    {
        if (IsValid())
        {
            string cmd = "INSERT INTO `users` (`id`, `pseudo`, `email`, `password`, `firstname`, `lastname`, `gender`, `phonenumber`, `address`, `yearofbirth`, `profile`, `points`, `points2`, `points3`, `points4`, `points5`) VALUES(NULL, '" + RPseudo.text + "', '" + REmail.text + "', '" + Md5Sum(RPassword.text) + "', '" + RFirstName.text + "', '" + RLastName.text + "', '" + selectedGender.text + "', '" + RPhoneNumber.text + "', '" + RAddress.text + "','" + RYearOfBirth.text + "', '" + selectedProfile.text + "','0','0','0','0','0')";
            MySqlCommand CmdSql = new MySqlCommand(cmd, con);

            try
            {
                CmdSql.ExecuteReader();
                RtxtInfos.text = "Register Succesfull";
            }

            catch (Exception Ex)
            {
                RtxtInfos.text = Ex.ToString();
            }
        }

        else
        {
            Debug.Log("non valide");
        }
    }

    #region Cryptage Password
    string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }
    #endregion

    public void Login()
    {
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` WHERE `pseudo`='" + LPseudo.text + "'", con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();
            string data = null;
            
            while (MyReader.Read())
            {
                data = MyReader["password"].ToString();

                if (data == Md5Sum(LPassword.text))
                {
                    LtxtInfos.text = "Login Successfull";
                    IEmail = MyReader["email"].ToString();
                    IFirstName = MyReader["firstname"].ToString();
                    ILastName = MyReader["lastname"].ToString();
                    IGender = MyReader["gender"].ToString();
                    IPhoneNumber = MyReader["phonenumber"].ToString();
                    IAddress = MyReader["address"].ToString();
                    IYearOfBirth = MyReader["yearofbirth"].ToString();
                    IProfile = MyReader["profile"].ToString();
                    IPseudo = MyReader["pseudo"].ToString();
                    IPoints = (int)MyReader["points"];
                    IPoints2 = (int)MyReader["points2"];
                    IPoints3 = (int)MyReader["points3"];
                    IPoints4 = (int)MyReader["points4"];
                    IPoints5 = (int)MyReader["points5"];
                    SceneManager.LoadScene("CupMenu");
                }

                else
                {
                    LtxtInfos.text = "Wrong Login Or Password";
                }
            }

            if (data==null)
            {
                LtxtInfos.text = "Account Not Existing";
            }
            MyReader.Close();
        }

        catch (Exception Ex) { Debug.Log(Ex.ToString()); }
    }

    #region Show Register or Login
    public void ShowRegister()
    {
        CanvasLogin.gameObject.SetActive(false);
        CanvasRegister.gameObject.SetActive(true);
    }

    public void ShowLogin()
    {
        CanvasLogin.gameObject.SetActive(true);
        CanvasRegister.gameObject.SetActive(false);
    }
    #endregion

    #region Save Points Database
    public void savePoints()
    {
        string cmd = "UPDATE `users` SET `points`=" + IPoints + " WHERE `pseudo`= '" + IPseudo + "'";
        MySqlCommand CmdSql = new MySqlCommand(cmd, con);

        try
        {
            CmdSql.ExecuteReader();
            Debug.Log("update successful");
        }

        catch (Exception Ex)
        {
            Debug.Log(Ex.ToString());
        }
    }

    public void savePoints2()
    {
        string cmd = "UPDATE `users` SET `points2`=" + IPoints2 + " WHERE `pseudo`= '" + IPseudo + "'";
        MySqlCommand CmdSql = new MySqlCommand(cmd, con);

        try
        {
            CmdSql.ExecuteReader();
            Debug.Log("update successful");
        }

        catch (Exception Ex)
        {
            Debug.Log(Ex.ToString());
        }
    }

    public void savePoints3()
    {
        string cmd = "UPDATE `users` SET `points3`=" + IPoints3 + " WHERE `pseudo`= '" + IPseudo + "'";
        MySqlCommand CmdSql = new MySqlCommand(cmd, con);

        try
        {
            CmdSql.ExecuteReader();
            Debug.Log("update successful");
        }

        catch (Exception Ex)
        {
            Debug.Log(Ex.ToString());
        }
    }

    public void savePoints4()
    {
        string cmd = "UPDATE `users` SET `points4`=" + IPoints4 + " WHERE `pseudo`= '" + IPseudo + "'";
        MySqlCommand CmdSql = new MySqlCommand(cmd, con);

        try
        {
            CmdSql.ExecuteReader();
            Debug.Log("update successful");
        }

        catch (Exception Ex)
        {
            Debug.Log(Ex.ToString());
        }
    }

    public void savePoints5()
    {
        string cmd = "UPDATE `users` SET `points5`=" + IPoints5 + " WHERE `pseudo`= '" + IPseudo + "'";
        MySqlCommand CmdSql = new MySqlCommand(cmd, con);

        try
        {
            CmdSql.ExecuteReader();
            Debug.Log("update successful");
        }

        catch (Exception Ex)
        {
            Debug.Log(Ex.ToString());
        }
    }
    #endregion

    #region Leaderboards
    public string LeaderBoard(int Limit)
    {
        try
        {
            connect_BDD();
            MySqlCommand CmdSql=new MySqlCommand("SELECT * FROM `users` order by `points` DESC LIMIT " +Limit, con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();

            string data = null;
            while (MyReader.Read())
            {
                data += MyReader["pseudo"].ToString() + ":" + MyReader["points"] + "\n";
            }
            MyReader.Close();
            return data;
        }

        catch
        {
            return null;
        }
    }

    public string LeaderBoard2(int Limit)
    {
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` order by `points2` DESC LIMIT " + Limit, con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();

            string data = null;
            while (MyReader.Read())
            {
                data += MyReader["pseudo"].ToString() + ":" + MyReader["points2"] + "\n";
            }
            MyReader.Close();
            return data;
        }

        catch
        {
            return null;
        }
    }

    public string LeaderBoard3(int Limit)
    {
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` order by `points3` DESC LIMIT " + Limit, con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();

            string data = null;
            while (MyReader.Read())
            {
                data += MyReader["pseudo"].ToString() + ":" + MyReader["points3"] + "\n";
            }
            MyReader.Close();
            return data;
        }

        catch
        {
            return null;
        }
    }

    public string LeaderBoard4(int Limit)
    {
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` order by `points4` DESC LIMIT " + Limit, con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();

            string data = null;
            while (MyReader.Read())
            {
                data += MyReader["pseudo"].ToString() + ":" + MyReader["points4"] + "\n";
            }
            MyReader.Close();
            return data;
        }

        catch
        {
            return null;
        }
    }

    public string LeaderBoard5(int Limit)
    {
        try
        {
            connect_BDD();
            MySqlCommand CmdSql = new MySqlCommand("SELECT * FROM `users` order by `points5` DESC LIMIT " + Limit, con);
            MySqlDataReader MyReader = CmdSql.ExecuteReader();

            string data = null;
            while (MyReader.Read())
            {
                data += MyReader["pseudo"].ToString() + ":" + MyReader["points5"] + "\n";
            }
            MyReader.Close();
            return data;
        }

        catch
        {
            return null;
        }
    }
    #endregion
}