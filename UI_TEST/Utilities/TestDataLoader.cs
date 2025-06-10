
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Ensek.UITests.Utilities
{
    public class TestData
    {
        public List<EnergyTest> EnergyTests { get; set; }
    }

    public class EnergyTest
    {
        public string EnergyType { get; set; }
        public int ValidQuantity { get; set; }
        public int InvalidQuantity { get; set; }
    }

    public class TestDataLoader
    {
        public TestData Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TestData>(json);
        }
    }
}
