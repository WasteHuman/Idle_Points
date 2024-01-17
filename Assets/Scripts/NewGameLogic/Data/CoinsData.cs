using NewGameLogic.NewStorage;
using NewStorage;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace NewGameLogic.Data
{
    public class CoinsData : ISaveAndLoad
    {
        private string m_FilePath;

        private float m_Coins;
        private float m_CoinsPerClick;

        public float Coins => m_Coins;
        public float CoinsPerClick => m_CoinsPerClick;

        public CoinsData()
        {
            m_FilePath = Application.persistentDataPath + "GameSave.save";

            CoinsStorage coinsStorage = new();
            m_CoinsPerClick = coinsStorage.coinsPerClick;
        }

        public void IncreaseCoins()
        {
            m_Coins += m_CoinsPerClick;
        }

        public void IncreaseCoinsPerClick(float[] price, int priceIndex, float[] value, int valueIndex)
        {
            if (m_Coins >= price[priceIndex])
            {
                m_Coins -= price[priceIndex];
                m_CoinsPerClick *= value[valueIndex];
                price[priceIndex] *= 2f;
            }
            else
            {
                Debug.Log("There are not enough coins!");
            }
        }

        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new();
            FileStream file = File.Create(m_FilePath);

            CoinsStorage coinsStorage = new()
            {
                coinsStored = m_Coins,
                coinsPerClick = m_CoinsPerClick
            };

            binaryFormatter.Serialize(file, coinsStorage);

            file.Close();
            Debug.Log("Coins data saved!");
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
                CoinsStorage coinsStorage = new();

                coinsStorage = (CoinsStorage) binaryFormatter.Deserialize(file);
                file.Close();

                m_Coins = coinsStorage.coinsStored;
                m_CoinsPerClick = coinsStorage.coinsPerClick;

                Debug.Log("Coins data loaded!");
            }
        }

        private void CreateDefaultFile()
        {
            CoinsStorage defaultData = new();
            BinaryFormatter binaryFormatter = new();
            FileStream file = File.Create(m_FilePath);

            binaryFormatter.Serialize(file, defaultData);
            file.Close();

            Debug.Log("Default data file created!");
        }
    }
}
