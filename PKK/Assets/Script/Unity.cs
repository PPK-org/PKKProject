using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;

public class Unity : MonoBehaviour
{
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;
    public InputField t_name, t_Address, t_id;
    public GameObject verifscreen;
    public Text data_staff;

    string DatabaseName = "SaveDB.s3db";
    
    void Start()
    {

        string filepath = Application.dataPath + "/Plugins/" + DatabaseName;

        //open db connection
        conn = "URI=file:" + filepath;

        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

      //  reader_function();
    }
    //Insert
    public void insert_button()
    {
        insert_function(DataPlayer.resume, DataPlayer.currenthealth, DataPlayer.xposition, DataPlayer.yposition, DataPlayer.zposition, DataPlayer.eventPlay, DataPlayer.backscene, DataPlayer.eventCount,  DataPlayer.level);

    }
    //Search 
    public void Search_button()
    {
        data_staff.text = "";
        Search_function(t_id.text);

    }

    //Found to Update 
    public void F_to_update_button()
    {
        data_staff.text = "";
        F_to_update_function(t_id.text);

    }
    //Update
    public void Update_button()
    {
        update_function(t_id.text, t_name.text, t_Address.text);

    }

    //Delete
    public void Delete_button()
    {
        data_staff.text = "";
        Delete_function(t_id.text);

    }

    //Insert To Database
    private void insert_function(bool resume, int currenthealth, float xposition, float yposition, float zposition, bool eventPlay, bool backscene, int eventCount, int level)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Update Savedat set resume = \"{0}\", currenthealth = \"{1}\", xposition =\"{2}\", yposition =\"{3}\", zposition =\"{4}\", eventPlay =\"{5}\", backscene =\"{6}\", eventCount =\"{7}\", level =\"{8}\"", resume, currenthealth, xposition, yposition, zposition, eventPlay, backscene, eventCount, level);// table name
            //sqlQuery = string.Format("insert into Savedat (resume, currenthealth, xposition, yposition, zposition, eventPlay, backscene, eventCount, level) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\")", resume, currenthealth, xposition, yposition, zposition, eventPlay, backscene, eventCount, level);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        //data_staff.text = "";
        Debug.Log("Insert Done  ");

        //reader_function();
    }
    //Read All Data For To Database
    public void reader_function()
    {
        // int idreaders ;
        string ok = "Y";
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT * FROM Savedat Where id="+"1";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                // idreaders = reader.GetString(1);
                ok = reader.GetString(1);
                if(ok.Equals("Y"))
                {
                    DataPlayer.resume = true;
                }else{
                    DataPlayer.resume = false;
                }
                
                DataPlayer.currenthealth = reader.GetInt32(2);
                DataPlayer.level = reader.GetInt32(9);
                DataPlayer.xposition = reader.GetFloat(3);
                DataPlayer.yposition = reader.GetFloat(4);
                DataPlayer.zposition = reader.GetFloat(5);
                ok = reader.GetString(6);
                if(ok.Equals("Y"))
                {
                    DataPlayer.resume = true;
                }else{
                    DataPlayer.resume = false;
                }
                ok = reader.GetString(7);
                if(ok.Equals("Y"))
                {
                    DataPlayer.resume = true;
                }else{
                    DataPlayer.resume = false;
                }
                DataPlayer.eventCount = reader.GetInt32(8);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            //       dbconn = null;
            verifscreen.SetActive(true);

        }
    }
    //Search on Database by ID
    private void Search_function(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            string Name_readers_Search, Address_readers_Search;
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT name,address " + "FROM Staff where id =" + Search_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                //  string id = reader.GetString(0);
                Name_readers_Search = reader.GetString(0);
                Address_readers_Search = reader.GetString(1);
                data_staff.text += Name_readers_Search + " - " + Address_readers_Search + "\n";

                Debug.Log(" name =" + Name_readers_Search + "Address=" + Address_readers_Search);

            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();


        }
   
    }


    //Search on Database by ID
    private void F_to_update_function(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            string Name_readers_Search, Address_readers_Search;
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT name,address " + "FROM Staff where id =" + Search_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
             
                Name_readers_Search = reader.GetString(0);
                Address_readers_Search = reader.GetString(1);
                t_name.text = Name_readers_Search;
                t_Address.text = Address_readers_Search;
          
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();


        }

    }
    //Update on  Database 
    private void update_function(string update_id, string update_name, string update_address)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Staff set name = @name ,address = @address where ID = @id ");

            SqliteParameter P_update_name = new SqliteParameter("@name", update_name);
            SqliteParameter P_update_address = new SqliteParameter("@address", update_address);
            SqliteParameter P_update_id = new SqliteParameter("@id", update_id);

            dbcmd.Parameters.Add(P_update_name);
            dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }



    //Delete
    private void Delete_function(string Delete_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "DELETE FROM Staff where id =" + Delete_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
        
           
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            data_staff.text = Delete_by_id + " Delete  Done ";

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}