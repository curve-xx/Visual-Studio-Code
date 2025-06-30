using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameStore.Frontend.Converters;

public class StringConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            // If the token is a number, read it as a string
            reader.TryGetInt32(out int intValue);
            return intValue.ToString();
        }

        // For other token types, return the string representation
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        // write the string value directly
        writer.WriteStringValue(value);
    }
}
