using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Scripts.Colors
{
    public class ColorsManager : MonoBehaviour
    {
        [SerializeField] private List<Color> _colors;

        private string _folderPath = "Core/Resources";
        private string _fileName = "colors.json";
        private string _filePath;

        private void Awake()
        {
            _filePath = Path.Combine(Application.dataPath, _folderPath, _fileName);
            LoadColors();
        }

        public Color GetRandomColor() => _colors[Random.Range(0, _colors.Count)];

        [Button, DisableInEditorMode]
        public void SaveColors()
        {
            if (_colors.Count == 0)
            {
                Debug.LogError("Color is null");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));

            List<ColorData> colorDataList = new List<ColorData>();
            foreach (Color color in _colors)
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

                _colors.Clear();
                foreach (ColorData colorData in colorDataList)
                {
                    Color color = new Color(colorData.r, colorData.g, colorData.b, colorData.a);
                    _colors.Add(color);
                }
            }
            else
            {
                Debug.Log("File is empty");
            }
        }
    }
}