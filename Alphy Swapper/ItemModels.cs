using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alphy2
{
    /// <summary>
    /// Represents a single Rocket League item mapping from items.json
    /// </summary>
    public class RlItem
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Product")]
        public string Product { get; set; }

        [JsonProperty("Slot")]
        public string Slot { get; set; }

        [JsonProperty("AssetPackage")]
        public string AssetPackage { get; set; }
    }

    /// <summary>
    /// The root object for deserializing the entire items.json file
    /// </summary>
    public class RlItemRoot
    {
        [JsonProperty("Items")]
        public List<RlItem> Items { get; set; }
    }

    /// <summary>
    /// A UI helper class designed to populate MaterialComboBoxes.
    /// It displays the clean product name while silently storing the integer ID.
    /// </summary>
    public class ItemComboBoxOption
    {
        public string DisplayName { get; set; }
        public int Id { get; set; }

        // Overriding ToString() is what tells the ComboBox what text to render in the UI
        public override string ToString()
        {
            return DisplayName;
        }
    }
}