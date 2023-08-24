using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Colors
{
    public class ColorsManager : MonoBehaviour
    {
        private string _folderPath = "Core/Resources";
        private string _fileName = "colors.json";
        private string _filePath;

        public List<Color> colors;
        
        private void Start()
        {
            _filePath = Path.Combine(Application.dataPath, _folderPath, _fileName);
            LoadColors();
        }

        [Button, DisableInEditorMode]
        public void SaveColors()
        {
            if (colors.Count == 0)
            {
                Debug.LogError("Color is null");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));

            List<ColorData> colorDataList = new List<ColorData>();
            foreach (Color color in colors)
            {
                ColorData colorData = new ColorData
                {
                    r = color.r,
                    g = color.g,
                    b = color.b,
                    a = color.a
                };
                colorDataList.Add(colorData);
            }

            string json = JsonConvert.SerializeObject(colorDataList);
            File.WriteAllText(_filePath, json);
        }

        [Button, DisableInEditorMode]
        public void LoadColors()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);

                List<ColorData> colorDataList = JsonConvert.DeserializeObject<List<ColorData>>(json);

                colors.Clear();
                foreach (ColorData colorData in colorDataList)
                {
                    Color color = new Color(colorData.r, colorData.g, colorData.b, colorData.a);
                    colors.Add(color);
                }
            }
            else
            {
                Debug.Log("File is empty");
            }
        }
    }
}