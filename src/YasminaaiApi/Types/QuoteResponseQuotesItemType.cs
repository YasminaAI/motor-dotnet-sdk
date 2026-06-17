using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using YasminaaiApi.Core;

namespace YasminaaiApi;

[JsonConverter(typeof(QuoteResponseQuotesItemType.QuoteResponseQuotesItemTypeSerializer))]
[Serializable]
public readonly record struct QuoteResponseQuotesItemType : IStringEnum
{
    public static readonly QuoteResponseQuotesItemType Tpl = new(Values.Tpl);

    public static readonly QuoteResponseQuotesItemType Comprehensive = new(Values.Comprehensive);

    public QuoteResponseQuotesItemType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static QuoteResponseQuotesItemType FromCustom(string value)
    {
        return new QuoteResponseQuotesItemType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(QuoteResponseQuotesItemType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(QuoteResponseQuotesItemType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(QuoteResponseQuotesItemType value) => value.Value;

    public static explicit operator QuoteResponseQuotesItemType(string value) => new(value);

    internal class QuoteResponseQuotesItemTypeSerializer
        : JsonConverter<QuoteResponseQuotesItemType>
    {
        public override QuoteResponseQuotesItemType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new QuoteResponseQuotesItemType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            QuoteResponseQuotesItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override QuoteResponseQuotesItemType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new QuoteResponseQuotesItemType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            QuoteResponseQuotesItemType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Tpl = "TPL";

        public const string Comprehensive = "Comprehensive";
    }
}
