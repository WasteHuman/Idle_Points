using NewGameLogic.NewStorage;
using NewStorage;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace NewGameLogic.Data
{
    public class ClickUpgradesData : ISaveAndLoad
    {
        private float[] m_CostUpgrades;
        private float[] m_MultiplierUpgrades;

        private string m_FilePath;

        public float[] CostUpgrades => m_CostUpgrades;
        public float[] MultiplierUpgrades => m_MultiplierUpgrades;

        public ClickUpgradesData()
        {
            m_FilePath = Application.persistentDataPath + "DataUpgradesSave.save";
            InitializeData();
        }

        private void InitializeData()
        {
            m_CostUpgrades = new float[5];
            m_MultiplierUpgrades = new float[5];

            ClickUpgradesStorage clickUpgradesStorage = new();
            for (int i = 0; i < m_CostUpgrades.Length; i++)
            {
                m_CostUpgrades[i] = clickUpgradesStorage.costUpgrades[i];
                m_MultiplierUpgrades[i] = clickUpgradesStorage.multiplierUpgrades[i];
            }
        }

        private void CreateDefaultFile()
        {
            ClickUpgradesStorage defaultData = new();
            BinaryFormatter binaryFormatter = new();
            FileStream file = File.Create(m_FilePath);

            binaryFormatter.Serialize(file, defaultData);
            file.Close();

            Debug.Log("Default data file created!(CUD)");
        }

        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new();

            FileStream file = File.Create(m_FilePath);
            ClickUpgradesStorage clicksUpgradesStorage = new();

            clicksUpgradesStorage.costUpgrades = new float[5];
            clicksUpgradesStorage.multiplierUpgrades = new float[5];

            for (int i = 0; i < clicksUpgradesStorage.costUpgrades.Length; i++)
            {
                clicksUpgradesStorage.costUpgrades[i] = m_CostUpgrades[i];
                clicksUpgradesStorage.multiplierUpgrades[i] = m_MultiplierUpgrades[i];
            }

            binaryFormatter.Serialize(file, clicksUpgradesStorage);

            file.Close();
            Debug.Log("Click upgrades data saved!");
        }

        public void LoadData()
        {
            if (!File.Exists(m_FilePath))
            {
                CreateDefaultFile();
            }
            else if (File.Exists(m_FilePath))
            {
                BinaryFormatter binaryFormatter = new();
                FileStream file = File.Open(m_FilePath, FileMode.Open);
                ClickUpgradesStorage clicksUpgradesStorage = new()
                {
                    costUpgrades = new float[5],
                    multiplierUpgrades = new float[5]
                };

                clicksUpgradesStorage = (ClickUpgradesStorage)binaryFormatter.Deserialize(file);
                file.Close();

                for (int i = 0; i < m_CostUpgrades.Length; i++)
                {
                    m_CostUpgrades[i] = clicksUpgradesStorage.costUpgrades[i];
                    m_MultiplierUpgrades[i] = clicksUpgradesStorage.multiplierUpgrades[i];
                }

                Debug.Log("Click upgrades data loaded!");
            }
        }
    }
}
