using System.Collections;
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
    public InputField RPassword, RLastName, RFirstName, REmail, RYearOfBirth;
    public Text RtxtInfos;
    MySqlConnection con;
    [Header("LOGIN")]
    public Canvas CanvasLogin;
    public InputField LPseudo;
    public InputField LPassword;
    public Text LtxtInfos;
    [Header("INFO USER")]
    public string IPseudo;
    public string ILastName, IFirstName, IEmail, IYearOfBirth;
    public int IPoints;

    private void Start()
    {
        connect_BDD();
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
       Debug.Log(con.State);
    }

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

    bool IsValidLenghtYear(string InputString, int LenghtString)
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

    bool IsValid()
    {
        //Verification de l'Email
        ColorBlock cbEmail = REmail.colors;

        if (!IsValidEmail(REmail.text))
        {
            RtxtInfos.text = "Invalid Email";
            cbEmail.normalColor = Color.red;
            REmail.colors = cbEmail;
            return false;
        }

        else
        {
            RtxtInfos.text = "";
            cbEmail.normalColor = Color.white;
            REmail.colors = cbEmail;
        }

        //Pseudo
        ColorBlock cbPseudo = RPseudo.colors;

        if (!IsValidLenght(RPseudo.text, 2))
        {
            cbPseudo.normalColor = Color.red;
            RtxtInfos.text = "Invalid Pseudo";
            RPseudo.colors = cbPseudo;
            return false;
        }
        else
        {
            cbPseudo.normalColor = Color.white;
            RtxtInfos.text = "";
            RPseudo.colors = cbPseudo;
        }

        //Password
        ColorBlock cbPassword = RPassword.colors;

        if (!IsValidLenght(RPassword.text, 5))
        {
            cbPassword.normalColor = Color.red;
            RtxtInfos.text = "Invalid Password";
            RPassword.colors = cbPassword;
            return false;
        }
        else
        {
            cbPassword.normalColor = Color.white;
            RtxtInfos.text = "";
            RPassword.colors = cbPassword;
        }

        //YearOfBirth
        ColorBlock cbYearOfBirth = RYearOfBirth.colors;

        if (!IsValidLenght(RYearOfBirth.text, 3))
        {
            cbYearOfBirth.normalColor = Color.red;
            RtxtInfos.text = "Invalid Year";
            RYearOfBirth.colors = cbYearOfBirth;
            return false;
        }

        if (!IsValidLenghtYear(RYearOfBirth.text, 5))
        {
            cbYearOfBirth.normalColor = Color.red;
            RtxtInfos.text = "Invalid Year";
            RYearOfBirth.colors = cbYearOfBirth;
            return false;
        }
        else
        {
            cbYearOfBirth.normalColor = Color.white;
            RtxtInfos.text = "";
            RYearOfBirth.colors = cbYearOfBirth;
        }

        //Other
        if (!IsValidLenght(RLastName.text, 0) || !IsValidLenght(RFirstName.text, 0))
        {
            RtxtInfos.text = "Empty Not Autorized";
            return false;
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

                if(data !=null)
                {
                    RtxtInfos.text = "Pseudo Already Used";
                    MyReader.Close();
                    return false;
                }
            }
            MyReader.Close();
        }
        catch(Exception Ex) { Debug.Log(Ex.ToString()); }

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
                    RtxtInfos.text = "Email Already Used";
                    MyReader.Close();
                    return false;
                }
            }
            MyReader.Close();
        }
        catch (Exception Ex) { Debug.Log(Ex.ToString()); }

        RtxtInfos.text = null;
        return true;
    }

    public void Register()
    {
        if (IsValid())
        {
            string cmd = "INSERT INTO `users` (`id`, `pseudo`, `password`, `lastname`, `firstname`, `email`, `yearofbirth`, `points`) VALUES(NULL, '" + RPseudo.text + "', '" + Md5Sum(RPassword.text) + "', '" + RLastName.text + "', '" + RFirstName.text + "', '" + REmail.text + "', '" + RYearOfBirth.text + "','0')";
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
                    ILastName = MyReader["lastname"].ToString();
                    IFirstName = MyReader["firstname"].ToString();
                    IEmail = MyReader["email"].ToString();
                    IYearOfBirth = MyReader["yearofbirth"].ToString();
                    IPseudo = MyReader["pseudo"].ToString();
                    IPoints = (int)MyReader["points"];
                    SceneManager.LoadScene("gametestkvn");
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
}