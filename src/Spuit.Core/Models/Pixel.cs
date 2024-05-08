using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spuit.Core.Models
{
    [JsonSerializable(typeof(Pixel))]
    public record Pixel
    {
        public static Pixel? FromJson(string data)
            => JsonSerializer.Deserialize<Pixel>(data);

        [JsonPropertyName("position")]
        public Position Position { get; set; } = new Position();

        [JsonPropertyName("hex")]
        public string Hex { get; set; } = "";

        [JsonPropertyName("rgb")]
        public RGB Rgb { get; set; } = new RGB();

        [JsonPropertyName("hsl")]
        public HSL Hsl { get; set; } = new HSL();

        public string ToJson()
            => JsonSerializer.Serialize(this);
    }

    [JsonSerializable(typeof(Position))]
    public record Position
    {
        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }

    [JsonSerializable(typeof(RGB))]
    public record RGB
    {
        [JsonPropertyName("r")]
        public byte R { get; set; }

        [JsonPropertyName("g")]
        public byte G { get; set; }

        [JsonPropertyName("b")]
        public byte B { get; set; }
    }

    [JsonSerializable(typeof(HSL))]
    public record HSL
    {
        [JsonPropertyName("h")]
        public float H { get; set; }

        [JsonPropertyName("s")]
        public float S { get; set; }

        [JsonPropertyName("l")]
        public float L { get; set; }
    }
}