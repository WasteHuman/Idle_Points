using NewGameLogic.Data;
using NewGameLogic.NewAssets;
using NewStorage;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NewGameLogic.NewRunnerNamespace
{
    public class NewRunner : MonoBehaviour
    {
        private List<ISaveAndLoad> m_SaveAndLoads;

        private bool m_IsRunning;
        public bool IsRunning => m_IsRunning;

        public void StartRunning()
        {
            CreateAllLogic();
            m_IsRunning = true;
            DontDestroyOnLoad(this);
        }

        public void StopRunning()
        {
            m_IsRunning = false;
        }

        public ISaveAndLoad GetDataFromList(int index)
        {
            return m_SaveAndLoads[index];
        }

        private void CreateAllLogic()
        {
            m_SaveAndLoads = new List<ISaveAndLoad>
            {
                new CoinsData(),
                new ClickUpgradesData(),
            };
        }

        public void SaveDatas()
        {
            foreach (ISaveAndLoad saveAndLoad in m_SaveAndLoads)
            {
                try
                {
                    saveAndLoad.SaveData();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public void LoadDatas()
        {
            foreach (ISaveAndLoad saveAndLoad in m_SaveAndLoads)
            {
                try
                {
                    saveAndLoad.LoadData();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}