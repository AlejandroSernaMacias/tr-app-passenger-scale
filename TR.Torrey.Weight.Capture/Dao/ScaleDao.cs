using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TR.Torrey.Weight.Capture.Models;
using Microsoft.VisualBasic.ApplicationServices;

namespace TR.Torrey.Weight.Capture.Dao
{
    public class ScaleDao
    {
        public static async Task<string> save(Scale scale)
        {
            if (await exist(scale))
                return await update(scale);
            else
                return await create(scale);
        }
        public static async Task<bool> exist(Scale scale)
        {
            bool exist = false;

            try
            {
                SqliteConnection conn = new SqliteConnection(@"Data Source=" + Common.Common.DATABASE_PATH + ";");
                conn.Open();

                string sql = "SELECT * FROM " + Common.Common.DB_TABLE_SCALE + " WHERE vIp = '" + scale.vIp + "';";

                SqliteCommand command = new SqliteCommand(sql, conn);
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    exist = true;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                exist = false;
            }

            return exist;
        }
        public static async Task<string> update(Scale scale)
        {
            try
            {
                SqliteConnection conn = new SqliteConnection(@"Data Source=" + Common.Common.DATABASE_PATH + ";");
                conn.Open();

                SqliteCommand sql;
                sql = conn.CreateCommand();

                sql.CommandText = "UPDATE " + Common.Common.DB_TABLE_SCALE + " "
                                + "SET "
                                + "vName = '" + scale.vName + "',"
                                + "vPort = '" + scale.vPort + "',"
                                + "fMinWeight = " + scale.fMinWeight + ","
                                + "fTotal = " + scale.fTotal + ","
                                + "iMinTime = " + scale.iMinTime + ","
                                + "iSamples = " + scale.iSamples + ","
                                + "iStatus = " + scale.iStatus + ","
                                + "dtLastUpdate = " + scale.dtLastUpdate + " "
                                + "WHERE "
                                + "vIp = '" + scale.vIp + "';";
                sql.ExecuteNonQuery();
                conn.Close();

                var strResponse = new
                {
                    code = Common.Common.CODE_SUCCESS,
                    message = Common.Common.MSG_SCALE_SAVE_SUCCESS,
                    data = scale.vIp,
                };
                return JsonConvert.SerializeObject(strResponse);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var strResponse = new
                {
                    code = Common.Common.CODE_ERROR,
                    message = Common.Common.MSG_SCALE_SAVE_ERROR,
                    data = Common.Common.SCALE_IP_DEFAULT
                };
                return JsonConvert.SerializeObject(strResponse);
            }
        }

        public static async Task<string> create(Scale scale)
        {
            try
            {
                SqliteConnection conn = new SqliteConnection(@"Data Source=" + Common.Common.DATABASE_PATH + ";");
                conn.Open();

                SqliteCommand sql;
                sql = conn.CreateCommand();

                var vPort       = scale.vPort == null ? "" : scale.vPort;
                var vName       = scale.vName == null ? "" : scale.vName;
                var vStatusScale= scale.vStatusScale == null ? "" : scale.vStatusScale;
                var vIp         = scale.vIp == null ? Common.Common.SCALE_IP_DEFAULT : scale.vIp;
                var fMinWeight  = scale.fMinWeight == null ? Common.Common.ID_ZERO.ToString() : scale.fMinWeight;
                var fTotal      = scale.fTotal == null ? Common.Common.ID_ZERO.ToString() : scale.fTotal;
                var iSamples    = scale.iSamples == null ? Common.Common.ID_ZERO : scale.iSamples;
                var iMinTime    = scale.iMinTime == null ? Common.Common.ID_ZERO : scale.iMinTime;
                var iStatus     = scale.iStatus == null ? Common.Common.ID_ZERO : scale.iStatus;
                var dtLastUpdate= scale.dtLastUpdate == null ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : scale.dtLastUpdate;


                sql.CommandText = "INSERT INTO " + Common.Common.DB_TABLE_SCALE + " "
                                + "(vIp,vPort, vName, vStatusScale ,iSamples,iMinTime,iStatus,fMinWeight,fTotal,dtLastUpdate) "
                                + "VALUES("
                                + "'" + vIp + "',"
                                + "'" + vPort + "',"
                                + "'" + vName + "',"
                                + "'" + vStatusScale + "',"
                                + iSamples + ","
                                + iMinTime + ","
                                + iStatus + ","
                                + "'" + fMinWeight + "',"
                                + "'" + fTotal + "',"
                                + "'" + dtLastUpdate + "'); ";

                sql.ExecuteNonQuery();

                var strResponse = new
                {
                    code = Common.Common.CODE_SUCCESS,
                    message = Common.Common.MSG_SCALE_SAVE_SUCCESS,
                    data = vIp
                };
                return JsonConvert.SerializeObject(strResponse);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                var strResponse = new
                {
                    code = Common.Common.CODE_ERROR,
                    message = Common.Common.MSG_SCALE_SAVE_ERROR,
                    data = Common.Common.SCALE_IP_DEFAULT
                };
                return JsonConvert.SerializeObject(strResponse);
            }
        }

        public static async Task<string> delete(Scale scale)
        {
            try
            {
                var vIp = scale.vIp == null ? Common.Common.ID_ONE.ToString() : scale.vIp;

                SqliteConnection conn = new SqliteConnection(@"Data Source=" + Common.Common.DATABASE_PATH + ";");
                conn.Open();

                SqliteCommand sql;
                sql = conn.CreateCommand();

                sql.CommandText = "DELETE FROM " + Common.Common.DB_TABLE_SCALE + " WHERE vIp = '" + vIp + "';";
                sql.ExecuteNonQuery();

                conn.Close();

                var strResponse = new
                {
                    code = Common.Common.CODE_SUCCESS,
                    message = Common.Common.MSG_SCALE_DELETE_SUCCESS,
                    data = vIp
                };
                return JsonConvert.SerializeObject(strResponse);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

                var strResponse = new
                {
                    code = Common.Common.CODE_ERROR,
                    message = Common.Common.MSG_SCALE_SAVE_ERROR,
                    data = Common.Common.SCALE_IP_DEFAULT
                };
                return JsonConvert.SerializeObject(strResponse);
            }
        }

        public static async Task<string> scales()
        {
            var list = new List<Models.Scale>();

            SqliteConnection conn = new SqliteConnection(@"Data Source=" + Common.Common.DATABASE_PATH + ";");
            conn.Open();

            try
            {
                string sql = "SELECT * FROM " + Common.Common.DB_TABLE_SCALE + ";";
                SqliteCommand command = new SqliteCommand(sql, conn);
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Scale
                    {
                        vIp = reader["vIp"].ToString(),
                        vPort = reader["vPort"].ToString(),
                        vName = reader["vName"].ToString(),
                        iMinTime = int.Parse(reader["iMinTime"].ToString()),
                        iSamples = int.Parse(reader["iSamples"].ToString()),
                        iStatus = int.Parse(reader["iStatus"].ToString()),
                        fMinWeight = reader["fMinWeight"].ToString(),
                        fTotal = reader["fTotal"].ToString(),
                        dtLastUpdate = reader["dtLastUpdate"].ToString()
                    });
                }

                var strResponse = new
                {
                    code = Common.Common.CODE_SUCCESS,
                    message = Common.Common.MSG_SCALE_GET,
                    data = list
                };
                return JsonConvert.SerializeObject(strResponse);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var strResponse = new
                {
                    code = Common.Common.CODE_ERROR,
                    message = Common.Common.MSG_SCALE_SAVE_ERROR,
                    data = Common.Common.SCALE_IP_DEFAULT
                };
                return JsonConvert.SerializeObject(strResponse);
            }
        }
    }
}
