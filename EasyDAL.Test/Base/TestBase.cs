﻿using EasyDAL.Test.Entities;
using EasyDAL.Test.Enums;
using EasyDAL.Test.TestModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace EasyDAL.Test
{
    public abstract class TestBase : IDisposable
    {
        protected WhereTestModel WhereTest
        {
            get
            {
                return new WhereTestModel
                {
                    CreatedOn = Convert.ToDateTime("2018-08-23 13:36:58").AddDays(-30),
                    DateTime_大于等于 = DateTime.Now.AddDays(-30),
                    DateTime_小于等于 = DateTime.Now,
                    AgentLevelXX = AgentLevel.DistiAgent,
                    ContainStr = "~00-d-3-1-",
                    In_List_枚举 = new List<AgentLevel>
                    {
                        AgentLevel.CityAgent,
                        AgentLevel.DistiAgent
                    },
                    In_Array_枚举 = new AgentLevel[]
                    {
                        AgentLevel.CityAgent,
                        AgentLevel.DistiAgent
                    },
                    In_List_String = new List<string>
                    {
                        "黄银凤",
                        "刘建芬"
                    },
                    In_Array_String = new string[]
                    {
                        "黄银凤",
                        "刘建芬"
                    }
                };
            }
        }

        protected LikeTestModel LikeTest
        {
            get
            {
                return new LikeTestModel
                {
                    无通配符 = "陈",
                    百分号 = "陈%",
                    下划线 = "王_",
                    百分号转义 = "刘/%_",
                    下划线转义 = "何/__"
                };
            }
        }

        protected IDbConnection Conn
        {
            /*
             * CREATE DATABASE `EasyDAL_Exchange`;
             */
            get { return GetOpenConnection("EasyDAL_Exchange"); }
        }

        protected IDbConnection Conn2
        {
            /*
             * CREATE DATABASE `rainbow_unicorn_db20180901` 
             */
            get { return GetOpenConnection("rainbow_unicorn_db20180901"); }
        }


        private static IDbConnection GetOpenConnection(string name)
        {
            /*
             * 
            */
            var conn = new MySqlConnection($"Server=localhost; Database={name}; Uid=SkyUser; Pwd=Sky@4321;SslMode=none;");
            conn.Open();
            //Hints.Hint = true;  // 全局 Hint 配置, 生产环境不要开启 
            return conn;
        }

        public void Dispose()
        {
            Conn.Close();
        }
    }

}
